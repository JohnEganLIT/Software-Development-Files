<?php include_once 'config/config.php';?>
<?php include_once 'config/connection.php';?>
<?php include_once 'library/functions.php';?>
<?php secureSession(); ?>

<!DOCTYPE HTML>
<html>
	<head>
		<title>Social Network</title>
		<link rel="icon" href="design/favicon.ico"/>	
		<link rel="stylesheet" href="design/style.css"/>
		<meta charset="UTF-8"/>		
	</head>

	<body>
		<header>
			<?php
			if(isset($_SESSION['userID']))
			{
			?>
				<div class="rowContainer">
					<!-- Logo -->
					<a href="profile.php" id="logoLoggedIn">Social Network</a> 
					
					<!-- Search box and button -->
					<form action="search.php" id="search" method="post"> 
						<input type="text" id="searchBox" name="search" maxlength="20" required>
						<input type="submit" id="searchBtn" value="Search">
					</form>
					
					<a href="templogoutscript.php" id="logoutBtn"> [Log Out] </a>
					
				</div>
			<?php
			}
			
			else
			{
				
			?>
				<div class="rowContainer">
					<!-- Logo -->
					<a href="index.php" id="logo">Social Network</a> 
				</div>
			<?php
			}
			?>
		</header>