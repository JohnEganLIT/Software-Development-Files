<html>
<head>
<title>MySQLi Ex1</title>
</head>
<body>
<h2>MySQLi Tutorial Examples - Example 1</h2>
<p>For MySQLi Manual click <a href="http://php.net/manual/en/book.mysqli.php">here</a>

<?php
echo "<hr>";
echo '<h3>Connect to a DB (Object Oriented)</h3>';
//Define Connection Parameters
//
$DBServer = '127.0.0.1'; // e.g 'localhost' 
$DBUser   = 'root';  //username
$DBPass   = '';  //password
$DBName   = 'itschool';  //database name

//connect using object oriented method

$conn = new mysqli($DBServer, $DBUser, $DBPass, $DBName);  //-->mysqli::__construct — Open a new connection to the MySQL server

// check connection
//
if ($conn->connect_error) {   //--->mysqli::$connect_errno — Returns the error code from last connect call
	echo "<p>Database connection failed: $conn->connect_error";
	exit("<p>PHP script terminated");
}

//display connection parameters
echo '<p>MySQL Server Connection information :<br>';
echo "Client connection info  string :  $conn->client_info <br>";
echo "Server Version   [as decimal release]:  $conn->server_info <br>";
echo "Server Version  [as integer] :  $conn->server_version <br>";
echo "Server Character Set :  $conn->character_set_name() <br>";
echo "Host info :  $conn->host_info() <br>";

echo '<h3>Close the connection</h3>';
//close the connection
$conn->close();
?>
</body>
</html>







