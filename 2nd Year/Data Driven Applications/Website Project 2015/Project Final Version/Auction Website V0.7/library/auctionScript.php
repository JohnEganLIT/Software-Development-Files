<?php
include '../includes/connection.php'; //Connection Parameters 
include '../includes/functions.php'; //PHP functions
secureSession(); //Starts secure session
access(); //Prevents access if not logged in

$directory = "../images/auctions/";
$file = $directory . basename($_FILES["file"]["name"]);

$fileType = pathinfo($file,PATHINFO_EXTENSION);

// Check if image file is a actual image 
if(isset($_POST["submit"])) 
{
    $check = getimagesize($_FILES["file"]["tmp_name"]);
    if($check == false) 
	{
		$_SESSION['statusBad'] = ".jpg files only please";
        header("location:../auction.php");
		exit();
    } 
	
	 // Check file size
	if($_FILES["file"]["size"] > 5000000) 
	{
		$_SESSION['statusBad'] = "Your file is too large";
		header("location:../auction.php");
		exit();
	}
	
	// Allow only Jpeg file format
	if($fileType != "jpg") 
	{
		$_SESSION['statusBad'] = ".jpg files only please";
        header("location:../auction.php");
		exit();
	}
	
	$value = array(); 
	$value = explode(".", $file); 
	$extension = strtolower(end($value)); //gets file extension 
	$newName = "id" . $_SESSION['id'] . $_POST['title'] . round(microtime(true)). "." . $extension; //renames file with user id, title, and current timestamp.
	$newName = str_replace(' ', '', $newName); //Removes spaces
	
	if(move_uploaded_file($_FILES["file"]["tmp_name"], $directory . $newName) == False) //If there is an error saving image to images/auctions/.
	{
		$_SESSION['statusBad'] = "Sorry, there was an error uploading your file.";
		header("location:../auction.php");
		exit();
	} 

	try
	{
		{
			$sql = 'SELECT username FROM users WHERE id=:id';
			$stmt = $conn->prepare($sql);
			$stmt->bindParam(':id', $_SESSION['id']);
			$stmt->execute(); //Selects username from row with current logged in id
			
			if($row = $stmt->fetch()) 
			{	
				$username = $row['username'];
			}
			
			else
			{
				$_SESSION['statusBad'] = "Error Creating Auction";
				header("location:../auction.php");
				exit();
			}
		}
		
		$title = $_POST['title'];
		$description = $_POST['description'];
		$price = $_POST['price'];
		$category = $_POST['category'];
		$directory = "images/auctions/";
		$image = $directory . $newName;
		
		$sql = 'INSERT INTO auctions (title, category, description, price, image, username) VALUES (:title, :category, :description, :price, :image, :username)';
		$stmt = $conn->prepare($sql); 
		$stmt->bindParam(':title', $title);
		$stmt->bindParam(':category', $category);
		$stmt->bindParam(':description', $description);
		$stmt->bindParam(':price', $price);
		$stmt->bindParam(':image', $image);
		$stmt->bindParam(':username', $username);
		$result = $stmt->execute(); //Inserts title, category, description, price, image and username into new row in auctions table.
		
		if($result)
		{
			$_SESSION['statusGood'] = "Auction Created Successfully";
			header("location:../auction.php");
			exit();
		}
		
		else
		{
			$_SESSION['statusBad'] = "Error Creating Auction";
			header("location:../auction.php");
			exit();
		}
	}
	
	catch(PDOException $e)
	{
		$_SESSION['debug'] = $e->getMessage();
	}
}
?>
