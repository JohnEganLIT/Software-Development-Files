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

function formValidation() 
{
	foreach($_POST AS $fieldname) 
	{ 	
		if(empty($fieldname)) //Makes sure there are no empty fields in $_POST array
		{
			$_SESSION['statusBad'] = 'Please fill in all fields!'; 
			header('Location: '.$_SERVER['REQUEST_URI']);
			exit;
		}								
	}
	
	if(isset($_POST['firstName']))
	{
		if(strlen($_POST['firstName']) > 20) //Checks if first name is too long
		{			
			$_SESSION['statusBad'] = 'First Name is too long!';
			header('Location: '.$_SERVER['REQUEST_URI']);
			exit;
		}	

		if(!preg_match("#^[a-zA-ZáéíóúÁÉÍÓÚ \-\']+$#", $_POST['firstName'])) //Checks first name for allowed characters a-z A-Z áéíóúÁÉÍÓÚ - '
		{			
			$_SESSION['statusBad'] = 'Characters not allowed!';
			header('Location: '.$_SERVER['REQUEST_URI']);
			exit;
		}
	}
	
	if(isset($_POST['lastName']))
	{
		if(strlen($_POST['lastName']) > 20) //Checks if last name is too long
		{
			$_SESSION['statusBad'] = 'Last Name is too long!';
			header('Location: '.$_SERVER['REQUEST_URI']);
			exit;
		}
		
		if(!preg_match("#^[a-zA-ZáéíóúÁÉÍÓÚ \-\']+$#", $_POST['firstName'])) //Checks last name for allowed characters a-z A-Z áéíóúÁÉÍÓÚ - '
		{			
			$_SESSION['statusBad'] = 'Characters not allowed!';
			header('Location: '.$_SERVER['REQUEST_URI']);
			exit;
		}
	}
	
	if(isset($_POST['email1']) && isset($_POST['email2'])) 
	{
		if(strlen($_POST['email1']) > 40) //Checks if email1 is too long
		{
			$_SESSION['statusBad'] = 'Email is too long!';
			header('Location: '.$_SERVER['REQUEST_URI']);
			exit;
		}
		
		if($_POST['email1'] != $_POST['email2']) //Compares email1 and email2 
		{
			$_SESSION['statusBad'] = 'Emails don\'t match!';
			header('Location: '.$_SERVER['REQUEST_URI']);
			exit;
		}
	}
	
	if(isset($_POST['pass1']) && isset($_POST['pass2'])) 
	{
		if(strlen($_POST['pass1']) < 5) //Checks if pass1 is too short
		{
			$_SESSION['statusBad'] = 'Password is too short!';
			header('Location: '.$_SERVER['REQUEST_URI']);
			exit;
		}
		
		if(strlen($_POST['pass1']) > 20) //Checks if pass1 is too long
		{
			$_SESSION['statusBad'] = 'Password too long!';
			header('Location: '.$_SERVER['REQUEST_URI']);
			exit;
		}
		
		if($_POST['pass1'] != $_POST['pass2']) //Compares two submitted passwords
		{
			$_SESSION['statusBad'] = 'Passwords don\'t match!';
			header('Location: '.$_SERVER['REQUEST_URI']);
			exit;
		}
	}
}

function dbInsert($args) //Pass query string followed by variables
{
	include 'config/connection.php';
	
	try
	{				
		$argsArray = func_get_args(); //Puts passed arguemnts into array
			
		$query = $argsArray[0]; //The query is stored in position 0
		
		$stmt = $conn->prepare($query); // Prepared statment to prevent sql injection
		
		for($i=1; $i<count($argsArray); $i++)
		{
			$stmt->bindParam($i, $argsArray[$i]); //Binds parameters eg. binds :? to $_POST[firstName]
		}
		
		if($stmt->execute())
		{
			return true;
		}
		
		else
		{
			return false;
		}
	}
	
	catch(Exception $e)
	{
		$_SESSION['statusBad'] = 'Error Inserting data into database';
		$_SESSION['debug'] = $e->getMessage();
	}
}

function checkUserID($userID) //Checks db for userID
{
	include 'config/connection.php';
	
	try
	{
		$sql = 'SELECT userID FROM users WHERE userID = :userID';
		$stmt = $conn->prepare($sql); 
		$stmt->bindParam(':userID', $userID);
		$stmt->execute(); //Checks db for entered userID
		
		if($stmt->fetch(PDO::FETCH_NUM) > 0)  //Checks how many rows contain this username
		{
			return true; //User ID exists
		}
		
		else
		{
			return false; //User ID does not exist
		}
	}
	
	catch(PDOException $e)
	{
		$_SESSION['debug'] = $e->getMessage();
	}
	
}

function checkEmail($email) //Checks db for email
{
	include 'config/connection.php';
	
	try
	{	
		$sql = 'SELECT email FROM users WHERE email = :email';
		$stmt = $conn->prepare($sql); 
		$stmt->bindParam(':email', $email);
		$stmt->execute(); //Checks db for entered email
		
		if($stmt->fetch(PDO::FETCH_NUM) > 0)  //Checks how many rows contain this username
		{
			return true; //Email exists
		}
		
		else
		{
			return false; //Email does not exist
		}
	}
	
	catch(PDOException $e)
	{
		$_SESSION['debug'] = $e->getMessage();
	}	
}

function getFirstName()
{
	try
	{	
		$sql = 'SELECT email FROM users WHERE email = :email';
		$stmt = $conn->prepare($sql); 
		$stmt->bindParam(':email', $email);
		$stmt->execute(); //Checks db for entered email
		
		if($stmt->fetch(PDO::FETCH_NUM) > 0)  //Checks how many rows contain this username
		{
			return true; //Email exists
		}
		
		else
		{
			return false; //Email does not exist
		}
	}
	
	catch(PDOException $e)
	{
		$_SESSION['debug'] = $e->getMessage();
	}	
}

function encryptPass($pass, $userID) //Returns encrypted version of password
{
	$salt = $userID; //Creates a per user salt for increased security and makes rainbow tables useless
	$cryptPass = hash('sha256', $salt.$pass); //Encrypts password and uses sha256 hashing along with the salt for increased security
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

function logout()
{
	session_unset(); //Unsets session variable
	session_destroy(); //Destroys session data. Logs out user. 
}

