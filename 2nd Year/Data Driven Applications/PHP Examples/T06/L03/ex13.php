<?php 
//includes
include("CONFIG/connection.php");  //include the database connection 
include("LIBRARY/helperFunctionsTables.php");  //include the database connection 
include("LIBRARY/helperFunctionsDatabase.php");  //include the database connection 
require_once("CONFIG/config.php");  //include the application configuration settings
?>

<META HTTP-EQUIV="Content-Type" CONTENT="text/html;" charset="UTF-8">
<html>
<head>
<title>MySQLi</title>
<link rel="stylesheet" type="text/css" href="<?php echo __CSS;?>">
</head>
<body>
<!----------------- HEADER SECTION ----------------------->
<!--====================================================-->
<header>
<h2>MySQLi Tutorial Examples - Example 13 - DELECT RECORD Query</h2>
</header>
<?php

//----------------NAVIGATION SECTION----------------------//
//========================================================//
include("PAGE_CONTENT/navigation.php");  

//----------------MAIN SECTION----------------------------//
//========================================================//
echo "<section class='wide'>";
$table='lecturer';  //table to delete records from
$PK="LectID";  //Specify the PK of the table

if(isset($_POST['delrecord']))  //if the form has been submitted 
{
	//DELETE query
	$selectedID=$_POST['delrecord'];  //get the ID of the record we want to delete from the form
	$sqlDel="DELETE FROM $table WHERE $PK='$selectedID'";  //create the SQL
	
	if (deleteRecord($conn,$sqlDel))  //call the deleteRecord() function
	{
	echo "<h3>RECORD WITH PK=$selectedID DELETED</h3>";
	}
	else
	{
	echo "<h3 >RECORD WITH PK=$selectedID CANNOT BE DELETED</h3>";
	}
	
	//Re-display table with delete options
	//Query string
	$sqlData="SELECT * FROM $table";  //get the data from the table
	$sqlTitles="SHOW COLUMNS FROM $table";  //get the table column descriptions

	//execute the 2 queries
	$rsData=getTableData($conn,$sqlData);
	$rsTitles=getTableData($conn,$sqlTitles);

	//check the results
	$arrayData=checkResultSet($rsData);
	$arrayTitles=checkResultSet($rsTitles);

	//use resultsets to generate HTML tables with DELETE button
	generateDeleteTable($table, $PK, $arrayTitles, $arrayData);

	//close the connection
	$conn->close();
}
else //this is the first time the form is loaded
{
	//display table with delete options
	//Query string
	
	$sqlData="SELECT * FROM $table";  //get the data from the table
	$sqlTitles="SHOW COLUMNS FROM $table";  //get the table column descriptions


	//execute the 2 queries
	$rsData=getTableData($conn,$sqlData);
	$rsTitles=getTableData($conn,$sqlTitles);

	//check the results
	$arrayData=checkResultSet($rsData);
	$arrayTitles=checkResultSet($rsTitles);

	//use resultsets to generate HTML tables with DELETE button
	generateDeleteTable($table, $PK, $arrayTitles, $arrayData);

	//close the connection
	$conn->close();
}

echo "</section>";

//----------------FOOTER section--------------------------//
//========================================================//

//warn DEBUG  mode is on
if (__DEBUG==1) 
	{	
		echo '<footer class="debug">';
	echo 'Debug mode is ON<br>';
	echo "SqL = $sqlDel";
	echo "</footer>";

	}
	else
	{
	echo '<footer class="copyright">';
	echo 'Copyright 2016 Gerry Guinane';
	echo "</footer>";
	}


?>

</body>
</html>
















 



