<?php
	//Sets up database
	$dbHost = 'localhost';
	$dbName = 'projectdb';
	$dbUser = 'root';
	$dbPass = '';

	try{
		$conn = new PDO('mysql:host=' . $dbHost . ';dbname=' . $dbName, $dbUser, $dbPass);
		$conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
	}

	catch(PDOException $e) 
	{
		echo 'Connection failed: ' . $e->getMessage();
		die();
	}
?>