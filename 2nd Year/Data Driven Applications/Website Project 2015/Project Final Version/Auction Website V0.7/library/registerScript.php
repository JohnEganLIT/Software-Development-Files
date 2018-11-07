<?php
include '../includes/connection.php'; //Connection Parameters 
include '../includes/functions.php'; //PHP functions
secureSession(); //Starts secure session

if($_POST['username'] == '' || $_POST['email'] == '' || $_POST['pass1'] == '' || $_POST['pass2'] == '')//Makes sure there are no empty fields
{
	$_SESSION['statusBad'] = 'Please fill in all fields!';
	header("location:../register.php");
	exit();
}

if($_POST['pass1'] != $_POST['pass2'])//compares pass1 and pass2
{
	$_SESSION['statusBad'] = 'Passwords do not match!';
	header("location:../register.php");
	exit();
}

$username = $_POST['username'];
$email = $_POST['email'];
$pass = $_POST['pass1'];

try
{
	//PDO prepared statements to prevent sql injection
	$sql = 'SELECT username FROM users WHERE username = :username';
	$stmt = $conn->prepare($sql); 
	$stmt->bindParam(':username', $username);
	$stmt->execute(); //Finds entered username
	
	$sql2 = 'SELECT email FROM users WHERE email = :email';
	$stmt2 = $conn->prepare($sql2);
	$stmt2->bindParam(':email', $email);
	$stmt2->execute(); //Finds entered email
	
	if($stmt->fetch(PDO::FETCH_NUM) > 0)  //Checks how many rows contain this username
	{
		$_SESSION['statusBad'] = $username . ' already exists!';
		header("location:../register.php");
		exit();
	}
	
	elseif($stmt2->fetch(PDO::FETCH_NUM) > 0)  //Checks how many rows contain this email
	{
		$_SESSION['statusBad'] = $email . ' already exists!';
		header("location:../register.php");
		exit();
	}
	
	else
	{
		$cryptPass = encrypt($pass); //Gets encrypted version of entered password
	
		$sql3 = 'INSERT INTO users (username, email, password) VALUES (:username, :email, :pass)'; 
		$stmt3 = $conn->prepare($sql3);
		$stmt3->bindParam(':username', $username);
		$stmt3->bindParam(':email', $email);
		$stmt3->bindParam(':pass', $cryptPass);
		$result = $stmt3->execute();
		
		if($result) //Inserts username, email and password into a new row
		{
			$_SESSION['statusGood'] = 'Registration Successful! Please log in here!';
			header("location:../login.php");
			exit();
		}
		
		else
		{
			$_SESSION['statusBad'] = 'Error! Please contact an Admin!';
			header("location:../register.php");
			exit();
		}
	}	
}

catch(PDOException $e)
{
	$_SESSION['statusBad'] = "Error" . $e->getMessage();
	header("location:../register.php");
}
?>
