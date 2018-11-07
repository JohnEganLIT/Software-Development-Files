<?php
	$dbHost = 'localhost'; 
	$dbName = 'projectdb'; 
	$dbUser = 'root'; //This needs to be changed to a user with limited privilages
	$dbPass = ''; //Needs a password

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