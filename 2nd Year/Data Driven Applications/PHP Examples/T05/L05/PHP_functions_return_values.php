<html>
<head>
<title>PHP_functions_return_values</title>
</head>
<body>

<h1>Functions Returning Values</h1>


<h2>Table of Important Web Programming Technologies</h2> 

<p>
<?php

//define functions:
function buildRows($array)
{	//generates a string of html containing the row data and table row element tags
   $rows = '<tr><td>' .
           implode('</td></tr><tr><td>', $array) .
           '</td></tr>';   //note the use of the implode function

   return $rows;  //returns a string
}

function buildTable($rows)
{  //adds the table element tags to the rows
   $table = "<table cellpadding='1' cellspacing='1' bgcolor='#FFCC00' border='1'>$rows</table>";
   return $table;
}

//create an array to display in the table
$myarray = array('php',
                 'mysql',
                 'apache',
                 'java',
                 'xml');

//call the functions to create the table
echo buildTable(buildRows($myarray));

?>

</p>
</body>
</html> 
