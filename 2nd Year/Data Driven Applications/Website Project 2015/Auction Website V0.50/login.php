<?php include 'includes/header.php'?>
<div class="main container">
	<!-- Login Form -->
	<form name="signInForm" id="form" action="library/loginScript.php" method="POST">
		<fieldset>
			<legend align="center">Login</legend>
			
			<label for="user">Username</label>
			<input id="user" type="text" name="user" required ="required"/><br>
			
			<label for="pass">Password</label>
			<input id="pass" type="password" name="pass" required ="required"/><br>
			
			<input id="formBtn" type="submit" class="button" name="submit" value="Sign In"/>
		</fieldset>
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
	<p><a href="register.php">New User? Click here to register new account.</a></p>
</div>
<?php include 'includes/footer.php'?>