<?php 
//includes
include("CONFIG/connection.php");  //include the database connection 
include("LIBRARY/helperFunctionsTables.php");  //include the database connection 
require_once("CONFIG/config.php");  //include the application configuration settings
?>

<html>
<head>
<title>MySQLi</title>
<link rel="stylesheet" type="text/css" href="<?php echo __CSS;?>">
</head>
<body>
<!----------------- HEADER SECTION ----------------------->
<!--====================================================-->
<header>
<h2>MySQLi Tutorial Examples - Example 8 - Dynamically creating a form</h2>
</header>
<?php

//----------------NAVIGATION SECTION----------------------//
//========================================================//
include("PAGE_CONTENT/navigation.php"); 

//----------------MAIN SECTION----------------------------//
//========================================================//
echo "<section>";

if(isset($_POST['send']))  //if the form has been submitted previously
{
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
	//dynamically create a form by getting table names from the database.
	
	//setup a query to get the table names from the current database
	$sqlGetTableDescriptions="SHOW TABLES";  //Query to get a list of tables from the current database
	$rsTableDescriptions=getTableData($conn,$sqlGetTableDescriptions);  //resultset from the query
	$arrayTableDescriptions=checkResultSet($rsTableDescriptions); //checked and put in to an associative array

	
	
	//iterate through the results array to dynamically create the form with a drop down menu
	$indexString='Tables_in_'.$DBName;  //this index is used in the resultset array
	echo '<form method="post"  class="getinput" name="tableSelect" action="'.$_SERVER['PHP_SELF'].'">';
	echo '<div>';
	echo '<h2>Select Table Form</h2>';
	echo '<table >';
	echo '<tr><td><label><span>Select a table to display </span>';
	echo '<select name="tableName">';
	foreach($arrayTableDescriptions as $row) 
		{
		echo '<option value="'.$row[$indexString].'">'.$row[$indexString].'</option>';  //this is where the index string gets used
		}
	echo '</select>';
	echo '</label></td></tr>';
	echo '<tr><td>';
	echo '<label>';
	echo '<span>Hit Enter to display table</span>';
	echo '<input name="send" type="submit" id="sendButton" value="Enter">';
	echo '</label>';
	echo '</td></tr>';
	echo '</table>';
	echo '</div>';
	echo '</form>';

	
	$conn->close();
}

echo "</section>";


//----------------RHS SECTION-----------------------------//
//========================================================//
echo '<section class="right">';
echo '<h3>Notes:</h3>';
echo '<p>The problem with Example 7 is that it relies on the user entering the correct table name
This example dynamically creates a form with tablenames from the database for the user to choose. </p>';
echo '<p>This example also makes greater use of CSS to lay out the page into five distinct sections HEADER, FOOTER, NAV, RH SECTION and MAIN SECTION.</p>';
echo '</section>';



//----------------FOOTER section--------------------------//
//========================================================//

//warn DEBUG  mode is on
if (__DEBUG==1) 
	{	
	echo '<footer class="debug">';
	echo '<hr><h3>Debug Information</h3>';
	echo 'Database Selected ='. $DBName.'<br>';
	echo '$indexString='.$indexString.'<br>';
	echo '<p>Table Selected ='. $table.'<br>';
	echo '<h4>$arrayTableDescriptions:</h4>';
	print_r($arrayTableDescriptions);
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
















 




