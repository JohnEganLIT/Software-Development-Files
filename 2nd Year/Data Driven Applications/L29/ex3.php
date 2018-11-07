<html>
<head>
<title>MySQLi Ex3</title>
</head>
<body>
<h2>MySQLi Tutorial Examples - Example 3 - USING RESULTSET PROPERTIES</h2>
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
$sql1='SELECT * FROM modules';
 
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
echo "Number of Fields/columns=$rs->field_count<br>";
echo "<br>";


echo '<h3>Use the  RESULTSET properties.. to display the field length of the data in each field</h3>';
$row=-1;  //note starting negative row counter
$numCols=$rs->field_count;
$numRows=$rs->num_rows;
echo "<table border=5>";
while ($row<0)  //this while loop constructs the first row of column headings
	{
		$col=0;
		echo "<tr><td></td>"; //blank cell 
			while ($col<$numCols)
				{
				echo "<td>Column $col Data</td>";
				echo "<td>Column $col Length</td>";
				$col++;
				}
		echo "</tr>";
		$row++;
	}

while ($row<$numRows)  //this while loop constructs a row for every row in the resultset
	{
		$rs->data_seek($row); 
		$col=0;
		$rowData = $rs->fetch_row();
		echo "<tr><td>Row Nr: $row </td>";  //column to label each row
			while ($col<$numCols)
				{
				echo "<td>$rowData[$col]</td>";
				echo "<td>".$rs->lengths[$col]."</td>";
				$col++;
				}
		echo "</tr>";
		$row++;
	}
echo "</table>";
	

//close the connection
$conn->close();
?>


</body>
</html>








