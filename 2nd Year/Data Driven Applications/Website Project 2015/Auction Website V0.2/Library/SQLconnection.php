<?php
	$dbHost = 'localhost';
	$dbName = 'projectdb';
	$dbUser = 'root';
	$dbPass = '';

	try{
		$conn = new PDO('mysql:host=' . $dbHost . ';dbname=' . $dbName, $dbUser, $dbPass);
	}

	catch(PDOException $e) 
	{
		echo 'Connection failed: ' . $e->getMessage();
	}
?>