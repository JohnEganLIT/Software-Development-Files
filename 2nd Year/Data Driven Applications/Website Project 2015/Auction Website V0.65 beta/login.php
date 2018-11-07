<?php include "includes/header.php" ?>		
<div class="main container">
	<form name="loginForm" id="loginForm" action="library/loginScript.php" method="POST">
		<fieldset>
			<legend>Login</legend>
			
			<label>Username</label>
			<input name="username" class="inputField" type="text" required />
			
			<label>Password</label>
			<input name="pass1" class="inputField" type="password" required />
			
			<input name="loginBtn" id="loginBtn" type="submit" value="Sign In"/>
		</fieldset>
		<p><a href="register.php">New User? Click here to register new account.</a></p>
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