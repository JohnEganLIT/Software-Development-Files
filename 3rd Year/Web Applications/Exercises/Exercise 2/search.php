<?php include "config/connection.php" ?>
<html>
	<head>
		<link rel="stylesheet" href="style.css"/>
	</head>
	<body>
		
	<?php 
	if(isset($_POST['location']) && isset($_POST['priceRange']))
	{
		$location = $_POST["location"];
		$priceRange = $_POST["priceRange"];
	}

	if($_POST["priceRange"] == "any")
	{
		$sql = "SELECT * FROM properties WHERE city = :location";
		
		$stmt = $conn->prepare($sql);
		$stmt->bindParam(':location', $location);
		$stmt->execute();		
	}
	
	else if($_POST["priceRange"] == "150")
	{
		$sql = "SELECT * FROM properties WHERE city = :location AND price >= 150000 AND price <= 200000";
		
		$stmt = $conn->prepare($sql);
		$stmt->bindParam(':location', $location);
		$stmt->execute();	
	}
	
	else if($_POST["priceRange"] == "200")
	{
		$sql = "SELECT * FROM properties WHERE city = :location AND price >= 200000 AND price <= 250000";
		
		$stmt = $conn->prepare($sql);
		$stmt->bindParam(':location', $location);
		$stmt->execute();	
	}
	
	else if($_POST["priceRange"] == "250")
	{
		$sql = "SELECT * FROM properties WHERE city = :location AND price >= 300000 AND price <= 350000";
		
		$stmt = $conn->prepare($sql);
		$stmt->bindParam(':location', $location);
		$stmt->execute();	
	}
	
	else if($_POST["priceRange"] == "300")
	{
		$sql = "SELECT * FROM properties WHERE city = :location AND price >= 350000 AND price <= 500000";
		
		$stmt = $conn->prepare($sql);
		$stmt->bindParam(':location', $location);
		$stmt->execute();	
	}
	
	if($stmt->fetch() == NULL)
	{
		echo "No results" . "<br>";
	}
	
	else
	{
		while($result = $stmt->fetch())
		{
			echo '<a href="result.php?id='. $result['id'].'">';
			echo '<div id="searchResult">';
				echo '<p>';
				echo '<img src="images/thumbnails/' . $result["photo"] . '" id="litLogo"/>';
					echo $result["street"] . "<br>";
					echo $result["city"] . "<br>";
					echo "\xE2\x82\xAc" . $result["price"];
					
				echo '<p>';
			echo '</div>';
			echo '</a>';
		}
	}
	
	?>
	</body>
</html>