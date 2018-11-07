<?php
	include '../includes/config.php';
	include '../includes/functions.php';
	include '../includes/connection.php';
	secureSession();
	
	if($_POST['user'] == '' || $_POST['email'] == '' || $_POST['pass1'] == '' || $_POST['pass2'] == '')//Makes sure there are no empty fields
	{
		$_SESSION['status'] = 'Please fill in all fields!';
		header("location:../register.php");
	}
	
	elseif(strcmp($_POST['pass1'], $_POST['pass2']) !== 0)//compares pass1 and pass2
	{
		$_SESSION['status'] = 'Passwords do not match!';
		header("location:../register.php");
	}
	
	$username = $_POST['user'];
	$email = $_POST['email'];
	$pass = $_POST['pass1'];
	
	$stmt = $conn->prepare("SELECT * FROM users WHERE username = :username"); //Uses PDO prepared statements to prevent sql injection
	$stmt->bindParam(':username', $username);
	$stmt->execute();
	
	$stmt2 = $conn->prepare("SELECT * FROM users WHERE email = :email");
	$stmt2->bindParam(':email', $email);
	$stmt2->execute();
	
	if($stmt->fetch(PDO::FETCH_NUM) > 0)  //Checks how many rows contain this username
	{
		$_SESSION['status'] = $username . ' already exists!';
		header("location:../register.php");
	}
	
	elseif($stmt2->fetch(PDO::FETCH_NUM) > 0)  //Checks how many rows contain this email
	{
		$_SESSION['status'] = $email . ' already exists!';
		header("location:../register.php");
	}
	
	else
	{
		$salt = "6bT4Y7U469";	//encryption key
		$cryptPass = crypt($pass, $salt); //encrypts password
	
		$stmt3 = $conn->prepare("INSERT INTO users (username, email, password) VALUES (:username, :email, :pass)");
		$stmt3->bindParam(':username', $username);
		$stmt3->bindParam(':email', $email);
		$stmt3->bindParam(':pass', $cryptPass);
		$flag = pdoInsert($stmt3);
		
		if($flag == true)
		{
			$_SESSION['status'] = 'Registration Successful! Please log in here!';
			header("location:../login.php");
		}
		
		else
		{
			$_SESSION['status'] = 'Error! Please contact an Admin!';
			header("location:../register.php");
		}
	}	
	
?>
