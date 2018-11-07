<?php
	function checkPalindrome($num)
	{	
		settype($num, "string");
		
		$reverse = strrev($num);
		
		if($num == $reverse)
			return 1;
		
		else 
			return 0;
	}	
	
	$answer = 100;
	
	for($i=100;$i<1000;$i++)
	{
		for($y=100;$y<1000;$y++)
		{
			if(checkPalindrome($i*$y))
			{
				if($answer < $i*$y)
					$answer = $i * $y . "<br>";
			}			
		}
	}
	
	echo $answer;
	
?>

