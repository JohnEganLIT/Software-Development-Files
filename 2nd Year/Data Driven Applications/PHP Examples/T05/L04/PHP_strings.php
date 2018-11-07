<html>
<head>
<title>PHP_strings</title>
</head>
<body>

<h1>Strings</h1>

<?php

echo '<h3>single/Double quotes and escape characters</h3>';
$fruit ='apples';
echo "Using double quotes - My favourite fruit is - $fruit <br>";
echo 'Using single quotes - My favourite fruit is -  $fruit <br>';
echo "Using escape character '\' to display special characters  \"$fruit\" <br>";


echo '<h3>String Concatenation</h3>';
$string1='Hello ';
$string2='World ';
echo 'Strings may be joined by the concatenation operator (.) '.$string1.$string2;

echo '<h3>String Operations</h3>';
$MyString='Hello World, Welcome to Data Driven Applications';
echo 'Print the first 5 characters: <em>'.substr($MyString, 0, 5).'</em><br>';
echo 'Print from 4th character to end: <em>'.substr($MyString,6).'</em><br>';
echo 'Print last 12 character from the end: <em>'.substr($MyString,-12).'</em><br>';
echo 'Print a segment from the middle: <em>'.substr($MyString,24,-12).'</em><br>';





?>


</body>
</html> 
