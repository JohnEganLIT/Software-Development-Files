<?php
////////////////////////////////////////////////////////////////////////////////////////////////////////
//TASK ONE
//define the array
$marks = array("DP" => 50, "WP" => 59, "PR" => 76, "HC" => 33, "WD" => 21, "DV" =>89);


////////////////////////////////////////////////////////////////////////////////////////////////////////
//TASK TWO
//find the students average mark
$total = 0;

foreach ($marks as $value) {
	
	$total += $value;
}

$average = $total / count($marks);

echo "Average is " .  number_format($average, 2);

////////////////////////////////////////////////////////////////////////////////////////////////////////
//TASK THREE
//find the lowest mark and the subject it was obtained in
//you could sort the array and take the first value in the newly sorted array as the smallest
//you could also use min function which finds the smallest value in an array....
$smallestMark = $marks["DP"];
	
foreach ($marks as $key => $value) {
	
	if ($value < $smallestMark) {
		
		$smallestMark = $value;
		$smallestSubj = $key;
	}
}

echo "<br><br>Smallest mark is $smallestMark and was achieved in $smallestSubj";

echo "<br><br>";

////////////////////////////////////////////////////////////////////////////////////////////////////////
//TASK FOUR
//display each subject and display whether it was below average, above average or equal to the average mark
foreach ($marks as $key => $value) {
	
	echo "Subject $key : ";
	if ($value < $average) {
		echo "$value is <font color=\"red\">BELOW</font> the average<br>";
	}
	else if ($value > $average) {
		echo "$value is <font color=\"green\">ABOVE</font> the average<br>";
	}
	else {
		echo "$value is <font color=\"orange\">EQUAL</font> TO the average<br>";
	}
}
	
			  
?> 