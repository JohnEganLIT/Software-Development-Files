<?php
include "../includes/connection.php";
include "../includes/functions.php";
secureSession(); //Starts secure session
access(); //Prevents access if not logged in

try{
	if($_POST['form'] == "accDetails") //If account details form has been submitted
	{
		if($_POST['username'] == '' || $_POST['email'] == '')//Makes sure there are no empty fields
		{
			$_SESSION['statusBad'] = 'Please fill in all fields!';
			header("location:../register.php");
			exit();
		}
		
		$id = $_SESSION['id']; 
		$username = $_POST['username'];
		$email = $_POST['email'];
		
		$sql = 'SELECT * FROM users WHERE (username = :username OR email = :email) AND id != :id';
		$stmt = $conn->prepare($sql);
		$stmt->bindParam(':id', $id);
		$stmt->bindParam(':username', $username);
		$stmt->bindParam(':email', $email);
		$stmt->execute(); //Checks every other row for entered username and email. 
		
		if($row = $stmt->fetch()) //If username or email already exists.
		{
			if($row['username'] == $username)
			{
				$_SESSION['status'] = "Username in use!";
				header("location:../account.php");
				exit();
			}
			
			elseif($row['email'] == $email)
			{
				$_SESSION['status'] = "Email in use!";
				header("location:../account.php");
				exit();
			}
		}
		
		else
		{
			$sql = 'UPDATE users SET username = :username, email = :email WHERE id=:id'; 
			$stmt = $conn->prepare($sql);
			$stmt->bindParam(':id', $id);
			$stmt->bindParam(':username', $username);
			$stmt->bindParam(':email', $email);
			$result = $stmt->execute(); //Updates row with new username and/or email.
			
			if($result)
			{
				$_SESSION['statusGood'] = "Username and email saved successfully";
				header("location:../account.php");
				exit();
			}
			
			else
			{
				$_SESSION['statusBad'] = "Error saving username and email!";
				header("location:../account.php");
				exit();
			}
		}
		
	}
	
	elseif($_POST['form'] == "accAddress") //If account delivery address has been submitted
	{
		$sql = 'UPDATE users SET address1 = :address1, address2 = :address2, town = :town, county = :county WHERE id=:id';
		$stmt = $conn->prepare($sql);
		$stmt->bindParam(':id', $_SESSION['id']);
		$stmt->bindParam(':address1', $_POST['address1']);
		$stmt->bindParam(':address2', $_POST['address2']);
		$stmt->bindParam(':town', $_POST['town']);
		$stmt->bindParam(':county', $_POST['county']);
		$result = $stmt->execute(); //Updates row with new address
		
		if($result)
		{
			$_SESSION['statusGood'] = "Address saved successfully";
			header("location:../account.php");
			exit();
		}
		
		else
		{
			$_SESSION['statusBad'] = "Error saving address!";
			header("location:../account.php");
			exit();
		}
	}
	
	elseif($_POST['form'] == "accPassword") //If account password change form has been submitted
	{
		if($_POST['pass1'] == '' || $_POST['pass2'] == '')//Makes sure there are no empty fields
		
		if($_POST['pass1'] != $_POST['pass2'])
		{
			$_SESSION['statusBad'] = "Passwords don't match";
			header("location:../account.php");
			exit();
		}
		
		$cryptPass = encrypt($_POST['pass1']); //Gets encrypted version of entered password
		
		$sql = 'UPDATE users SET password=:password WHERE id=:id';
		$stmt = $conn->prepare($sql);
		$stmt->bindParam(':id', $_SESSION['id']);
		$stmt->bindParam(':password', $cryptPass);
		$result = $stmt->execute(); //Updates row with new password
		
		if($result)
		{
			$_SESSION['statusGood'] = "Password change successful";
			header("location:../account.php");
		}
		
		else
		{
			$_SESSION['statusBad'] = "Error changing password!";
			header("location:../account.php");
		}
	}
}

catch(PDOException $e)
{
	$_SESSION['status'] = "Error:" . $e->getMessage();
	header("location:../account.php");
}
?>