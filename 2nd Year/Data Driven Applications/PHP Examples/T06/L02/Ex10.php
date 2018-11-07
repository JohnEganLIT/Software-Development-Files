<?php 
//includes
include("CONFIG/connection.php");  //include the database connection 
include("LIBRARY/helperFunctionsTables.php");  //include the database connection 
include("CONFIG/config.php");  //include the application configuration settings
?>

<html>
<head>
<title>Simple Database Query Form</title>
</head>

<body>
<h2>Data Entry Form</h2>

<form method="post" action="<?php echo $_SERVER['PHP_SELF'];?>">
  Enter Student ID Number : 
  <input name="Student_ID" type="text" id="ID">
  <br>  <br>
  Enter Student First Name :
  <input name="Student_firstname" type="text" id="firstname">
  <br>  <br>
  Enter Student Last Name :
  <input name="Student_lastname" type="text" id="lastname">  <br>  <br>
  <input name="send" type="submit" id="submit" value="Submit Data">
</form><hr>

<hr>

<h2>Query Result</h2><br><br>
<?php
if(isset($_POST['send']))  //check the form has been submitted
{

	//Define the SQL query to be executed
	$student_ID = $_POST['Student_ID'];
	$student_firstname = $_POST['Student_firstname'];
	$student_lastname = $_POST['Student_lastname'];

	//Set up the query string, note the use of single quotes around STRING values
	$insertSQL="INSERT INTO students (StudentID,FirstName,LastName) VALUES('$student_ID','$student_firstname','$student_lastname')";
	
	//this code could be made into a helper function
	try {
		if($conn->query($insertSQL)){
		echo "Data Record Inserted Successfully <br>";
		echo 	'<b>Please enter a new user details in the form above.</b><br>';
		}
	}
	//catch exception
	catch(Exception $e) {
		if (__DEBUG==1) 
			{
			//DEBUG mode is enabled
			echo '<hr><h2>Debug Information:</h2>';
			echo '<h4>Error message $e:</h4>';
			echo 'Message: ' .$e->getMessage();
			exit('<p class="warning">PHP script terminated');		
			}
		else
			{
			//DEBUG mode is disabled
			header("Location:".__USER_ERROR_PAGE);
			}
	}

}
else 	//The form has not been submitted
{
	echo 	'<b>Please enter a new user details in the form above.</b>';
} //END IF isset($_POST['send'])


//DEBUG info
if (__DEBUG==1) 
	{	
	echo '<footer class="debug">';
	echo '<hr><h3>Debug Information</h3>';
	echo 'Database Selected ='. $DBName.'<br>';
	echo 'SQL='.$insertSQL.'<br>';
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

<hr>
</body>
</html>

















 




