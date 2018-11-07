<?php
//includes
include("CONFIG/connection.php");  //include the database connection 
?>

<html>
<head>
<title>MySQLi Ex4</title>
</head>
<body>
<h2>MySQLi Tutorial Examples - Example 4 - USING Include()</h2>
<p>For MySQLi Manual click <a href="http://php.net/manual/en/book.mysqli.php">here</a>

<?php

//==============================================================================//
//SELECT Query
echo "<hr>";
echo '<h3>Execute a SELECT Query</h3>';

//Query string
$sql1='SELECT * FROM students';

//execute the query 
//trigger exception in a "try" block
try {
  $rs=$conn->query($sql1);
  //$rs is the result set 
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

//close the connection
$conn->close();
?>


</body>
</html>
















 



