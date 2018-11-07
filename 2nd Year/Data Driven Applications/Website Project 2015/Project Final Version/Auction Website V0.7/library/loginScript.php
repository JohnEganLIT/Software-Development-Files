<?php
include '../includes/connection.php'; //Connection parameters
include '../includes/functions.php'; //PHP functions
secureSession(); //Starts secure session

$username = $_POST['username'];
$pass = $_POST['pass'];

$cryptPass = encrypt($pass); //Gets encrypted version of entered password

try
{
	$sql = 'SELECT id, username, email FROM users WHERE username = :username And password = :cryptPass';
	$stmt = $conn->prepare($sql); 
	$stmt->bindParam(':username', $username);
	$stmt->bindParam(':cryptPass', $cryptPass);
	$stmt->execute(); //Selects rows with entered username and encrypted password
	
	if($row = $stmt->fetch())  
	{	
		$_SESSION['id'] = $row['id'];
		header("location:../index.php");
		exit();
	}
	
	else
	{
		$_SESSION['statusBad'] = "Incorrect username or password!";	
		header("location:../login.php");
		exit();
	}
}

catch(PDOException $e)
{
	$_SESSION['statusBad'] = $e->getMessage();
	header("location:../login.php");
}

?>