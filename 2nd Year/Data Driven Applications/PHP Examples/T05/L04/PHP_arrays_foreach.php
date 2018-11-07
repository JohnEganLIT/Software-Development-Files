<html>
<head>
<title>PHP_arrays_foreach</title>
</head>
<body>

<h1>Iterating Through Arrays</h1>

<?php

//create sample arrays:
$books = array(
    1 => "War and Peace",
    2 => "Macbeth"
	);

$person1 = array (
	"Firstname"=>"John",
	"Lastname"=>"Smith"
	);
$person2 = array (
	"Firstname"=>"Katie",
	"Lastname"=>"Jones"
	);
//multidimensional array
$people = array("Member1"=>$person1,"Member2"=>$person2);
	

echo '<h3>Using foreach:</h3>';
foreach ($books as $value) {
	echo '<p>'.$value.'</p>';
}

echo '<h4>Using foreach with multidimensional arrays:</h4>';
foreach ($people as $key=>$value){
	//value is an associative array
	echo $value["Lastname"].','.$value["Firstname"].'<br>';
	}

echo '<h4>Using foreach with multidimensional arrays to generate a TABLE:</h4>';
echo '<table border="1">';
echo '<tr><th>Member Nr.</th><th>Lastname</th><th>Firstname</th></tr>';
foreach ($people as $key=>$value){
	//$value is an associative array representing a row of data
	echo '<tr><td>'.$key.'</td><td>'.$value["Lastname"].'</td><td>'.$value["Firstname"].'</td></tr>';
	}
echo '</table>';

?>

</body>
</html> 
