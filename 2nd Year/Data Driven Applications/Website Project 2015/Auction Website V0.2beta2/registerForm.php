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
			<form action="library/register.php" method="POST">
				<h1>Register</h1>
				<p><label>User Name: </label>
				<input id="username" type="text" name="user" required ="required" /></p>
			 
				<p><label>Password: </label>
				<input id="password" type="password" name="pass" required ="required" /></p>
				
				<p><label>E-Mail: </label>
				<input id="username" type="email" name="email" required ="required" /></p>
				
				<input id="signInBtn" type="submit" name="submit" value="Register" />
					
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
		</div><!-- End  Main -->
		<div id = "footer">
			<?php include 'includes/footer.php' ?>
		</div>
	</body>
</html>