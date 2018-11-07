<?php 
//includes
include("CONFIG/connection.php");  //include the database connection 
include("LIBRARY/helperFunctionsTables.php");  //include the database connection 
require_once("CONFIG/config.php");  //include the application configuration settings
?>

<html>
<head>
<title>Simple Database Query Form</title>
<link rel="stylesheet" type="text/css" href="<?php echo __CSS;?>">
</head>

<!----------------- HEADER SECTION ----------------------->
<!--====================================================-->
<header>
<h2>MySQLi Tutorial Examples - Example 9a - Simple Database Query Form</h2>
</header>

<?php
//----------------NAVIGATION SECTION----------------------//
//========================================================//
include("PAGE_CONTENT/navigation.php"); 
?>

<body>

<!-- Main Section -->
<section>
<h2>Database Query Form</h2>
<p>Please enter your request in the following form:</p>
<form method="post" action="<?php echo $_SERVER['PHP_SELF'];?>">
  Enter Student ID Number : 
  <input name="Student_ID" type="text" id="ID_nr"><br><br>
  <input name="send" type="submit" id="send" value="Execute Query">
</form>
<hr>

<h2>Database Query Result</h2><br><br>
<?php
if(isset($_POST['send']))  //check the form has been submitted
{
	$criteria = $_POST['Student_ID']; //Get the select criteria from the FORM
	$table='students';
	if ($criteria!=NULL)  //check that a value has been entered for ID
	{

		$sqlData="SELECT * FROM $table where StudentID='$criteria'";  //set up the query
		$sqlTitles="SHOW COLUMNS FROM $table";  //query to get the table column descriptions

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
	}
	else //No selection criteria has been entered
	{
		echo "<br> Please enter a valid student ID<br>";
	}  //end IF $criteria!=NULL
}
else 	//The form has not been submitted
{
	echo 	'<b>Please enter a valid user ID in the form above.</b>';
} //END IF isset($_POST['send'])

echo '</section>';


//-----------Footer section

if (__DEBUG==1) 
	{	
	echo '<footer class="debug">';
	echo '<hr><h3>Debug Information</h3>';
	echo 'Database Selected ='. $DBName.'<br>';
	echo 'Criteria ='. $criteria.'<br>';
	echo 'SQL='.$sqlData.'<br>';
	echo "</footer>";

	}
	else
	{
	echo '<footer class="copyright">';
	echo '<hr>';
	echo 'Copyright 2016 Gerry Guinane';
	echo "</footer>";
	}
?>
</body>
</html>

















 




