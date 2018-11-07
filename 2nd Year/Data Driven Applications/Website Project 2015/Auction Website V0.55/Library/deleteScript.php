<?php
	include '../includes/connection.php'; //Connection Parameters 
	
	try
	{
		echo $_SESSION['id'];
		
		$sql = 'DELETE FROM users WHERE id = :id';
		$stmt = $conn->prepare($sql);
		$stmt->bindParam(':id', $_POST['id']);
		$stmt->execute();
		
		header("location:../admin.php");
	}
	
	catch(PDOException $e){
		echo  $e->getMessage();	
	}
?>