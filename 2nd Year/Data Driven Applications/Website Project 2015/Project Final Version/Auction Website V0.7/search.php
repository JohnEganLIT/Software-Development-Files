<?php include "includes/header.php"; ?>
<div class="main container">
	<?php
	$search = $_POST['search'];
	
	echo "<a href=\"index.php\" id=\"resetBtn\">Reset Search</a>";
	
	try
	{
		$sql = "SELECT * FROM auctions WHERE title REGEXP :search OR category REGEXP :search";
		$stmt = $conn->prepare($sql);
		$stmt->bindParam(':search', $search);
		$stmt->execute(); //Finds auctions where the title or category fields contain a substring equal to $search 
		
		if($stmt->rowCount() > 0)
		{
			while($row = $stmt->fetch()) //Outputs results
			{
				echo "<div class=\"contentContainer\" onclick=\"location.href='viewAuction.php?auctionID=" . $row['id'] . "'\">";
					echo "<h2>" . $row['title'] . "</h2>";
					echo "<img src=".$row['image'].">" ;
					echo '<div class="price">€' . $row['price'] . "</div>";
				echo '</div>';
			}
		}

		else
		{
			echo "<div id=\"noResult\">" . $search . " not found.</div>";
		}
	}

	catch(PDOException $e)
	{
		$e->getMessage();
	}
	?>
</div>
<?php include "includes/footer.php";?>