<!DOCTYPE HTML>
<html>
<head>
	<style>
		*{
			font-size: 1.1em;
		}
		
		table, th, td{
			margin-top: 5px;
			border: 1px solid black;
			font-size: 1em;
			text-align: center;
		}
		
		td{
			width: 100px;
		}
		
		#smallestNum{
			color: red;
		}
		
		#heading{
			text-align: center;
		}
		
		#firstNum{
			color: blue;
		}
		
		#secondNum{
			color: red;
		}
	</style>
</head>
<body>
	<table>
	<tr>
	<td id="heading" colspan="12">Random Number Generator</td>
	</tr>
		<tr>
		<?php
		$rands = array();
 
		for($i=0;$i<50;$i++)
		{
			$rands[$i] = rand(10,19);
		}
		
		$counter = 0;

		foreach($rands as $item)
		{
			if($counter == 12)
			{
				$counter = 0;
				echo "</tr>";
				echo "<tr>";
			}
			
			echo "<td>" .$item . "</td>";
			
			$counter++;
		}
		
		
		
		for($i=10;$i<20;$i++)
		{
			$freqCounter = 0;
			
			foreach($rands as $item)
			{
				if($rands[$i] == $item)
				 $freqCounter++;
			}	
			
			echo "The number <span id=\"firstNum\">" . $i . "</span> appears <span id=\"secondNum\">" . $freqCounter . " </span>times.<br>";
		}

		?>
		</tr>
	</table>

</body>
</html>