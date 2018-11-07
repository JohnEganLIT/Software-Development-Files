<html>
	<head>
		<title>Auction Website</title>
		<?php include 'includes/style.php' ?>
	</head>
	<body>
		<div id = "header">
			<?php include 'includes/header.php' ?>
		</div><!--End Header -->
		
		<div id = "categories">
			<?php include 'includes/categories.php' ?> 
		</div><!--End Categories -->
		
		<div class = "container main">
			<form name="signInForm" id="form" action="library/register.php" method="POST">
				<fieldset>
					<legend>Sign In</legend>
				
					<label for="email">Email</label>
					<input id="email" type="text" name="user" required ="required"/><br>
				 
					<label for="password">Password</label>
					<input id="password" type="password" name="pass" required ="required"/><br>
					
					<input id="formBtn" type="submit" name="submit" value="Sign In"/>
				</fieldset>
				<?php
					session_start();
					if(isset($_SESSION['regStatus']))
					{
						echo $_SESSION['regStatus'];
						unset($_SESSION['regStatus']);
					}		

					else if(isset($_SESSION['regStatus']))
					{
						echo $_SESSION['regStatus'];
						unset($_SESSION['regStatus']);
					}
				?>
			</form>
			<p><a href="register.php">New User? Click here to register new account.</a></p>
		</div><!-- End  Main -->
		<div id = "footer">
			<?php include 'includes/footer.php' ?>
		</div>
	</body>
</html>