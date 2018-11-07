</body>
<footer>
	<div class="rowContainer">
		<?php
		if (__DEBUG==1) 
		{	
			echo 'Debug mode is ON</br>';
			
			if(!empty($_POST))
			{
				echo '$_POST ';
				print_r($_POST);
				echo '<br>';
			}
			
			if(isset($_SESSION['debug']))
			{
				echo 'Error: ' . $_SESSION['debug'];
				unset($_SESSION['debug']);
			}
			
			if(isset($_SESSION['userID']))
			{
				echo 'User ID: ' . $_SESSION['userID'];
			}
		}

		else
		{
			echo '&copy;2015 Colin Maher';
		}
		?>
	<div>
</footer>