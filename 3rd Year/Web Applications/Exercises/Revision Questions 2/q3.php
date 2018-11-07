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
			<td id="heading" colspan="10">Random Number Generator</td>
		</tr>
		<tr>
			<?php
			$rands = array();
	 
			for($i=0;$i<20;$i++)
			{
				$rands[$i] = rand(0,99);
			}

			$counter = 0;

			foreach($rands as $item)
			{
				if($counter == 10)
				{
					$counter = 0;
					echo "</tr>";
					echo "<tr>";
				}
				
				echo "<td>" .$item . "</td>";
				
				$counter++;
			}
			
			$reverse = array();
			$x = count($rands) - 1;
			
			for($i=0;$i<20;$i++)
			{
				$reverse[$i] = $rands[$x];
				$x--;
			}			
			
			?>
		</tr>
	</table>
	
	<table>
		<tr>
			<td id="heading" colspan="10">Reversed</td>
		</tr>
		<tr>
			<?php
			foreach($reverse as $item)
			{
				if($counter == 10)
				{
					$counter = 0;
					echo "</tr>";
					echo "<tr>";
				}
				
				echo "<td>" .$item . "</td>";
				
				$counter++;
			}
			?>
		</tr>
	</table>
</body>
</html>