</body>
<footer>
	<div class="container">
		<?php
		if (__DEBUG==1) 
		{	
			echo 'Debug mode is ON<br>';
			
			if($_POST)
			{
				echo '$_Post Array Contents</br>';
				print_r($_POST);
			}
		}

		else
		{
			echo '&copy;2015 Colin Maher';
		}
		?>
	<div>
</footer>