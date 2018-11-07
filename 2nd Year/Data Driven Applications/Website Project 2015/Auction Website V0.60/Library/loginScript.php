<?php
	include '../includes/functions.php'; //PHP functions
	include '../includes/connection.php'; //Connection parameters
	secureSession(); //Starts secure session
	
	$username = $_POST['user'];
	$pass = $_POST['pass'];
	
	$cryptPass = encrypt($pass); //Gets encrypted version of entered password
		
	try
	{
		$sql = 'SELECT * FROM users WHERE username = :username And password = :cryptPass';
		$stmt = $conn->prepare($sql); //PDO prepared statements to prevent sql injection
		$stmt->bindParam(':username', $username);
		$stmt->bindParam(':cryptPass', $cryptPass);
		$stmt->execute();
		
		if($stmt->fetch(PDO::FETCH_NUM) > 0)  //Checks how many rows contain this username
		{
			$_SESSION['user'] = $username;
			//$_SESSION['id'] = $id;
			header("location:../index.php");
		}
		
		else
		{
			$_SESSION['status'] = "Incorrect username or password!";	
			header("location:../login.php");
		}
	}
	
	catch(PDOException $e)
	{
		$_SESSION['status'] = $e->getMessage();
		header("location:../login.php");
	}
	
?>