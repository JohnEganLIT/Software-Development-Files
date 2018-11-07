<?php
//includes
include("CONFIG/connection.php");  //include the database connection 
?>

<html>
<head>
<title>Exercise</title>
<link rel="stylesheet" type="text/css" href="CSS/mystyle.css">
</head>
<body>

<form action"Exercise.php" method="post">
<select name="option">
  <option value="lecturer">Lecturer</option>
  <option value="modules">Modules</option>
  <option value="results">Results</option>
  <option value="students">Students</option>
</select>
<input type="submit"/>
</form>
<?php
//==============================================================================//
//SELECT Query
//if($_POST['submit'])
//{
	echo "<hr>";

	//Query string
	$table=$_POST['option'];
	$sql1="SELECT * FROM $table";  //get the data from the table
	$sql2="SHOW COLUMNS FROM $table";  //get the table column descriptions

	//execute the 2 queries

	try {
	  $rs1=$conn->query($sql1);
	}
	//catch exception
	catch(Exception $e) {
	  echo 'Message: ' .$e->getMessage();
	  exit("<p>PHP script terminated");
	}

	try {
	  $rs2=$conn->query($sql2);
	}
	//catch exception
	catch(Exception $e) {
	  echo 'Message: ' .$e->getMessage();
	  exit("<p>PHP script terminated");
	}
	//check that there is a valid result set 
	if($rs1 === false) {
	  echo 'Wrong SQL: ' . $sql . ' Error: ' . $conn->error;
	  exit("<p>PHP script terminated");
	} else {
	  $arr1 = $rs1->fetch_all(MYSQLI_ASSOC);  //put the result into an array
	}

	if($rs2 === false) {
	  echo 'Wrong SQL: ' . $sql . ' Error: ' . $conn->error;
	  exit("<p>PHP script terminated");
	} else {
	  $arr2 = $rs2->fetch_all(MYSQLI_ASSOC);  //put the result into an array
	}

	//use the two resultsets to generate HTML tables
	echo "<table border=1>";
	//first - create the table caption and headings
	echo "<caption>".strtoupper($table)." TABLE - QUERY RESULT</caption>";
	echo '<tr>';
	foreach($arr2 as $row) {
		echo '<th>'.$row['Field'].'</th>';
	}
	echo '</tr>';
		//then show the data
		foreach($arr1 as $row) {
			echo '<tr>';
			foreach($arr2 as $fieldName) {
				echo '<td>'.$row[$fieldName['Field']].'</td>';}
			echo '</tr>';
			}
	echo "</table>";
	echo "<br>";

	//close the connection
	$conn->close();
//}
?>
</body>
</html>
















 



