<?php
include 'includes/config.php';
include 'includes/functions.php';
include 'includes/connection.php';
secureSession();
?>
<!DOCTYPE html>
<html lang="en">
	<head>
		<meta charset="UTF-8"/>
		<link rel="stylesheet" href="style.css"/>
		<link rel="icon" href="images/favicon.ico"/>
		<title>Auction Website</title>
	</head>
	<body>
		<!-- Header -->
		<header>
			<div class="container">
				<a href="index.php" id="logo">TechAuctions.ie</a>
				<form action = "search.php" id="search" method = "post">
					<input type="text" name="searchBox" id="searchBox">
					<input type="submit" name="searchBtn" id="searchBtn" class="button" value="Search">
				</form>
	
				<?php
				if(isset($_SESSION['user']))
				{
					echo '<div id="name">Hi, ' . $_SESSION['user'] . '</div>';
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
		</header>