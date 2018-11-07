<?php
//helper functions

function getTableData($connection,$sql)
{
	try {
		$rs=$connection->query($sql);
		return $rs;
	}
	//catch exception
	catch(Exception $e) {
		if (__DEBUG==1) 
			{ 
			echo 'Message: ' .$e->getMessage();
			exit('<p class="warning">PHP script terminated');
			}
		else
			{	
			header("Location:".__USER_ERROR_PAGE);
			}
	}
}

function checkResultSet($rs)
	{
	if($rs === false) {
		if (__DEBUG==1)
		{
		echo 'Wrong SQL: ' . $sql . ' Error: ' . $conn->error;
		exit('<p class="warning">PHP script terminated');
		}
		else
			{	
			header("Location:".__USER_ERROR_PAGE);
			}
	} else {
		$arr = $rs->fetch_all(MYSQLI_ASSOC);  //put the result into an array
		return $arr;
	}
}

function generateTable($tableName, $titlesResultSet, $dataResultSet)
{
	//use resultsets to generate HTML tables

	echo "<table border=1>";

	//first - create the table caption and headings
	echo "<caption>".strtoupper($tableName)." TABLE - QUERY RESULT</caption>";
	echo '<tr>';
	foreach($titlesResultSet as $fieldName) {
		echo '<th>'.$fieldName['Field'].'</th>';
	}
	echo '</tr>';

	//then show the data
	foreach($dataResultSet as $row) {
		echo '<tr>';
		foreach($titlesResultSet as $fieldName) {
			echo '<td>'.$row[$fieldName['Field']].'</td>';}
		echo '</tr>';
		}
	echo "</table>";
}
?>
