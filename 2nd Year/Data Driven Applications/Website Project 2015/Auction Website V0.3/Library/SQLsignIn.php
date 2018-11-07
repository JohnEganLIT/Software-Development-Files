<?php
	include 'SQLconnection.php';
	
	session_start();
	
	$username = $_POST['user'];
	$pass = $_POST['pass'];
	
	$salt = "6bT4Y7U469"; 
	$cryptPass = crypt($pass, $salt); 
	
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
		header("location:../signIn.php");
	}
?>