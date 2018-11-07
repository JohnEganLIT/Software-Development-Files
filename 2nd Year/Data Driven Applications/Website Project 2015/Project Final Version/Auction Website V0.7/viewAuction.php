<?php include "includes/header.php" ?>		
<div class="main container">
<?php
try
{
	$auctionID = $_GET["auctionID"]; 
	
	$sql = 'SELECT * FROM auctions WHERE id = :id'; 
	$stmt = $conn->prepare($sql);
	$stmt->bindParam(':id', $auctionID);
	$result = $stmt->execute(); //Finds auction with this ID
	
	while($row = $stmt->fetch()) //Ouputs auction
	{	
		echo "<div id=\"viewAuction\">";
		echo "<div id=\"liveBid\"> Ajax live bidding coming eventually </div>";
			echo "<h1>" . $row['title'] . "</h1>";
			echo "<img src=".$row['image'].">" ;
			echo "<div id=\"price\"> €" . $row['price'] . "</div>";
			echo "<p> " .$row['description'] . "</p>";
			echo "Auction created by " . $row['username'] . ".";
		echo "</div>";
	}
	
}

catch(PDOException $e)
{
	$e->getMessage();
}
?>
</div>		
<?php include "includes/footer.php" ?>