<?php include "library/header.php" ?>	
	<main>
	<?php 
	if(isset($_POST['search']))
	{
		try
		{
			$sql = 'SELECT userID, firstName, lastName FROM users /*WHERE firstName REGEXP :search*/';
			$stmt = $conn->prepare($sql);
			$stmt->bindParam(':search', $_POST['searchTerm']);
			//$stmt->bindParam(':search', $_POST['search']);
			$stmt->execute(); //Finds users matching search criteria 			
			
			while($result = $stmt->fetch())
			{
				echo '<div id="searchResult">'; 
					echo '<a href="profile.php?userID='. $result['userID'] . '"/><img id="searchResultPic" src="' . getProfPic($result['userID']) . '">';
					echo '<h2 id="searchResultName">' . $result['firstName'] . " " . $result['lastName'] . '</h2>'; 
					echo '<p id="searchResultDesc">' . getProfDesc($result['userID']) . '</p>';
					echo '<p id="searchResultDOB">DOB: ' . getDOB($result['userID']) . '</p>';
					
					//if(getProfFrom($result['userID']) != "")
					//echo '<p id="searchResultFrom">From ' . getProfFrom($result['userID']) . '</p>';
				
					if(getProfRelationship($result['userID']) != "Private")
					echo '<p id="searchResultRelationship">Relationship Status: ' . getProfRelationship($result['userID']) . '</p>';
				
					if(getProfLives($result['userID']) != "") 
					echo '<p id="searchResultLives">Lives in ' . getProfLives($result['userID']) . '</p>';
					
				echo '</div>';
			}			
		}
		
		catch(PDOException $e)
		{
			$_SESSION['debug'] = $e->getMessage();
		}		
	}
	?>
	
		<section class="rowContainer">
			
		</section>
	</main>
<?php include "library/footer.php" ?>
