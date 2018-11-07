<?php
	include 'connection.php';
	include 'functions.php';
	
	if(isset($_POST['user']) && isset($_POST['pass']) && isset($_POST['email']))
	{
		$user = $_POST['user'];
		$pass = $_POST['pass'];
		$email = $_POST['email'];
	}
	
	else
	{
		signInForm();
		$_SESSION['regStatus'] = 'Error!';
	}

	$secure = "ireland";
	$cryptPass = crypt($pass, $secure);
		
	$query1 = mysql_query("SELECT * FROM users WHERE username='$user'");
	$query2 = mysql_query("SELECT * FROM users WHERE email='$email'");
	
	if(mysql_num_rows($query1) > 0) 
	{ 
		session_start();
		$_SESSION['regStatus'] = 'Username already exists!';
		
		if(isset($_COOKIE['adminLoggedIn']))
		{
			ControlPanel();
		}
		
		else
		{
			SignInForm();
		}
	}
	
	elseif(mysql_num_rows($query2) > 0)
	{
		session_start();
		$_SESSION['regStatus'] = 'Email already exists!';
		
		if(isset($_COOKIE['adminLoggedIn']))
		{
			ControlPanel();
		}
		
		else
		{
			SignInForm();
		}
	}
	
	else
	{
		mysql_query("INSERT INTO users (username, password, email) 
		VALUES ('$user', '$cryptPass', '$email')");
		
		session_start();
		$_SESSION['regStatus'] = 'Account Created!';
		
		if(isset($_COOKIE['adminLoggedIn']))
		{
			ControlPanel();
		}
		
		else
		{
			SignInForm();
		}
	}
?>
