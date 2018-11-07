<?php 
//includes
include("CONFIG/connection.php");  //include the database connection 
include("LIBRARY/helperFunctionsTables.php");  //include the database connection 
require_once("CONFIG/config.php");  //include the application configuration settings
?>


<html>
<head>
<title>MySQLi</title>
<link rel="stylesheet" type="text/css" href="CSS/mystyle.css">
</head>
<body>
<h2>MySQLi Tutorial Examples - Example 7 - Getting user input</h2>

<?php



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
	
	include 'FORMS/reloadForm.html';

}
else 
{
	include 'FORMS/selectTableForm.html';
}

//if DEBUG  mode is on - process some debug code here
if (__DEBUG==1) {
	echo '<hr><h2>Debug Information:</h2>';
	echo '<h4>Post Array:</h4>';
	print_r($_POST);
	echo '<h4>SQL:</h4>';
	echo '$sqlData string:'.$sqlData.'<br>';
	echo '$sqlTitles string:'.$sqlTitles.'<br>';
	echo '<h4>Titles Array:</h4>';
	print_r($arrayTitles);
	echo '<h4>Data Array:</h4>';
	print_r($arrayData);
	
	};

?>

</body>
</html>
















 




