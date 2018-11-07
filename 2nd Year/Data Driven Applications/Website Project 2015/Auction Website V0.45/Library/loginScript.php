<?php
	include '../includes/config.php';
	include '../includes/functions.php';
	include '../includes/connection.php';
	secureSession();
	
	$username = $_POST['user'];
	$pass = $_POST['pass'];
	
	$cryptPass = encrypt($pass); 
	
	$stmt = $conn->prepare("SELECT * FROM users WHERE username = :username And password = :cryptPass"); //Uses PDO prepared statements to prevent sql injection
	$stmt->bindParam(':username', $username);
	$stmt->bindParam(':cryptPass', $cryptPass);
	$stmt->execute();
	
	if($stmt->fetch(PDO::FETCH_NUM) > 0)  //Checks how many rows contain this username
	{
		$_SESSION['user'] = $username;
		header("location:../index.php");
	}
	
	else
	{
		$_SESSION['status'] = "Incorrect username or password!";	
		header("location:../login.php");
	}
?>