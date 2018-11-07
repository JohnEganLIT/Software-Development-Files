<?php
	include '../includes/functions.php'; //PHP functions
	include '../includes/connection.php'; //Connection Parameters 
	secureSession(); //Starts secure session
	
	if($_POST['user'] == '' || $_POST['email'] == '' || $_POST['pass1'] == '' || $_POST['pass2'] == '')//Makes sure there are no empty fields
	{
		$_SESSION['status'] = 'Please fill in all fields!';
		header("location:../register.php");
	}
	
	elseif(strcmp($_POST['pass1'], $_POST['pass2']) !== 0)//compares pass1 and pass2
	{
		$_SESSION['status'] = 'Passwords do not match!';
		header("location:../register.php");
	}
	
	$username = $_POST['user'];
	$email = $_POST['email'];
	$pass = $_POST['pass1'];
	
	try
	{
		//PDO prepared statements to prevent sql injection
		$sql = 'SELECT * FROM users WHERE username = :username';
		$stmt = $conn->prepare($sql); 
		$stmt->bindParam(':username', $username);
		$stmt->execute(); //Finds entered username
		
		$sql2 = 'SELECT * FROM users WHERE email = :email';
		$stmt2 = $conn->prepare($sql2);
		$stmt2->bindParam(':email', $email);
		$stmt2->execute(); //Finds entered email
		
		if($stmt->fetch(PDO::FETCH_NUM) > 0)  //Checks how many rows contain this username
		{
			$_SESSION['status'] = $username . ' already exists!';
			header("location:../register.php");
		}
		
		elseif($stmt2->fetch(PDO::FETCH_NUM) > 0)  //Checks how many rows contain this email
		{
			$_SESSION['status'] = $email . ' already exists!';
			header("location:../register.php");
		}
		
		else
		{
			$cryptPass = encrypt($pass); //Gets encrypted version of entered password
		
			$sql3 = 'INSERT INTO users (username, email, password) VALUES (:username, :email, :pass)';
			$stmt3 = $conn->prepare($sql3);
			$stmt3->bindParam(':username', $username);
			$stmt3->bindParam(':email', $email);
			$stmt3->bindParam(':pass', $cryptPass);
			$flag = pdoInsert($stmt3); //Calls pdoInsert Function 
			
			if($flag == true)
			{
				$_SESSION['status'] = 'Registration Successful! Please log in here!';
				header("location:../login.php");
			}
			
			else
			{
				$_SESSION['status'] = 'Error! Please contact an Admin!';
				header("location:../register.php");
			}
		}	
	}
	
	catch(PDOException $e)
	{
		$_SESSION['status'] = $e->getMessage();
		header("location:../register.php");
	}
	
	
?>
