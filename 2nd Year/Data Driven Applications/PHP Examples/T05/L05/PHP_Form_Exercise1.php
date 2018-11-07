<!DOCTYPE html>

<style>
th, td {
    text-align: left;
    padding: 8px;
}

.oddrows:nth-child(even){background-color: #AAAAAA}

input[type=text], select {
    width: 100%;
    padding: 12px 20px;
    margin: 8px 0;
    display: inline-block;
    border: 1px solid #ccc;
    border-radius: 4px;
    box-sizing: border-box;
}

input[type=submit] {
    background-color: #4CAF50;
    color: white;
    padding: 14px 20px;
    margin: 8px 0;
    border: none;
    border-radius: 4px;
    cursor: pointer;
}

input[type=submit]:hover {
    background-color: #45a049;
}

div {
    border-radius: 5px;
    background-color: #f2f2f2;
    padding: 40px;
}

#header {
	width:500px;
    background-color:#f1f185;
    color:black;
    text-align:center;
    padding:10px;
}

#top {
    background-color:#eeeeee;
    height:300px;
    width:500px;
    float:left;
    padding:10px;	      
}



#bottom {
	width:500px;
    background-color:#f1f185;
   padding:10px;	 	 
}

</style>

<head>
<title>PHP_Form_Ex1</title>
</head>
<body>
<div id="header">
<h1>Exercise 1 Form Self Processing</h1>
</div>
<div id="top">


<form action="<?php echo $_SERVER["PHP_SELF"];?>" method="post">
	<table border=0>
		<tr><td>Enter a value: </td><td><input type="text" name="value1"></td></tr>
		<tr><td>Enter a value: </td><td><input type="text" name="value2"></td></tr>
		<tr>
			<td  colspan=2>
			<input type="submit"  value="ADD" name="btn_add">
			<input type="submit" value="SUBTRACT" name="btn_subtract">
			<input type="submit" value="TABLE" name="btn_table">
			</td>
		<tr>
	</table>
</form>
</div>


<?php
//define the functions
function sum($x, $y) {
    $z = $x + $y;
    return $z;
}

function diff($x, $y) {
    $z = $x - $y;
    return $z;
}

function mult($x, $y) {
    $z = $x * $y;
    return $z;
}
?>

<div id="bottom">
<?php
if (isset($_POST['btn_add'])){  //check that the button has been pressed
    echo 'The SUM of '.$_POST['value1'];
    echo ' and '.$_POST['value2'];
    echo ' is = '.sum($_POST['value1'],$_POST['value2']);
}
else if (isset($_POST['btn_subtract'])){  //check that the button has been pressed
    echo 'The DIFFERENCE of '.$_POST['value1'];
    echo ' and '.$_POST['value2'];
    echo ' is = '.diff($_POST['value1'],$_POST['value2']);
}
else if (isset($_POST['btn_table'])){  //check that the button has been pressed
    echo '<table border=1>';
    $val1=$_POST['value1'];
    for ($i=1;$i<=$_POST['value2'];$i++)
        {
        echo '<tr class=oddrows><td>'.$_POST['value1'].'</td><td>Times</td><td> '.$i.'</td><td> = '.mult($val1,$i).'</td></tr>';
        }
    echo '</table>';
}
else //the form has not been submitted
{
    echo "<p>Please enter some values in the form.</p>";
}


?>
</div>
</body>
</html> 

