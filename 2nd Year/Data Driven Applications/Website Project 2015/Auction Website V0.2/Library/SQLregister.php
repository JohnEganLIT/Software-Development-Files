<?php
	include 'SQLconnection.php';
	
	session_start();

	if(!isset($_POST['user']) || !isset($_POST['email']) || !isset($_POST['pass1']) || !isset($_POST['pass2']))//Makes sure there are no empty fields
	{
		$_SESSION['regStatus'] = 'Please fill in all fields!';
		header("location:../register.php");
	}
	
	if($_POST['pass1'] != $_POST['pass2'])//compares pass 1 and pass 2
	{
		$_SESSION['regStatus'] = 'Passwords do not match!';
		header("location:../register.php");
	}
	
	$username = $_POST['user'];
	$email = $_POST['email'];
	$pass = $_POST['pass1'];
	
	$stmt = $conn->prepare("SELECT * FROM users WHERE username = '$username'");
	$stmt->execute();
	
	$stmt2 = $conn->prepare("SELECT * FROM users WHERE email = '$email'");
	$stmt2->execute();
	
	if($stmt->fetch(PDO::FETCH_NUM) > 0)  //Checks how many rows contain this username
	{
		$_SESSION['regStatus'] = 'UserName already exists!';
		header("location:../register.php");
	}
	
	elseif($stmt2->fetch(PDO::FETCH_NUM) > 0)  //Checks how many rows contain this email
	{
		$_SESSION['regStatus'] = 'Email already exists!';
		header("location:../register.php");
	}
	
	else
	{
		$key = "ireland";	//encryption key
		$cryptPass = crypt($pass, $key); //encrypts password
	
		$stmt = $conn->prepare("INSERT INTO users (username, email, password) VALUES ('$username', '$email', '$cryptPass')");
		$stmt->execute();
		
		$_SESSION['regStatus'] = 'Account Created!';
		header("location:../register.php");
	}
	
?>
