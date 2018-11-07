<?php include "config/config.php";?>
<?php include "config/connection.php";?>
<?php include "library/functions.php";?>
<?php session_start(); ?>

<!DOCTYPE HTML>
<html>
	<head>
		<title>Auction Website</title>
		<link rel="icon" href="design/favicon.ico"/>	
		<link rel="stylesheet" href="design/style.css"/>
		<meta charset="UTF-8"/>		
	</head>

	<body>
		<header>
			<div class="container">
				<!-- Logo -->
				<a href="index.php" id="logo">Social Network</a> 
				
				<!-- Search box and button -->
				<form action="search.php" id="search" method="post"> 
					<input type="text" id="searchBox" name="search" maxlength="20" required>
					<input type="submit" id="searchBtn" value="Search">
				</form>
			</div>
		</header>