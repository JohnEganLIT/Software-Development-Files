<html>
<head>
<title>PHP_SuperGet</title>
<style type="text/css">
<!--
body, table { font:12px Verdana,Arial,Helvetica,sans-serif}
tr.Light { background-color:#F9F9F9 }
tr.Dark { background-color:#C0C0A0 }
tr.Pink { background-color:#EEE0E0; border: solid 1px}
-->
</style>
</head>
<body>
<h1>Accessing the $_GET superglobal</h1>

<h3>Using values retrieved from $_GET</h3>
<?php
echo "The course title is: <font color='RED'> {$_GET['course']} </font><br>";
echo "The module name is: <font color='RED'>{$_GET['module']}</font>";
?>

<hr>

<h3>Instructions to use</h3>
<p>The $_GET is a way of passing user input data to the web server and PHP processor through the URL.
<p>The data is passed as part of the URL as shown in the following example:

<p>
URI = http://localhost:8088/Koxxxxxx/T01/L03/PHP_SuperGet.php?course=Software%20Development&module=Database%20Systems

<p>
Where 'port' and 'path' are the ones used by your web server.
<p>
After the question mark (?) - 'course' and 'module' are the variable names used to identify the $_GET array elements. 
<p>
After the equals sign (=) is the actual data you are passing through the URL. The symbol '&' separates the variables and the character string '%20' is used whenever a space is required.

<p>
Enter the above URL and pass values to it after the  '=' sign. 

<hr>
<h3>Full dump of the $_GET array:</h3>
<table border="1" cellspacing="2">
<tbody>
<tr class="Pink">
<th><h2>Server variable</h2></th><th><h2>Value</h2></th></tr>
<?php
$colors = array('Dark', 'Light'); //an array containing 2 values
$i=0;  //loop counter

//use 'foreach' iterate through the array
foreach($_GET as $key=>$value) //see PHP manual: http://ie.php.net/manual/en/control-structures.foreach.php
    {
   echo '<tr class="'.$colors[$i++ % 2].'">'; //see PHP manual: http://ie.php.net/manual/en/language.operators.arithmetic.php
   echo '<td><b>$_SERVER[\''.$key.'\']</b></td>';
   echo '<td>'.$value.'</td></tr>';
    }
?>
</tbody>
</table>
</body>
</html> 
