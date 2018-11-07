<html>
<head>
<title>PHP_form2_self_processing</title>
</head>
<body>

<h1>Form 2 Self Processing</h1>

<form action="<?php echo $_SERVER["PHP_SELF"];?>" method="post">
Enter a value: <input type="text" name="value1"><br>
Enter a value: <input type="text" name="value2"><br>
<input type="submit" name="data_submitted">
</form>
<hr>

<?php
//define the functions
function sum($x, $y) {
    $z = $x + $y;
    return $z;
}
?>

<?php
if (isset($_POST['data_submitted'])){  //check that the form has been submitted
	echo 'The SUM of '.$_POST['value1'];
	echo ' and '.$_POST['value2'];
	echo ' is = '.sum($_POST['value1'],$_POST['value2']);
}
else //the form has not been submitted
{
	echo "<p>Please enter some values in the form.</p>";
}
?>

</body>
</html> 
