<?php include("classlib/Person.php"); //include the class library ?>
<html>
<head>
<title>PHP_using_classes4</title>
</head>

<body>
<h1>PHP Retrieving Persistent Object properties</h1>

<?php 
echo "<h3>Reconstruct Objects from a CSV data file</h3>";
$group=array();  //empty array to contain person objects
$dataFile = fopen("persistence/person_data.csv", "r") or die("Unable to open file!");
$i=0;  //index for the array
while(!feof($dataFile)) {
  $csv=fgets($dataFile); //read a line from the CSV file
  if(!feof($dataFile)){ //make sure not at end
	  $personProperties=explode(",",$csv); //parse values to an array
	  $group[$i]=new Person($personProperties[0],$personProperties[1]);//create new person objects
	  $i++;
  }
}
fclose($dataFile); //close the data file

//dump the array of Person objects
print_r($group);
?>

</body>
</html>
