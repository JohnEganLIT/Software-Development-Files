<?php include "config/connection.php" ?>
<html>
	<head>
		<link rel="stylesheet" href="style.css"/>
	</head>
	<body>
		
	<?php 
	$sql = "SELECT * FROM properties WHERE id = :id";
	
	$stmt = $conn->prepare($sql);
	$stmt->bindParam(':id', $_GET["id"]);
	$stmt->execute();

	while($result = $stmt->fetch())
	{
		echo '<div id="result">';
			echo '<p>';
			echo '<img src="images/full/' . $result["photo"] . '" id="litLogo"/>';
				echo $result["street"] . "<br>";
				echo $result["city"] . "<br>";
				echo "\xE2\x82\xAc" . $result["price"] . "<br>";
				echo "No. of Bedrooms: " . $result["bedrooms"] . "<br>";
				echo "No of Bathrooms:" . $result["bathrooms"] . "<br>";
				echo "Square Ft. " . $result["squarefeet"] . "<br>";
				echo "Garage Size: " . $result["garagesize"] . "<br>";				
			echo '<p>';
		echo '</div>';
	}		
	?>
	<a id="homeBtn" href="index.php">Home</a>
	</body>
</html>

