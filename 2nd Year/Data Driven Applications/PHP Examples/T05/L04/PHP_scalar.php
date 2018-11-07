<html>
<head>
<title>PHP_scalar</title>
</head>
<body>

<h1>Scalar Data Types</h1>

<?php
echo '<h3>Integer/Float</h3>';
$i=1;
$n=10;
while($i<=$n){
	$x=$n%$i;
	$z=$n/$i;
	if ($x)
	{
	echo "<p>Loop Variable value is : $i and the division result is $z (Floating Point)</p> ";
	}
	else
	{
	echo "<p>Loop Variable value is  : $i and the division result is $z (Integer)</p> ";
	}
	$i++;}
echo '<hr>';

echo '<h3>Float</h3>';
$a = 1.234; 
$b = 1.2e3; 
$c = 7E-10;

echo $a*$b*$c;

echo '<h3>Boolean</h3>';
$some_state=TRUE; //experiment with assigning different values eg FALSE,1, 0, -5, 5 , 'abc'

if ($some_state)
{
echo 'The variable state is TRUE, its value is '.$some_state;
}
else
{
echo 'The variable state is FALSE, its value is '.$some_state;
}
echo '<hr>';

$var1="hello";
$var2="hello";
if ($var1==$var2){
	echo '<p>$var1 is equivalent to $var2</p>';
}
else {
echo '<p>$var1 is NOT equivalent to $var2</p>';
}


?>

</body>
</html> 
