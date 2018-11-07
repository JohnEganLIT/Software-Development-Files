html>
<head>
<title>MySQLi Ex2</title>
</head>
<body>
<h2>MySQLi Tutorial Examples - Example 2 - SELECT QUERY</h2>
<p>For MySQLi Manual click <a href="http://php.net/manual/en/book.mysqli.php">here</a>

<?php
//Define Connection Parameters
//
$DBServer = 'localhost'; // e.g 'localhost' or '192.168.1.100'
$DBUser   = 'root';
$DBPass   = '';
$DBName   = 'itschool';


//connect using object oriented method
$conn = new mysqli($DBServer, $DBUser, $DBPass, $DBName);  //-->mysqli::__construct — Open a new connection to the MySQL server

// check connection
//
if ($conn->connect_error) {   //--->mysqli::$connect_errno — Returns the error code from last connect call
	echo "<p>Database connection failed: $conn->connect_error, E_USER_ERROR";
	exit("<p>PHP script terminated");
  //trigger_error('Database connection failed: '  . $conn->connect_error, E_USER_ERROR);   //--->mysqli::$connect_error — Returns a string description of the last connect error
}



//==============================================================================//
//SELECT Query
echo "<hr>";
echo '<h3>Execute a SELECT Query</h3>';

//Query string
$sql1='SELECT * FROM studentsx';
 

 

//execute the query 
//trigger exception in a "try" block
try {
  $rs=$conn->query($sql1);
  //$rs is the result set 
  //$rs=$conn->query($sql1);  
  //--->mysqli::query — Performs a query on the database - Data inside the query should be properly escaped.
  //If the exception is thrown, this text will not be shown
  echo '<p>Query Executed';
}
//catch exception
catch(Exception $e) {
  echo 'Message: ' .$e->getMessage();
  exit("<p>PHP script terminated");
}

//check that there is a valid result set 
if($rs === false) {
  echo 'Wrong SQL: ' . $sql . ' Error: ' . $conn->error;
  exit("<p>PHP script terminated");
} else {
  $arr = $rs->fetch_all(MYSQLI_ASSOC);  //put the result into an array
}

echo "<h3>Resultset properties:</h3>";
echo "<p>Rows Returned=$rs->num_rows<br>";
echo "Current Field Pointer=$rs->current_field<br>";
echo "Number of Fields=$rs->field_count<br>";
echo "<br>";


echo '<h3>Iterate Through Result Array</h3>';
// iterate through the result ARRAY using foreach()
echo 'Iterate through the resultset using foreach()<br>';
foreach($arr as $row) {
    echo $row['StudentID'].' : ';
    echo $row['FirstName'] . '  ';
    echo $row['LastName'] . '<br>';
}
echo "<br>";

echo '<h3>Iterate Through RESULTSET</h3>';
//iterate through the RESULTSET using fetch_assoc() function
$rs->data_seek(5);  //set data_seek pointer to the fifth record
echo 'Iterate through the resultset using fetch_assoc() and data_seek()<br>';
while($row = $rs->fetch_assoc()){
    echo $row['StudentID'].' : ';
    echo $row['FirstName'] . '  ';
    echo $row['LastName'] . '<br>';
}

//close the connection
$conn->close();
?>


</body>
</html>







