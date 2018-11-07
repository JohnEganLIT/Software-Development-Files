<?php include "library/header.php" ?>
	
	<div id="main">	
		<?php 
		$_SESSION['loginStatusGood'] = 'Logged In';
		$_SESSION['regStatusBad'] = 'You done fucked up boy';
		//Checks if any registration form fields were submitted
		if(isset($_POST['firstName']) || isset($_POST['lastName']) || isset($_POST['email1']) || isset($_POST['email2']) || isset($_POST['pass1']) 
		|| isset($_POST['pass2']) || isset($_POST['birthDay']) || isset($_POST['birthMonth']) || isset($_POST['birthYear']))
		{
			//Checks if all registration form fields were submitted
			if(isset($_POST['firstName']) && isset($_POST['lastName']) && isset($_POST['email1']) && isset($_POST['email2']) && isset($_POST['pass1']) 
			&& isset($_POST['pass2']) && isset($_POST['birthDay']) && isset($_POST['birthMonth']) && isset($_POST['birthYear']))
			{
				$_SESSION['regStatusGood'] = 'Account Created Successfully. Log In Here :)';
			}
			
			else
			{
				$_SESSION['regStatusBad'] = 'Error Creating Account!';
			}		
		}
		
		//Checks if any login form fields were submitted 
		if(isset($_POST['email']) || isset($_POST['password']))
		{
			//Checks if all login form fields were submitted
			if(isset($_POST['email']) && isset($_POST['password']))
			{
				$_SESSION['loginStatusGood'] = 'Logged In';
				unset($_POST);
			}		
			
			else
			{
				$_SESSION['loginStatusBad'] = 'Error Logging In!';
			}
		}
		
		?>
		
		<script src="library/jscript/validateForm.js"></script> <!--- Form Validation Javascript--->
		
		<!--- Registration Form --->
		<form id="regForm" method="post" autocomplete="off" action="<?php echo $_SERVER['PHP_SELF'];?>" method="post">
			<h2>Create Account</h2>
			<div>
				<input id="name" name="firstName" type="text" maxlength="20" placeholder="First Name" required="true" />
				<input id="name" name="lastName" type="text" maxlength="20" placeholder="Last Name" required="true"  />
			</div>			
			<div><input id="email1" name="email1" type="email" maxlength="40" placeholder="Email" required="true"  /></div>
			<div><input id="email2" name="email2" type="email" maxlength="40" placeholder="Re-type Email" required="true"  /></div>			
			<div><input id="pass1" name="pass1" type="password" maxlength="30" placeholder="Password" required="true"  /></div>		
			<div><input id="pass2" name="pass2" type="password" maxlength="30" placeholder="Re-type Password" required="true"  /></div>
			
			
			<div id="birthDropList">
				<h4> Date of Birth </h4>
				<select name="birthDay" required="true" >
				  <option name="day" selected>Day</option>
					<?php 
					for($i = 1; $i < 32; $i++)
					{
						echo "<option value=\"$i\">$i</option>";
					}
					?>
				</select>
				
				<select name="birthMonth" required="true" >
				  <option value="" selected>Month</option>
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
			
				<select name="birthYear" required="true" >
				  <option value="" selected>Year</option>
					<?php 
					for($i = 2016; $i > 1916; $i--)
					{
						echo "<option value=\"$i\">$i</option>";
					}
					?>		  
				</select>
			</div>
			
			<div id="genderBtn" >
				<label>Male</label>
				<input type="radio" name="radiobutton" value="Male" required="true">

				<label>Female</label>
				<input type="radio" name="radiobutton" value="Female" required="true">			
			</div>
			<div><input id="regBtn" type="submit" value="Register" onsubmit="" /></div>
			<?php
			//Displays Registration Errors
			echo '<div class="statusBad">';
				if(isset($_SESSION['regStatusBad']))
				{
					echo $_SESSION['regStatusBad'];
					unset($_SESSION['regStatusBad']);
				}		
			echo '</div>';
			?>
		</form>	
			
		<!--- Login Form --->			
		<form id="loginForm" method="post" autocomplete="off" action="<?php echo $_SERVER['PHP_SELF'];?>">		
			<h2>Log In</h2>
			<div><input name="email" type="text" maxlength="25" placeholder="Email" required="true"  /></div>	
			<div><input name="password" type="text" maxlength="25" placeholder="Password" required="true"  /></div>				
			
			<div><input id="loginBtn" type="submit" value="Log In" onsubmit="" /></div>
		
			<?php
			//Displays Login Errors/ Registration Success
			echo '<div class="statusGood">';
				if(isset($_SESSION['loginStatusGood']))
				{
					echo $_SESSION['loginStatusGood'];
					unset($_SESSION['loginStatusGood']);
				}		
			echo '</div>';
			
			echo '<div class="statusGood">';
				if(isset($_SESSION['regStatusGood']))
				{
					echo $_SESSION['regStatusGood'];
					unset($_SESSION['regStatusGood']);
				}		
			echo '</div>';
			
			echo '<div class="statusBad">';
				if(isset($_SESSION['loginStatusBad']))
				{
					echo $_SESSION['loginStatusBad'];
					unset($_SESSION['loginStatusBad']);
				}		
			echo '</div>';
			?>
		</form>			
	</div>
<?php include "library/footer.php" ?>
