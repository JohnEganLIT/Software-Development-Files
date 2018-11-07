<html>
<head>
<title>PHP_functions</title>
</head>
<body>

<h1>Functions</h1>



<?php
//define the functions

function writeMsg1() {
    echo "The message is:Hello World <br>";
}

function writeMsg2($msg) {
    echo "The message is: $msg<br>";
}

function sum($x, $y) {
    $z = $x + $y;
    return $z;
}

//define some variables:
$myMessage="Welcome to Data Driven Applications";
$var1=10;
$var2=15;

//call the functions
writeMsg1();
writeMsg2($myMessage); // call the function

echo "The sum of $var1 and $var2 is = sum($var1,$var2) <br>"; //a function cannot be evaluated inside a double-quoted string!! 
echo "The sum of $var1 and $var2 is = ".sum($var1,$var2);  //but this works

?>
</body>
</html> 
