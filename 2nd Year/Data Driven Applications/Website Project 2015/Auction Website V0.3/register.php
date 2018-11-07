<html>
	<head>
		<title>Auction Website</title>
		<?php include 'includes/style.php'; ?>
		<script type="text/javascript">
			window.onload = function() 
			{
				document.getElementById("pass1").onchange = validatePassword;
				document.getElementById("pass2").onchange = validatePassword;
			}
			
			function validatePassword()
			{
				var pass2=document.getElementById("pass2").value;
				var pass1=document.getElementById("pass1").value;
			
				if(pass1 != pass2)
				{
					document.getElementById("pass2").setCustomValidity("Passwords Don't Match");
				}
					
				else
				{
					document.getElementById("pass2").setCustomValidity('');
				}		
			}
		</script>
	</head>
	<body>
		<div id = "header">
			<?php include 'includes/header.php'; ?>
		</div><!--End Header -->
		
		<div id = "categories">
			<?php include 'includes/categories.php'; ?> 
		</div><!--End Categories -->
		
		<div class = "container main">
			<form name="regForm" id="form" method="POST" action="library/SQLregister.php">
				<fieldset>
					<legend>Register</legend>
					 
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
		</div><!-- End  Main -->
		<div id = "footer">
			<?php include 'includes/footer.php'; ?>
		</div>
	</body>
</html>