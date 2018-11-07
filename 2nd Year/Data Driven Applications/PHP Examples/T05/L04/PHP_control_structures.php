<html>
<head>
<title>PHP_control_structures</title>
</head>
<body>
<h1>Control Structures</h1>
<h2>If...Else if</h2>
<p>
<?php
$ip = $_SERVER['REMOTE_ADDR'];
$agent = $_SERVER['HTTP_USER_AGENT'];

if(strpos($agent, "MSIE") !== false)
	$agent = "Internet Explorer";
else if (strpos($agent, 'Firefox') !== false)
	$agent = "Firefox";
else if (strpos($agent, 'Chrome') !== false)
	$agent = "Chrome";
else if (strpos($agent, 'Safari') !== false)
	$agent = "Safari";
else if (strpos($agent, 'Webkit') !== false)
	$agent = "Webkit";
else if (strpos($agent, 'Gecko') !== false)
	$agent = "Gecko compatible browser";
else 	$agent = "an unknown browser";
	
echo "Your computer IP is $ip and you are using $agent";
?>

<h2>While..</h2>
<?php
$number = 1;
while ($number < 11)
{
   echo $number . '<br>';
   $number++;
}
?>
<h2>For..</h2>
<?php
echo '<h3>For example 1: </h3>';
for ($i=1;$i<=10;$i++)
{
   echo $i . '<br>';
}

echo '<h3>For example 2 (using break): </h3>';
for ($i = 1; ; $i++) {
    if ($i > 10) {
        break;
    }
    echo $i.'<br>';
}
?>

<h2>Switch..</h2>
<?php
$choice='cake';
switch ($choice) {
    case "apple":
        echo "Your choice is apple";
        break;
    case "bar":
        echo "Your choice  is bar";
        break;
    case "cake":
        echo "Your choice  is cake";
        break;
	default:
		echo "You have not made a valid choice";
		break;
}
?>


</body>
</html> 
