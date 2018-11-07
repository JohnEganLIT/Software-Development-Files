<?php include "includes/header.php" ?>		
<div class="main container">
	<form name="registerForm" id="loginForm" action="library/registerScript.php" method="POST">
		<fieldset>
			<legend>Register</legend>
			
			<label>Username</label>
			<input name="username" class="inputField" type="text" required />
			
			<label>Email</label>
			<input name="email" class="inputField" type="email" required />
			
			<label>Password</label>
			<input name="pass1" class="inputField" type="password" required />
			
			<label>Confirm Password</label>
			<input name="pass2" class="inputField" type="password" required />
			
			<input name="loginBtn" id="loginBtn" type="submit" value="Register"/>
		</fieldset>
		<p><a href="register.php">Already have an account? Click here to sign in.</a></p>
		<div class="status">
		<?php
			if(isset($_SESSION['status']))
			{
				echo $_SESSION['status'];
				unset($_SESSION['status']);
			}		
		?>
		</div>
	</form>
</div>		
<?php include "includes/footer.php" ?>	
