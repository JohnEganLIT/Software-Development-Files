<?php include "library/header.php" ?>	
	<main>	
		<?php 
		
		//Checks if registration form was submitted
		if(isset($_POST['register']))
		{			
			formValidation(); //PHP form validation. See library/functions.php	
				
			$userID = uniqid(); //Creates unique id for user
			$firstName = $_POST['firstName'];
			$lastName = $_POST['lastName'];
			$email = $_POST['email1'];
			$password = encryptPass($_POST['pass1'], $userID); //Gets encrypted version of password. See library/functions encryptPass()
			$dob = ($_POST['birthYear'] . "/" . $_POST['birthMonth'] . "/" . $_POST['birthDay']); //Puts birth day, month, and year into a string for saving to db
			$gender = $_POST['gender'];
			
			if(checkEmail($email))
			{
				$_SESSION['statusBad'] = "Email already exists!"; 
				header('Location: '.$_SERVER['REQUEST_URI']);
				exit;
			}
			
			if(dbInsert("INSERT INTO profile (profileID) VALUES (?)", $userID) == FALSE) 
			{
				$_SESSION['statusBad'] = 'Error Creating Account';
			}
			
			mkdir("images/$userID"); //Creates images folder for user
			
			if(dbInsert("INSERT INTO users (userID, firstName, lastName, email, password, dateOfBirth, gender) VALUES (?, ?, ?, ?, ?, ?, ?)", 
			$userID, $firstName, $lastName, $email, $password, $dob, $gender))
			{
				$_SESSION['userID'] = $userID;
				header('Location:editprofile.php');
				exit();
			}
			
			else
			{
				$_SESSION['statusBad'] = 'Error Creating Account';
			}
					
			header('Location: '.$_SERVER['REQUEST_URI']);
			exit();
		}		
		
		//Checks if login form was submitted
		if(isset($_POST['login']))
		{
			formValidation(); //PHP form validation. See library/functions.php	
		
			try
			{
				$sql = 'SELECT userID FROM users WHERE email = :email';
			
				$stmt = $conn->prepare($sql); 
				$stmt->bindParam(':email', $_POST['email']);
				$stmt->execute(); 
				
				$result = $stmt->fetch();
				
				if($result)
				{
					$userID = $result['userID'];	
				}
				
				else
				{
					$_SESSION['statusBad'] = 'Email doesn\'t exist';
					header('Location: '.$_SERVER['REQUEST_URI']);
					exit;
				}
				
				$cryptPass = encryptPass($_POST['pass'], $userID); //Gets encrypted version of password. See library/functions encryptPass()
					
				$sql = 'SELECT userID, password FROM users WHERE userID = :userID And password = :cryptPass';

				$stmt = $conn->prepare($sql); 
				$stmt->bindParam(':userID', $userID);
				$stmt->bindParam(':cryptPass', $cryptPass);
				$stmt->execute(); //Selects rows with entered username and encrypted password
				
				$result = $stmt->fetch();
				
				if($result)  
				{	
					$_SESSION['userID'] = $result['userID']; //Creates session containing userID which logs in the user
					header("location: profile.php");
					exit();
				}
				
				else
				{
					$_SESSION['statusBad'] = "Incorrect email or password!";	
					header('Location: '. $_SERVER['REQUEST_URI']);
					exit();
				}
			}
			
			catch(PDOException $e)
			{
				$_SESSION['debug'] = $e->getMessage();
			}
		}
		
		if(isset($_SESSION['userID']))
		{
			header('Location: profile.php');
			exit;
		}		

		?>
		
		<script src="library/jscript/validateRegForm.js"></script> <!--- Javascript Form Validation --->

		<section class="container">	
			<!--- Registration Form --->
			<form id="regForm" name="regForm" method="post" autocomplete="off"  action="<?php echo $_SERVER['PHP_SELF'];?>" onsubmit="return validateRegForm()">			
				<h2>Create Account</h2>
				
				<input id="firstName" name="firstName" type="text" placeholder="First Name" maxlength="20" pattern="[a-zA-ZáéíóúÁÉÓÍÚ'-\s]*" title="Only letters, apostraphes and hyphens allowed. eg. Anne-Marie O'Brien" required/>
				<input id="lastName" name="lastName" type="text"  placeholder="Last Name" maxlength="20" pattern="[a-zA-ZáéíóúÁÉÍÓÚ'-\s]*" title="Only letters, apostraphes and hyphens allowed. eg. Anne-Marie O'Brien" required/>
				<input id="email1" name="email1" type="email" maxlength="40" placeholder="Email" required />
				<input id="email2" name="email2" type="email" maxlength="40" placeholder="Re-type Email" required />	
				<input id="pass1" name="pass1" type="password" minlength="5" maxlength="30" placeholder="Password" required />
				<input id="pass2" name="pass2" type="password" minlength="5" maxlength="30" placeholder="Re-type Password" required />
				
				<div id="birthday">
					<label> Date of Birth </label>
					
					<select id="birthDay" name="birthDay" >
						<option selected value="">Day</option>
						<?php 
						for($i = 1; $i < 32; $i++)
						{
							echo "<option value=\"$i\">$i</option>";
						}
						?>
					</select>
					
					<select id="birthMonth" name="birthMonth" >
					  <option selected value="">Month</option>
					  <option value="1">January</option>
					  <option value="2">February</option>
					  <option value="3">March</option>
					  <option value="4">April</option>
					  <option value="5">May</option>
					  <option value="6">June</option>
					  <option value="7">July</option>
					  <option value="8">August</option>
					  <option value="9">September</option>
					  <option value="10">October</option>
					  <option value="11">November</option>
					  <option value="12">December</option>
					</select>
					
					<select id="birthYear" name="birthYear" >
					  <option selected value="">Year</option>
						<?php 
						for($i = 2016; $i > 1915; $i--)
						{
							echo "<option value=\"$i\">$i</option>";
						}
						?>		  
					</select>
				</div>
				
				<div id="genderBtns">
					<label>Male</label>
					<input type="radio" name="gender" value="male" required >

					<label>Female</label>
					<input type="radio" name="gender" value="female" required >	

					<label>Other</label>
					<input type="radio" name="gender" value="Other" required >	
				</div>

				<div><input id="regBtn" type="submit" name="register" value="Register" /></div>
			</form>	
				
			<!--- Login Form --->			
			<form id="loginForm" name="loginForm" method="post" action="<?php echo $_SERVER['PHP_SELF'];?>">		
				<h2>Log In</h2>
				<input name="email" type="email" maxlength="40" placeholder="Email" required />
				<input name="pass" type="password"  minlength="5" placeholder="Password" required />			
				
				<input id="loginBtn" type="submit" name="login" value="Log In" />
			</form>			
			
			<div class="container">
				<div id="status">
				<?php
					//Displays Login Errors/ Registration Success			
					echo '<div class="statusGood">';
						if(isset($_SESSION['statusGood']))
						{
							echo $_SESSION['statusGood'];
							unset($_SESSION['statusGood']);
						}		
					echo '</div>';
					
					echo '<div class="statusBad">';
						if(isset($_SESSION['statusBad']))
						{
							echo $_SESSION['statusBad'];
							unset($_SESSION['statusBad']);
						}		
					echo '</div>';
					?>
				</div>
			</div>
		</section>
	</main>
<?php include "library/footer.php" ?>
