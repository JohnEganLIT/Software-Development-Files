<html>
<head>
<title>PHP_form1_processing</title>
</head>
<body>

<h1>Form 1 Processing</h1>

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
	echo "<a href=PHP_form1.php>Go back</a>";
}
?>

</body>
</html> 
