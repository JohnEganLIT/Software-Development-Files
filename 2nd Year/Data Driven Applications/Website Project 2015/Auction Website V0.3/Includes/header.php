<div class="container">
	<a href="index.php" id="logo">IrishTechShop</a>
	
	<form action = "search.php" method = "post">
		<input type="text" name="searchBox" id="searchBox">
		<input type="submit" name="searchBtn" class="button" id="searchBtn" value="Search">
	</form>
	
	<script type="text/javascript">
		function toggle_visibility(id) //Toggles visability of categories
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
	<div id="toggleBtn"><a href="#" onclick="toggle_visibility('categories');">Categories &#9660;</a></div>
	
	<?php
		session_start();
		if(isset($_SESSION['user']))
		{
			echo '<a href="cart.php" class="button HeaderBtn">Cart</a>';
			echo '<a href="register.php" class="button headerBtn">Account</a>';
			echo '<a href="library/signOut.php" class="button HeaderBtn">Sign Out</a>';				
		}
		
		else
		{
			echo '<a href="register.php" class="button headerBtn">Register</a>';
			echo '<a href="signIn.php" class="button headerBtn">Sign In</a>';
		}		
	?>
</div>
				
				