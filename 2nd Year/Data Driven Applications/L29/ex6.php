<?php 
//includes
include("CONFIG/connection.php");  //include the database connection 
include("LIBRARY/helperFunctionsTables.php");  //include the database connection 
include("CONFIG/config.php");  //include the application configuration settings
?>

<html>
<head>
<title>MySQLi Ex6</title>
<link rel="stylesheet" type="text/css" href="CSS/mystyle.css">
</head>
<body>
<h2>MySQLi Tutorial Examples - Example 6 - Using Include to simplify script</h2>

<?php

//SELECT Query
echo "<hr>";

//warn DEBUG  mode is on
if (__DEBUG==1) {echo 'Debug mode is ON<br>';};

//Query string
$table='students';
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


?>


</body>
</html>














