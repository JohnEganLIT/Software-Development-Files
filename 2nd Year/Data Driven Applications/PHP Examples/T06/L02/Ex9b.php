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
<h2>MySQLi Tutorial Examples - Example 9b - INSERT Query</h2>
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
	$table='lecturer';  //table to insert values into
	


	
	//INSERT QUERY

	
	//get the values entered in the form
	$lectID=$conn->real_escape_string($_POST['lectID']);
	$lectFirstName=$conn->real_escape_string($_POST['lectFirstName']);
	$lectLastName=$conn->real_escape_string($_POST['lectLastName']);
	$pass1=$conn->real_escape_string($_POST['lectPass1']);
	$pass2=$conn->real_escape_string($_POST['lectPass2']);
	
	if ($pass1===$pass2)
	{
		$sqlInsert= "INSERT INTO $table (LectID,FirstName,LastName,password) VALUES('$lectID','$lectFirstName','$lectLastName','$pass1')";
		if(queryInsert($conn,$sqlInsert)==1) //execute the INSERT query
		{ 
		echo "<h3>New data inserted successfully</h3>";
		}
		else
		{
		echo "<h3>New data has not been inserted - a record for this ID already exists</h3>";
		}
		
	}
	else
	{ 
		echo "<p>Passwords dont match - data not entered";
	}
	

	//SELECT Query

	//Query string
	
	$sqlData="SELECT * FROM $table WHERE LectID='$lectID'";  //get the data from the table
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
	
	$buttonText="Add another Lecturer";
	include 'FORMS/buttonWithText.html';

}
else 
{
	// display the new user registration form
	include 'FORMS/newUserForm.html'; 


}

echo "</section>";


//----------------RHS SECTION-----------------------------//
//========================================================//
echo '<section class="right">';
echo '<h3>Notes:</h3>';
echo '<p>New user setup form:</p>';
echo '<p>Gets user input from form using $_POST</p>';
echo '<p>Escapes the user input</p>';
echo '<p>Inserts data into data table</p>';
echo '<p>Displays inserted record</p>';echo '</section>';



//----------------FOOTER section--------------------------//
//========================================================//

//warn DEBUG  mode is on
if (__DEBUG==1) 
	{	
		echo '<footer class="debug">';
	echo 'Debug mode is ON';
	echo "<p>insert SQL= $sqlInsert";
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
















 



