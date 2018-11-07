<!-- This file is included at the top of every page viewable by the user -->
<?php
include 'includes/connection.php'; //Connection parameters
include 'includes/functions.php'; //PHP functions
secureSession(); //Starts secure session
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
				<a href="index.php" id="logo">TechAuctions.ie</a> <!-- Logo -->
				
				<!-- Search box and button -->
				<form action ="search.php" id="search" method ="post"> 
					<input type="text" name="search" id="searchBox" maxlength="20" required>
					<input type="submit" id="searchBtn" class="button" value="Search">
				</form>
	
				<?php
				if(isset($_SESSION['id'])) //If user is logged in 
				{
					try
					{
						$sql = 'SELECT username FROM users WHERE id=:id';
						$stmt = $conn->prepare($sql); //PDO prepared statements to prevent sql injection
						$stmt->bindParam(':id', $_SESSION['id']);
						$stmt->execute();
						
						if($row = $stmt->fetch())  //Gets username from row with this id
						{	
							$username = $row['username'];
						}
					}

					catch(PDOException $e)
					{
						echo "Error: " . $e->getMessage();
						exit();
					}
					
					echo '<div id="username">Hi, ' . $username . '<br><a href="library/logoutScript.php" id="logoutBtn"><sub> [Log Out] </sub></a></div>'; //Displays username and logout button
					if($_SESSION['id'] == 1) //If Admin is logged in
					{
						echo '<a href="account.php" class="headerBtn">Control Panel</a>';	//Control Panel button
					}
					else
					{
						echo '<a href="account.php" class="headerBtn">Account</a>';	//Account button
					}
					echo '<a href="auction.php" class="headerBtn">Auction</a>'; //Auction button
				}
				
				else //If user is not logged in 
				{
					echo '<a href="register.php" class="headerBtn">Register</a>'; //Displays if logged out
					echo '<a href="login.php" class="headerBtn">Log In</a>';
				}	
				?>
			</div>
		</header>