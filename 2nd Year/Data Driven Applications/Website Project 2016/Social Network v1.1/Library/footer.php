</body>
<footer>
	<div class="container">
		<?php
		if (__DEBUG==1) 
		{	
			echo 'Debug mode is ON</br>';
			
			if(isset($_SESSION['userID']))
			{
				echo 'User ID: ' . $_SESSION['userID'] . '<br>';
			}
			
			if(!empty($_POST))
			{
				echo '$_POST ';
				print_r($_POST);
				echo '<br>';
			}
			
			if(isset($_SESSION['debug']))
			{
				echo 'Error: ' . $_SESSION['debug'] . '<br>';
				unset($_SESSION['debug']);
			}
			
		}

		else
		{
			echo '&copy;2015 Colin Maher';
		}
		?>
		
		<a href="admin.php">Admin Login</a>
	<div>
</footer>