<?php
	$dbServer = "localhost";
	$dbUser = "root";
	$dbPass = "";
	$dbName = "k00186813db";
	
	$dbhandle = mysql_connect($dbServer, $dbUser, $dbPass) or die("Unable to connect to MySQL");
	
	$selected = mysql_select_db($dbName, $dbhandle) or die("Could not select $dbName database.");
?>