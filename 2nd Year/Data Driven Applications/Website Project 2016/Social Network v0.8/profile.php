<?php include "library/header.php" ?>	
	<main>	
		<section class="rowContainer">	
				<div class="rowContainer">
						<?php 
						if(isset($_SESSION['userID']))
						{
							
							echo '<img src="' . getProfilePic($_SESSION['userID']) . '" id="profilePic" alt="My Profile Picture">';
							echo '<div id="profileInfo">';
								
								echo '<h1>' . getfirstName($_SESSION['userID']) . ' ' . getLastName($_SESSION['userID']) . '</h1>';	
								echo '<a href="editProfile.php" id="editProfBtn">Edit Profile</a>';
								
								if(getProfileDesc($_SESSION['userID']) != "")
								echo '<p id="description">' . getProfileDesc($_SESSION['userID']) . '</p>';
							
								if(getProfileLives($_SESSION['userID']) != "")
								echo '<p><b>Relationship Status</b>: ' . getProfileRelationship($_SESSION['userID']) . '</p>';
								
								$originalDate = DateTime::createFromFormat('Y-m-d', getDOB($_SESSION['userID']));
								$newDate = $originalDate->format('d-m-Y'); //Switches date format from Y-M-D to D-M-Y							
								
								echo '<p><b>DOB:</b> ' . $newDate . '</p>';
								
								if(getProfileFrom($_SESSION['userID']) != "")
								echo '<br><p>From ' . getProfileFrom($_SESSION['userID']) . '</p>';
								
								if(getProfileLives($_SESSION['userID']) != "")
								echo '<p>Lives in ' . getProfileLives($_SESSION['userID']) . '</p>'; 					
							
							echo '</div>';			
						?>
				</div>
				<div class="rowContainer">
							<form id="statusForm" name="statusForm" method="post" action="<?php echo $_SERVER['PHP_SELF'];?>">		
								<textarea rows="8" cols="40" name="email" type="text" maxlength="40" placeholder="Enter Status" required ></textarea>		
								
								<input id="statusBtn" type="submit" name="status" value="Post" />
							</form>
						</div>
						<?php
						}
						
						else
						{
							header('location: index.php');
						}
						?>
				</div>
		</section>
	</main>
<?php include "library/footer.php" ?>
