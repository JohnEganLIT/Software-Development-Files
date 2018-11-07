<?php include("classlib/Person.php"); //include the person class library ?>
<?php include("classlib/Employee.php"); //include the employee class library ?>
<html>
<head>
<title>PHP_using_classes2</title>
</head>

<body>
<h1>PHP Classes - Inheritance</h1>

<?php 
//Create Objects 
$person1 = new Person("John Muldoon","12-June-1981");
$person2 = new Person("Keiran Marmion","15-Feb-1990");
$employee1 = new Employee("Pat Lam","2716253AB",1122,"17-June-1971");

echo "Person1's full name: " . $person1->get_name()."<br>";
echo "Employee1's full name: " . $employee1->get_name()."<br>";
echo "Employee1's PPSN: " . $employee1->get_ppsn()."<br>";

//check the employees PIN number
if($employee1->verify_pin(1122)){
echo "Employee's PIN check:OK <br>";
}
else {
echo "Employee's PIN check:FAIL <br>";
}

?>
</body>
</html>
