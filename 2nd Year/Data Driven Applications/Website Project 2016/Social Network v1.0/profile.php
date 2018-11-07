<?php include "library/header.php" ?>	
	<main>		
		<?php
		if(isset($_POST['addFriend']))
		{
			$otherUserID = $_POST['otherUserID'];
			$loggedInUserID = $_SESSION['userID'];
			
			try
			{
				$sql = 'INSERT INTO friends (friend1, friend2) VALUES (:userID, :otherUserID)';
		
				$stmt = $conn->prepare($sql); 
				$stmt->bindParam(':userID', $_SESSION['userID']);
				$stmt->bindParam(':otherUserID', $_GET['userID']);
				$stmt->execute(); 						
			}
				
			catch(PDOException $e)
			{
				$_SESSION['debug'] = $e->getMessage();
			}
			
			header('Location: '. $_SERVER['REQUEST_URI']);
			exit();
		}
		
		if(isset($_POST['removeFriend']))
		{
			
			$otherUserID = $_POST['otherUserID'];
			$loggedInUserID = $_SESSION['userID'];
			
			echo $otherUserID . "<br>";
			echo $loggedInUserID;
			
			
			try
			{
				$sql = 'DELETE FROM friends WHERE (friend1 = :userID AND friend2 = :otherUserID) OR (friend2 = :userID AND friend1 = :otherUserID)';
			
				$stmt = $conn->prepare($sql); 
				$stmt->bindParam(':userID', $_SESSION['userID']);
				$stmt->bindParam(':otherUserID', $_GET['userID']);
				$stmt->execute();  
			
			}
			
			catch(PDOException $e)
			{
				$_SESSION['debug'] = $e->getMessage();
			}
			
			header('Location: '. $_SERVER['REQUEST_URI']);
			exit();
			
		}
		
		if(isset($_SESSION['userID']))
		{
			if(isset($_GET['userID']))
			{
				$userID = $_GET['userID'];
			}
			
			else
			{
				$userID = $_SESSION['userID'];	
			}
				
			echo '<div class="container">';
				echo '<div id="profCol">';
				
					echo '<img src="' . getProfPic($userID) . '" id="profPic" alt="My Profile Picture">';
				
					echo '<div id="profInfo">';
						if(getProfDesc($userID) != "")
						echo '<p id="profDesc">' . getProfDesc($userID) . '</p>';
					
						echo '<p id="profDOB"><strong>DOB:</strong> ' . getDOB($userID) . '</p>';						
						
						if(getProfRelationship($userID) != "Private")
						echo '<p id="profRel"><strong>Relationship Status</strong>: ' . getProfRelationship($userID) . '</p>';
					
						if(getProfFrom($userID) != "")
						echo '<p id="profFrom"><strong>From:</strong> ' . getProfFrom($userID) . '</p>';
							
						if(getProfLives($userID) != "")
						echo '<p id="profLives"><strong>Lives:</strong> ' . getProfLives($userID) . '</p>'; 
				
					echo '</div>';
				
					echo '<div id="profFriendList">';
					
						if(isset($_GET['userID']))
							$friends = findFriends($userID, $_GET['userID']);
						else
							$friends = findFriends($userID, 0);
						
						if(count($friends) > 0)
						{
							echo '<h2>Friends('. count($friends) . ')</h2>';
							foreach($friends as $friend)
							{
								echo '<a href="profile.php?userID='. $friend . '"><img id="profFriendListPic" src="' . getProfPic($friend) . '" id="profilePic" title="' . getFirstName($friend) . " " . getLastName($friend) . '"/></a>';
							}
						}
						
						else
						{
							echo getFirstName($userID) . ' does not have any friends yet :(';
						}

					echo '</div>';
				echo '</div>';
				
				
						
				echo '<div id="profNameFriendStatus">';
							
					echo '<h1 id="profName">' . getfirstName($userID) . ' ' . getLastName($userID) . '</h1>';
					
					
					if(isset($_GET['userID']))
					{
						try
						{
							$sql = 'SELECT friend1, friend2 FROM friends WHERE (friend1 = :userID AND friend2 = :otherUserID) OR (friend2 = :userID AND friend1 = :otherUserID)';
					
							$stmt = $conn->prepare($sql); 
							$stmt->bindParam(':userID', $_SESSION['userID']);
							$stmt->bindParam(':otherUserID', $_GET['userID']);
							$stmt->execute(); 
							
							$result = $stmt->fetch();
										
							if($result['friend1'] == $_SESSION['userID'])
									$otherUserID = $result['friend1'];
							else
									$otherUserID = $result['friend2'];
							
							if($result)
							{
								echo '<form id="friendStatusBox" action="'. $_SERVER['REQUEST_URI'] .'" method="post" >';
									echo '<input type="hidden" name="otherUserID" value="'.$otherUserID.'" >';
									echo '<input type="image" name="removeFriend" id="friendStatusPic" value="submit" src="design/friends.jpg"/>';
									echo '<input type="image" name="removeFriend" id="friendStatusPicRemove" value="submit" src="design/unfriend.jpg"/>';
								echo '</form>';
							}
							
							else
							{
								echo '<form id="friendStatusBoxNotFriends" action="'. $_SERVER['REQUEST_URI'] .'" method="post" >';
									echo '<input type="hidden" name="otherUserID" value="'.$otherUserID.'" >';
									echo '<input type="image" name="addFriend" id="friendStatusPicAdd" value="submit" src="design/notfriends.jpg"/>';
								echo '</form>';			
							}
						}
						catch(PDOException $e)
						{
							$_SESSION['debug'] = $e->getMessage();
						}
					}
				echo '</div>';
				
				echo '<form id="statusForm" name="statusForm" method="post" action="' . $_SERVER['PHP_SELF'] . '">';		
					echo '<textarea rows="8" cols="40" name="email" type="text" maxlength="40" placeholder="Enter Status" required ></textarea>';	
					echo '<br>';
					echo '<input id="statusBtn" type="submit" name="status" value="Post" />';
				echo '</form>';		
					
			echo '</div>';
			
		}			
		?>
		
	</main>
<?php include "library/footer.php" ?>
