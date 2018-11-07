<html>
<head>
<title>PHP_string_functions</title>
</head>
<body>
<h1>String Functions</h1>
<h2>str_repeat($string, $n) : repeat $string $n times: </h2>
<p>
<?php echo str_repeat('  **REPEAT THIS** ', 10);?>
</p>

<h2>strrchr($string, $char) : find the last occurence of the character $char in $string</h2>
<p>For example: you want to get the file extension from a file name. You can use this function in 
conjunction with substr():</p>
<p>
<?php
$filename='mydocument.txt';
$ext = substr(strrchr($filename, '.'), 1);
echo 'The file name is:  '."$filename". '   and its extension is:  ' ."$ext";
?>
</p>

<h2> trim($string) : remove extra spaces at the beginning and end of $string </h2>
<p>
<?php  echo trim('  abc def      ');?>
</p>
 
<h2>addslashes($string) : adding backslashes before characters that need to be quoted in $string</h2>
<p>
This function is usually used on form values before being used for database queries. 
</p>
<?php
$name="O'Brien"; //this string contains a special character
$sql="SELECT * FROM users WHERE name =$name";
echo $sql.'<br>';
echo addslashes($sql).'<br>'; //the special character is now escaped
?>
 

<h2>explode($separator, $string) : Split $string by $separator</h2>
<p>
This function is commonly used to extract values in a string which are separated by a a certain separator 
string. For example, suppose we have some information stored as comma separated values. To extract each 
values we can do it like shown below: </p>
<?php
// extract information from comma separated values
$csv = 'John Smith,15,Main Street';
$info = explode(',', $csv);  //this creates an array $info
?>

<p>
Now, $info is an array with three values : </p>

Array <br>
( <br>
   [0] => John Smith <br>
   [1] => 15 <br>
   [2] => Main Street <br>
) <br>

<p>
We can further process this array like displaying them in a table, etc.</p>
<p>
<?php
echo "<table border='1'>";
foreach ($info as $key=>$value){
	echo '<tr><td>'.$value.'</td></tr>';
}
echo '</table>';
?>


</p>
 
<h2>implode($string, $array) : Join the values of $array using $string</h2>

This one do the opposite than the previous function. For example to reverse back the $info array into a 

string we can do it like this :

<?php
$info = array('John Smith', 15, 'Main Street');
$csv = implode(',', $info);
echo '<br>The string is now:   '."$csv";
?>

<p>
Another example : Pretend we have an array containing some values and we want to print them in an ordered 
list. We can use the implode() like this :

<?php
// print ordered list of names in array
$names = array('John Smith', 'Peter Murphy', 'Mary Jones', 'Bertie');
echo '<ol><li>' . implode('</li><li>', $names) . '</li></ol>';
?>


</body>
</html>



</body>
</html> 
