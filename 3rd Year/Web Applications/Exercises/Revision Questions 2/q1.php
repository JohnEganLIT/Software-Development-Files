<!DOCTYPE HTML>
<html>
<head>
	<style>
		*{
			font-size: 1.1em;
		}
		
		table, th, td{
			border: 1px solid black;
			font-size: 1em;
			text-align: center
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
 
		for($i=0;$i<100;$i++)
		{
			$rands[$i] = rand(0,49);
		}

		$smallest = $rands[0];
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
			
			if($item < $smallest)
				$smallest = $item;
			
			$counter++;
		}

		echo "<p>The Smallest number is <span id=\"smallestNum\">" . $smallest . "</span></p>";
		?>
		<tr>
	</table>

</body>
</html>