<?php
function secureSession() //Creates secure session when called
{
	//Sets up secure session for user to log in to website
	ini_set('session.cookie_httponly', true); //Prevents session ID being accessible via javascript
	ini_set('session.use_only_cookies', true); //Prevents session ID passing as a GET
	
	session_start(); //Starts session

	session_regenerate_id(); //Regenerates session id every time session_start() is called

	if(isset($_SESSION['last_ip']) === false)
	{
		$_SESSION['last_ip'] = $_SERVER['REMOTE_ADDR']; //Sets last IP address
	}

	if($_SESSION['last_ip'] !== $_SERVER['REMOTE_ADDR']) //Compares last IP to current IP
	{
		session_unset(); //Unsets session variable
		session_destroy(); //Destroys session data. Logs out user. 
	}
}

function encrypt($pass) //Returns encrypted version of password
{
	$salt = "6bT4Y7U469"; //Key for extra security
	$cryptPass = crypt($pass, $salt); //Uses Salt encryption
	return $cryptPass;
}

function access() //Refuses access to a page if user is not logged in
{
	if(!isset($_SESSION['id']))
	{
		echo "<div class=\"accessDenied\">Access Denied<div>";
		exit;
	}
}

