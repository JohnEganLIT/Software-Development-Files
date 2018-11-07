<?php include("classlib/Person.php"); //include the class library ?>
<html>
<head>
<title>PHP_using_classes3</title>
</head>

<body>
<h1>PHP Persisting Object properties</h1>

<?php 
// Create objects:
$person1 = new Person("John Muldoon","12-June-1981");
$person2 = new Person("Keiran Marmion","15-Feb-1990");
$person3 = new Person("Jack Carty","17-Jan-1991");

//put the objects into an array
$group=array($person1,$person2,$person3);

echo "<h3>Create a CSV string containing all of the objects' properties</h3>";
$csv="";//an empty CSV string
foreach ($group as $person){
	//get the properties of each object , put into CSV
	$csv.=$person->get_name().",".$person->get_dob()."\n";
}
echo $csv;

echo "<h3>Persist the object properties to a CSV file</h3>";
$dataFile = fopen("persistence/person_data.csv", "w") or die("Unable to open file!");
fwrite($dataFile, $csv);
fclose($dataFile);

?>

</body>
</html>
