<div class="container">
	<a href="index.php" id="logo">IrishTechShop</a>
	
	<form action = "search.php" method = "post">
		<input type="text" name="searchBox" id="searchBox">
		<input type="submit" name="searchBtn" class="button" id="searchBtn" value="Search">
	</form>
	
	<script type="text/javascript" src="library/jscript/toggleVisibility.js"></script>	
	<div id="toggleBtn"><a href="#" onclick="toggleVisibility('categories');">Categories &#9660;</a></div> <!-- Calls toggle function when button is pressed -->

	<?php
	if(isset($_SESSION['user']))
	{
		echo '<a href="account.php" class="button headerBtn">Account</a>';	
		echo '<a href="library/logoutScript.php" class="button headerBtn">Logout</a>';		
	}
	
	else
	{
		echo '<a href="register.php" class="button headerBtn">Register</a>';
		echo '<a href="login.php" class="button headerBtn">Log In</a>';
	}	
	?>
</div> 
			
			