<?php include "includes/header.php" ?>		
<div class="main container">
	<?php
	try
	{
		$sql = 'SELECT * FROM auctions';
		$stmt = $conn->prepare($sql);
		$result = $stmt->execute();
		
		if($stmt->rowCount() == 0)
		{
			echo '<div id="noAuctions">';
			echo '<img src="images/arrow.png" id="arrowImage" alt="arrow">';
			if(isset($_SESSION['id']))
			{
				echo "<h2>There are no auctions at the moment :(</h2>";
				echo "<p>You can create your own auction here</p>";
			}
			
			elseif(!isset($_SESSION['id']))
			{
				echo "<h2>There are no auctions at the moment :(</h2>";
				echo "<p>Login to create your own auction</p>";
			}
			echo "</div>";
		}
		
		while($row = $stmt->fetch())
		{
			echo "<div class=\"contentContainer\" onclick=\"location.href='viewAuction.php?auctionID=" . $row['id'] . "'\">";
				echo "<h2>" . $row['title'] . "</h2>";
				echo "<img src=".$row['image'].">" ;
				echo '<div class="price">€' . $row['price'] . "</div>";
			echo '</div>';
		}
	}

	catch(PDOException $e)
	{
		$e->getMessage();
	}
	?>
</div>		
<?php include "includes/footer.php" ?>