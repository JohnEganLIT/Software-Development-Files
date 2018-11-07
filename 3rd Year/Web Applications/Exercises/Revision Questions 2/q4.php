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
		<td><h3>Value</h3></td><td><h3>Frequency</h3></td>
	</tr>
	<tr>
		<?php
		$rands = array();
 
		for($i=0;$i<1000;$i++)
		{
			$rands[$i] = rand(0,30);
		}	
		
		for($i=0;$i<=30;$i++)
		{
			$freqCounter = 0;
			
			foreach($rands as $item)
			{
				if($rands[$i] == $item)
				 $freqCounter++;
			}	
			
			echo "<tr><td><span id=\"firstNum\">" . $i . "</span></td><td><span id=\"secondNum\">" . $freqCounter . "</td></tr>";
		}
		
		$mean = 0;
		
		foreach($rands as $item)
		{
			$mean += $item; 
		}
	
		$mean /= 1000;
		
		echo "The average of the values in the array is " . $mean;
		
		?>
		</tr>
	</table>
</body>
</html>