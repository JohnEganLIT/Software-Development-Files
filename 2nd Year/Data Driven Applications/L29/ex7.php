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
$DBServer = 'localhost'; // e.g 'localhost' 
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
<?php 
//includes
include("CONFIG/connection.php");  //include the database connection 
include("LIBRARY/helperFunctionsTables.php");  //include the database connection 
include("CONFIG/config.php");  //include the application configuration settings
?>


<html>
<head>
<title>MySQLi</title>
<link rel="stylesheet" type="text/css" href="CSS/mystyle.css">
</head>
<body>
<h2>MySQLi Tutorial Examples - Example 7 - Getting user input</h2>

<?php

//warn DEBUG  mode is on
if (__DEBUG==1) {echo 'Debug mode is ON<br>';};

//this is the code that process the data entered in the form
if(isset($_POST['send']))  //if the form has been submitted previously
{
	
	//==============================================================================//
	//SELECT Query




	//Query string
	$table=$_POST['tableName'];  //get the table name from the form
	$sqlData="SELECT * FROM $table";  //get the data from the table
	$sqlTitles="SHOW COLUMNS FROM $table";  //get the table column descriptions

	//execute the 2 queries
	$rsData=getTableData($conn,$sqlData);
	$rsTitles=getTableData($conn,$sqlTitles);

	//check the results
	$arrayData=checkResultSet($rsData);
	$arrayTitles=checkResultSet($rsTitles);

	//use resultsets to generate HTML tables
	generateTable($table, $arrayTitles, $arrayData);

	//close the connection
	$conn->close();
	
	include 'FORMS/reloadForm.txt';

}
else 
{
	include 'FORMS/selectTableForm.txt';
}

?>

</body>
</html>















