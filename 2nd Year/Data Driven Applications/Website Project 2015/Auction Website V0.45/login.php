<?php 
include 'includes/config.php';
include 'includes/functions.php';
include 'includes/connection.php';
secureSession();
?>
<!DOCTYPE html>
<html>
<head>
	<title>Auction Website</title>
	<link rel="stylesheet" type="text/css" href="<?php echo style; ?>">
</head>
<body>
	<div id="wrapper">
		<div id="header">
			<?php include header ?>
		</div><!--End Header -->
		
		<div id="categories">
			<?php include categories ?>
		</div><!--End Categories -->
		
		<div class="container main">
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
		</div><!-- End Main -->
		
		<div id="footer">
			<?php include footer ?>
		</div><!-- End Footer -->
	</div><!-- End Wrapper -->
</body>
</html>