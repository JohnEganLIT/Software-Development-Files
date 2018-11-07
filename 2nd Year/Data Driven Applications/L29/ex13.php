<?php 
//includes
include("CONFIG/connection.php");  //include the database connection 
include("LIBRARY/helperFunctionsTables.php");  //include the database connection 
include("LIBRARY/helperFunctionsDatabase.php");  //include the database connection 
include("CONFIG/config.php");  //include the application configuration settings
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
echo '<nav>';
echo "<h3>Navigation:</h3>";
echo '<a href="http://php.net/manual/en/book.mysqli.php">MySQLi Manual</a><br>';
echo '<a href="ex1.php">Example 1</a><br>';
echo '<a href="ex2.php">Example 2</a><br>';
echo '<a href="ex3.php">Example 3</a><br>';
echo '<a href="ex4.php">Example 4</a><br>';
echo '<a href="ex5.php">Example 5</a><br>';
echo '<a href="ex6.php">Example 6</a><br>';
echo '<a href="ex7.php">Example 7</a><br>';
echo '<a href="ex8.php">Example 8</a><br>';
echo '<a href="ex9.php">Example 9</a><br>';
echo '<a href="ex10.php">Example 10</a><br>';
echo '<a href="ex11.php">Example 11</a><br>';
echo '<a href="ex12.php">Example 12</a><br>';
echo '<a href="ex13.php">Example 13</a><br>';
echo "</nav>";

//----------------MAIN SECTION----------------------------//
//========================================================//
echo "<section>";
$table='lecturer';  //table to delete records from
$PK="LectID";  //Specify the PK of the table

if(isset($_POST['delrecord']))  //if the form has been submitted 
{

	
	//DELETE query
	$selectedID=$_POST['delrecord'];
	$sqlDel="DELETE FROM $table WHERE $PK='$selectedID'";
	
	if (deleteRecord($conn,$sqlDel)) 
	{
	echo "<h3>RECORD WITH PK=$selectedID DELETED</h3>";
	}
	else
	{
	echo "<h3 >RECORD WITH PK=$selectedID CANNOT BE DELETED</h3>";
	}
	
	
	
	
	//SELECT Query

	//Query string
	
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
	
	$buttonText="Delete another Lecturer";
	include 'FORMS/buttonWithText.txt';

}
else 
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

	//use resultsets to generate HTML tables
	generateDeleteTable($table, $PK, $arrayTitles, $arrayData);
	
	//echo "hello from ELSE";
	//print_r($arrayData);

	//close the connection
	$conn->close();

}

echo "</section>";


//----------------RHS SECTION-----------------------------//
//========================================================//
echo '<section class="right">';
echo '<h3>Notes:</h3>';
echo '<p>This page provides a DELETE button for record deletion. The button is dynamically generated to contain the PK of the selected record. </p>
<p>This is retrieved from the $_POST array to generate the DELETE SQL.</p>
<p> Note - not all records can be deleted as there is a FK relationship with the MODULES table</p>';
echo '</section>';



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
	echo 'Copyright 2015 Gerry Guinane';
	echo "</footer>";
	}


?>

</body>
</html>
















 




