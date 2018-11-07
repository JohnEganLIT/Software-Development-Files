<html>
<head>
<title>PHP_arrays</title>
</head>
<body>

<h1>Arrays</h1>

<?php

//create sample arrays:
$books = array(
    1 => "War and Peace",
    2 => "Macbeth"
	);

$cars = array("Volvo", "BMW", "Toyota");

$person1 = array (
	"Firstname"=>"John",
	"Lastname"=>"Smith"
	);
$person2 = array (
	"Firstname"=>"Katie",
	"Lastname"=>"Jones"
	);
//multidimensional array
$people = array($person1,$person2);
	
//use the arrays
echo '<h3>Use the key to access a value:</h3>';
echo '<p>Get a value from an INDEXED array:'.$cars[1].'</p>';
echo '<p>Get a value from an ASSOCIATIVE array:'.$person1["Lastname"];
echo '<p>Get a value from a MULTI DIMENSIONAL ASSOCIATIVE array:'.$people[1]["Lastname"];

echo '<h3>print_r - array/object dump/count elements:</h3>';
print_r($books);
echo '<br>The number of elements in the array are :'.count($books);


echo '<h3>Handling multidimensional arrays:</h3>';
echo '<h4>Array Dump:</h4>';
var_dump($people);

echo '<h4>Using for loop to iterate through a multidimensional array:</h4>';
for($row=0;$row<(count($people));$row++){	
	echo $people[$row]["Firstname"].' '.$people[$row]["Lastname"].'<br>';
}

?>

</body>
</html> 
