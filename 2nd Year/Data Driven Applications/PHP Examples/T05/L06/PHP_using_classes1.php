<?php include("classlib/Person.php"); //include the class library ?>
<html>
<head>
<title>PHP_using_classes</title>
</head>

<body>
<h1>PHP Using Classes</h1>

<?php 
// Create an object:
$person1 = new Person("John Muldoon","12-June-1981");
$person2 = new Person("Keiran Marmion","15-Feb-1990");
$person3 = new Person("Jack Carty","17-Jan-1991");

//put the objects into an array
$group=array($person1,$person2,$person3);

//use the object
echo "<h3>Use the objects</h3>";
echo "Person1's OLD name: " . $person1->get_name()."<br/>";
$person1->set_name("Ali Muldowney");
echo "Person1's NEW name: " . $person1->get_name()."<br/>";

//this wont work if the property is not public - so its commented out
//echo "Try to access the object property directly: ".$person1->name;  


//use the array of objects:
echo "<h3>Use print_r() function to dump the ARRAY of objects</h3>";
print_r($group);
echo "<br>";

echo "<h3>Iterate through the ARRAY of objects</h3>";

foreach ($group as $person){
	//print_r($person);
	echo $person->get_name()."   ".$person->get_dob()."<br>";
}



?>

</body>
</html>
