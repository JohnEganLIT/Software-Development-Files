<?php
	ini_set('session.cookie_httponly', true); //Prevents session ID being accessible via javascript
			
	session_start(); //Starts session

	session_regenerate_id(); //Regenerates session id every time session_start() is called

	if(isset($_SESSION['last_ip']) === false)
	{
		$_SESSION['last_ip'] = $_SERVER['REMOTE_ADDR']; //Sets last IP address
	}

	if($_SESSION['last_ip'] !== $_SERVER['REMOTE_ADDR']) //Compares last IP to current IP
	{
		session_unset(); //Unsets session variable
		session_destroy(); //Destroys session data. Logs out user. 
	}
?>

<div class="container">
	<a href="index.php" id="logo">IrishTechShop</a>

	<form action = "search.php" method = "post">
		<input type="text" name="searchBox" id="searchBox">
		<input type="submit" name="searchBtn" class="button" id="searchBtn" value="Search">
	</form>
	
	<script type="text/javascript">
		function toggle(id) //Toggles visability of categories
		{
			var e = document.getElementById(id);
			if(e.style.display == 'block')
			{
				e.style.display = 'none';
			}
			
			else
			{
				e.style.display = 'block';
			}
		}
	</script>	
	<div id="toggleBtn"><a href="#" onclick="toggle('categories');">Categories &#9660;</a></div> <!-- Calls toggle function when button is pressed

	<?php
		if(isset($_SESSION['user']))
		{
			echo '<a href="library/logout.php" class="button HeaderBtn">Logout</a>';
			echo '<a href="account.php" class="button headerBtn">Account</a>';		
		}
		
		else
		{
			echo '<a href="registerForm.php" class="button headerBtn">Register</a>';
			echo '<a href="loginForm.php" class="button headerBtn">Sign In</a>';
		}		
	?>
</div>
			
			