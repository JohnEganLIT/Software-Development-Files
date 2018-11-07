<?php
include "library/functions.php";
secureSession();
	session_unset(); //Unsets session variable
	session_destroy(); //Destroys session data. Logs out user. 
	
	header('location:index.php');
?>