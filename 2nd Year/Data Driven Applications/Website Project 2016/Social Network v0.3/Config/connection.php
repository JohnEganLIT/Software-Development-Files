<?php
$DBServer = 'localhost'; // e.g 'localhost' or '192.168.1.100'
$DBUser   = 'root';
$DBPass   = '';
$DBName   = 'socialnetwork';

$conn = new mysqli($DBServer, $DBUser, $DBPass, $DBName);

if($conn->connect_error)
{
	if(__DEBUG==1)
	{
		echo "<p>Database connection failed: $conn->connect_error</p>";
	}
	
	exit('<p>Error! Please contact an Administrator.</p>');
}
?>

