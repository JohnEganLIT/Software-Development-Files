<?php include_once 'config/config.php';?>
<?php include_once 'config/connection.php';?>
<?php include_once 'library/functions.php';?>
<?php secureSession(); ?>

<!DOCTYPE HTML>
<html>
	<head>
		<title>The Buddy Book</title>
		<link rel="icon" href="design/favicon.ico"/>	
		<link rel="stylesheet" href="design/style.css"/>
		<meta charset="UTF-8"/>		
	</head>

	<body>
		<header>
			<?php
			//Checks if user pressed logout button
			if(isset($_POST['logout']))
			{
				session_unset(); //Unsets session variable
				session_destroy(); //Destroys session data. Logs out user. 
				
				header('location:index.php');
				exit;
			}
			
			//Checks if user is logged in
			if(isset($_SESSION['userID']))
			{
			?>
				<div class="rowContainer">
					<!-- Logo -->
					<a href="profile.php" id="logoLoggedIn">The Buddy Book</a> 
					
					<!-- Search box and button -->
					<form action="search.php" id="search" method="post"> 
						<input type="text" id="searchBox" name="searchTerm" maxlength="35" value="<?php if(isset($_POST['searchTerm'])) echo $_POST['searchTerm']; ?>" >
						<input type="submit" id="searchBtn" name="search" value="Search">
					</form>
					
					<a href="editProfile.php">"<img src="design/cog.jpg" id="settingsCog"/></a>
					
					<?php echo '<img src="' . getProfPic($_SESSION['userID']) . '" id="profilePicHeader" alt="My Profile Picture">'; ?>
					
					<form action="<?php echo $_SERVER['PHP_SELF'];?>" method="post" id="logoutBtnForm">
						<?php echo 'Hi, ' . getFirstName($_SESSION['userID']); ?> 
						<input type="submit" name="logout" value="[Log Out]" id="logoutBtn">
					</form>				
				</div>
			<?php
			}
			
			else
			{
				
			?>
				<div class="rowContainer">
					<!-- Logo -->
					<a href="index.php" id="logo">The Buddy Book</a> 
				</div>
			<?php
			}
			?>
		</header>