<?php include "library/header.php" ?>	
	<?php
		if(isset($_POST['adminLogin']))
		{
			$sql = "SELECT userID, Password FROM users WHERE userID = :userID AND password = :password";
			
			$cryptPass = encryptPass($_POST['password'], $_POST['userID']);//Returns encrypted version of password

			$stmt = $conn->prepare($sql); 
			$stmt->bindParam(':userID', $_POST['userID']);
			$stmt->bindParam(':password', $cryptPass);
			$stmt->execute(); 
			
			$result = $stmt->fetch();
			
			if($result)
				$_SESSION['userID'] = 'Admin';
			
			else
				echo 'Wrong username or password';
			
			header('Location:profile.php');
			exit();
		}

	?>
	<main>	
	<h1>Admin Page</h1>
	<br>
		<?php if(!isset($_SESSION['userID'])){ ?>
			<form method="post" action="admin.php">	
				<h2>Admin Login</h2>
				<input name="userID" type="text"  minlength="" />	<br>
				<input name="password" type="password"  minlength="" />	<br>
				
				<input type="submit" name="adminLogin" type="submit" value="Login"  />
			</form>
		<?php
			}
		?>
	</main>
<?php include "library/footer.php" ?>
