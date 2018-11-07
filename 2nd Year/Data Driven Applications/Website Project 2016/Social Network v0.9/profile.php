<?php include "library/header.php" ?>	
	<main>		
		<?php 
		if(isset($_GET['userID']))
		{
			$userID = $_GET['userID'];
		}
		
		elseif(isset($_SESSION['userID']))
		{
			$userID = $_SESSION['userID'];			
		}	
		
		else
		{
			header('location: index.php');
			exit();
		}
		
		echo '<div class="rowContainer">';
			echo '<img src="' . getProfPic($userID) . '" id="profilePic" alt="My Profile Picture">';
			
			echo '<div id="profileInfo">';
				
				echo '<h1>' . getfirstName($userID) . ' ' . getLastName($userID) . '</h1>';	
				
				if(getProfDesc($userID) != "")
				echo '<p id="description">' . getProfDesc($userID) . '</p>';
			
				echo '<p><b>DOB:</b> ' . getDOB($userID) . '</p><br>';
				
				if(getProfRelationship($userID) != "Private")
				echo '<p><b>Relationship Status</b>: ' . getProfRelationship($userID) . '</p>';							
				
				if(getProfFrom($userID) != "")
				echo '<br><p>From ' . getProfFrom($userID) . '</p>';
				
				if(getProfLives($userID) != "")
				echo '<p>Lives in ' . getProfLives($userID) . '</p>'; 
				
				try
				{
					$sql = 'SELECT friendID FROM friends WHERE userID = :userID';
					$stmt = $conn->prepare($sql); 
					$stmt->bindParam(':userID', $userID);
					$stmt->execute(); //Checks db for entered userID
					
					$result = $stmt->fetchAll();
				}
				
				catch(PDOException $e)
				{
					$_SESSION['debug'] = $e->getMessage();;
				}
				
				
			echo '</div>';	
			
				echo '<div id="friendList">';
					echo '<h2>Friends List('. count($result) . ')</h2>';
					foreach($result as $friend)
					{
						echo '<a href="profile.php?userID='. $friend['friendID'] . '"/><img id="friendListPic" src="' . getProfPic($friend['friendID']) . '" id="profilePic" title="' . getFirstName($friend['friendID']) . " " . getLastName($friend['friendID']) . '">';
					}
				echo '</div>';
			
			
		echo '</div>';
		?>
		<div class="rowContainer">
			<form id="statusForm" name="statusForm" method="post" action="<?php echo $_SERVER['PHP_SELF'];?>">		
				<textarea rows="8" cols="40" name="email" type="text" maxlength="40" placeholder="Enter Status" required ></textarea>		
				
				<input id="statusBtn" type="submit" name="status" value="Post" />
			</form>
		</div>		
	</main>
<?php include "library/footer.php" ?>
