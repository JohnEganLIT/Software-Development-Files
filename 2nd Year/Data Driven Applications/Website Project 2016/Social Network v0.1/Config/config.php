<?php
	
define ('__DEBUG',0); //Enable(1) or Disable(0) debug mode. 
define ('__ErrorPage', 'error.php'); // Displayed in case of error

error_reporting(E_ALL ^ E_WARNING); //Supresses PHP warnings
?>