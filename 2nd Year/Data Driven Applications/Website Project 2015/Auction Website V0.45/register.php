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
			<form name="regForm" id="form" method="POST" action="library/registerScript.php">
				<fieldset>
					<legend align="center">Register</legend>
					 
					<label for="user">Username</label>
					<input id="user" type="text" name="user" minlength="5" maxlength="15" required/>
					
					<label for="email">Email</label>
					<input id="email" type="email" name="email" minlength="5" maxlength="30" required/>
					
					<label for="pass1">Password</label>
					<input id="pass1" type="password" name="pass1" minlength="5" maxlength="20" required/>
					
					<label for="pass2">Confirm Password</label>
					<input id="pass2" type="password" name="pass2" minlength="5" maxlength="20" required"/>
					
					<input id="formBtn" type="submit" name="submit" class="button" value="Register" />
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
			<p><a href="register.php">Already have an account? Click here to sign in.</a></p>
		</div><!-- End Main -->
		
		<div id="footer">
			<?php include footer ?>
		</div><!-- End Footer -->
	</div><!-- End Wrapper -->
</body>
</html>