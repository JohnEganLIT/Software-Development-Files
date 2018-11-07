<?php include "library/header.php" ?>
	
	<div id="main">	
		<?php 
		
		//Checks if registration form was submitted
		if(isset($_POST['register']))
		{			
			formValidation(); //PHP form validation. See library/functions.php		
				
		}		
		
		//Checks if login form was submitted
		if(isset($_POST['login']))
		{
			formValidation(); //PHP form validation. See library/functions.php	
		}
		
		?>
		
		<script src="library/jscript/validateForm.js"></script> <!--- Javascript Form Validation --->
		
		<!--- Registration Form --->
		<form id="regForm" method="post" autocomplete="off" action="<?php echo $_SERVER['PHP_SELF'];?>" method="post">
			<h2>Create Account</h2>
			<div>
				<input id="firstName" name="firstName" type="text" placeholder="First Name" maxlength="20" pattern="[a-zA-ZáéíóúÁÉÓÍÚ'-\s]*" title="Only letters, apostraphes and hyphens allowed. eg. Anne-Marie O'Brien" required />
				<input id="lastName" name="lastName" type="text"  placeholder="Last Name" maxlength="20" pattern="[a-zA-ZáéíóúÁÉÍÓÚ'-\s]*" title="Only letters, apostraphes and hyphens allowed. eg. Anne-Marie O'Brien" required />
			</div>			
			<div><input id="email1" name="email1" type="email" maxlength="40" placeholder="Email" required/></div>
			<div><input id="email2" name="email2" type="email" maxlength="40" placeholder="Re-type Email" required="true"/></div>			
			<div><input id="pass1" name="pass1" type="password" maxlength="30" placeholder="Password" required="true"/></div>		
			<div><input id="pass2" name="pass2" type="password" maxlength="30" placeholder="Re-type Password" required="true"/></div>
					
			<div id="birthDropList">
				<h4> Date of Birth </h4>
				<select name="birthDay" required="true">
				  <option name="day" selected>Day</option>
					<?php 
					for($i = 1; $i < 32; $i++)
					{
						echo "<option value=\"$i\">$i</option>";
					}
					?>
				</select>
				
				<select name="birthMonth"  >
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
			
				<select name="birthYear" required="true">
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
			<div><input id="regBtn" type="submit" name="register" value="Register" onsubmit="" /></div>
		</form>	
			
		<!--- Login Form --->			
		<form id="loginForm" method="post" autocomplete="off" action="<?php echo $_SERVER['PHP_SELF'];?>">		
			<h2>Log In</h2>
			<div><input name="email" type="text" maxlength="40" placeholder="Email" required="true" /></div>	
			<div><input name="pass1" type="text" maxlength="30" placeholder="Password" required="true" /></div>				
			
			<div><input id="loginBtn" type="submit" name="login" value="Log In" onsubmit="" /></div>
		</form>			
		
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
<?php include "library/footer.php" ?>
