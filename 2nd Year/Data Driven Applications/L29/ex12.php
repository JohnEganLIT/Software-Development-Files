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

<!--jQuery Library-->
<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>		
<script src="LIBRARY/JSCRIPT/pwStrengthScript.js"></script>	
		
</head>
<body>
<!----------------- HEADER SECTION ----------------------->
<!--====================================================-->
<header>
<h2>MySQLi Tutorial Examples - Example 12 - Password Encryption</h2>
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
echo "</nav>";

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
		//HASHING the PASSWORD
		
		//this hashing function is available in PHP 5.5 + only
		//$options = ['cost' => 12,];
		//echo password_hash("rasmuslerdorf", PASSWORD_BCRYPT, $options)."\n";
		//$passEncrypt=password_hash($pass1,PASSWORD_DEFAULT);  //see PHP manual  http://php.net/manual/en/function.password-hash.php

		//this hashing method works in PHP 5.1.2. +
		$passEncrypt= hash('ripemd160', $pass1);  //requires 40 chars field length
		
		$sqlInsert= "INSERT INTO $table (LectID,FirstName,LastName,password) VALUES('$lectID','$lectFirstName','$lectLastName','$passEncrypt')";

		
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
	include 'FORMS/buttonWithText.txt';

}
else 
{
	// display the user registration form
	//include 'FORMS/newUserForm.txt';  //without validation
	include 'FORMS/newUserFormValidatedStrength.txt'; //with validation


}

echo "</section>";


//----------------RHS SECTION-----------------------------//
//========================================================//
echo '<section class="right">';
echo '<h3>Notes:</h3>';
echo '<p>This example retrieves a set of values from a form (user registration) and creates an INSERT query to insert the values in the database. </p>';
echo 'It verifies that the values have been inserted correctly and displays the resulting table </p>';
echo '</section>';



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
















 




