<?php
	$dbHost = 'localhost'; 
	$dbName = 'litrealty'; 
	$dbUser = 'sd3user'; //This needs to be changed to a user with limited privilages
	$dbPass = 'pass'; //Needs a password

	try
	{
		$conn = new PDO('mysql:host=' . $dbHost . ';dbname=' . $dbName, $dbUser, $dbPass);
		$conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
	}

	catch(PDOException $e) 
	{
		echo 'Connection failed: ' . $e->getMessage();
		die();
	}
?>