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
<h2>MySQLi Tutorial Examples - Example 11 - Password Encryption</h2>
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
		//HASHING the PASSWORD
		
		//this hashing function is available in PHP 5.5 + only
		//$options = ['cost' => 12,];
		//echo password_hash("datadrivenapplications", PASSWORD_BCRYPT, $options)."\n";
		//$passEncrypt=password_hash($pass1,PASSWORD_DEFAULT);  
		//see PHP manual  http://php.net/manual/en/function.password-hash.php

		//this hashing method works in PHP 5.1.2. +
		//the first parameter is the hash algorithm
		$passEncrypt= hash('ripemd160', $pass1);  //this algorithm requires 40 chars field length
		
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
	


	
	echo '<h4>New record added successfully</h4>';
	$buttonText="Add another Lecturer";
	include 'FORMS/buttonWithText.html';

}
else 
{
	// display the user registration form
	//include 'FORMS/newUserForm.txt';  //without validation
	include 'FORMS/newUserFormValidated.html'; //with validation


}

echo "</section>";


//----------------RHS SECTION-----------------------------//
//========================================================//
echo '<section class="right">';
echo '<h3>Notes:</h3>';
echo '<p>New user setup form:</p>';
echo '<p>Gets user input from form using $_POST</p>';
echo '<p>Escapes the user input</p>';
echo '<p>Encrypts the user password</p>';
echo '<p>Inserts data into data table</p>';
echo '<p>Displays inserted record</p>';


echo '</section>';



//----------------FOOTER section--------------------------//
//========================================================//

//warn DEBUG  mode is on
if (__DEBUG==1) 
	{	
		echo '<footer class="debug">';
	echo 'Debug mode is ON';
	echo "<p>insert SQL= $sqlInsert";
	
	echo '<h4>New record added:</h4>';
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
	
	
	echo "</footer>";

	}
	else
	{
	echo '<footer class="copyright">';
	echo 'Copyright 2016 Gerry Guinane';
	echo "</footer>";
	}

	
	if (__DEBUG==1) {

	} //end debug info

?>

</body>
</html>
















 




