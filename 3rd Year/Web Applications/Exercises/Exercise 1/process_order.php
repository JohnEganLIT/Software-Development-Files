<?php
$tirePrice = 100;
$oilPrice = 10;
$sPlugPrice = 15;
$totalPrice = $tirePrice + $oilPrice + $sPlugPrice;
$address = $_POST["shipAddr"];

$tires = $_POST["tire"];
$oil = $_POST["oil"];
$sPlugs = $_POST["sPlug"];

$time = date("h:i a, jS F");
?>
<html>
	<head>
		<style>
		
		</style>
	</head>
	<body>
		<h1>Bob's Auto Parts</h1>
		<h2>Order Results</h2>
		
		<p>Order Processed at: <?php echo $time; ?> </p>
		
		<p>Item's ordered: 
		<?php 
		echo $totalPrice . "<br>";
		echo $tires . " tires.<br>";
		echo $oil . " bottles of oil.<br>";
		echo $sPlugs . " spark plugs.<br>";
		echo "<br>Address to ship to is " . $address . ".<br>";
		
		echo "<br>Toal price of order is " . "\xE2\x82\xAc";
		echo ($tires * $tirePrice) + ($oil * $oilPrice) + ($sPlugs * $sPlugPrice);
		
		@ $fp = fopen("orders.txt", 'a');
		flock($fp, LOCK_EX);
		
		if (!$fp)
		{
			 echo '<p><strong> Your order could not be processed at this time. Please try again later.</strong></p></body></html>';
			 exit;
		}
		
		$outputstring = $time . ". " . $tires . " tires   " . $oil . " oil cans   " . $sPlugs . " spark plugs   " . $totalPrice . " " . $address . "\n";
		if(fwrite($fp, $outputstring, strlen($outputstring))); //where $outputstring contains the text you want to write to
			echo "<br><br>Written to file";
		flock($fp, LOCK_UN);
		fclose($fp);
		?>
		<br><br><a href="index.html">Home</a>
		</p>
	</body>
</html>