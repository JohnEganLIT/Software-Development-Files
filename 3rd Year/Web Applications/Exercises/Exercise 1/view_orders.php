<?php 
	@ $fp = fopen("orders.txt", 'r');
	//echo fread($fp,filesize("orders.txt"));
	//$orderArray;
	
	while(($line = fgets($fp)) !== false) 
	{
        echo $line . "<br>";
    }
	fclose($fp);
?>

<br><br><a href="index.html">Home</a>