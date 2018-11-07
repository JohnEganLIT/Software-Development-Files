<?php
	//Sets up database
	$dbHost = 'localhost';
	$dbName = 'projectdb';
	$dbUser = 'sec_user';
	$dbPass = '2gjNqZBcDt';

	try{
		$conn = new PDO('mysql:host=' . $dbHost . ';dbname=' . $dbName, $dbUser, $dbPass);
	}

	catch(PDOException $e) 
	{
		echo 'Connection failed: ' . $e->getMessage();
	}
?>