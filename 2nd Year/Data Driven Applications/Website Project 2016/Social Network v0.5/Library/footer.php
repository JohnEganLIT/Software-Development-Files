</body>
<footer>
	<div class="container">
		<?php
		if (__DEBUG==1) 
		{	
			echo 'Debug mode is ON</br>';
			
			if(!empty($_POST))
			{
				echo '$_POST ';
				print_r($_POST);
			}
			
			if(!empty($_SESSION))
			{
				echo '$_SESSION ';
				print_r($_SESSION);
			}
		}

		else
		{
			echo '&copy;2015 Colin Maher';
		}
		?>
	<div>
</footer>