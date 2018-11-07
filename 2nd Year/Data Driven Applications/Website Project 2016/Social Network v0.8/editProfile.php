<?php include "library/header.php" ?>	
	<main>	
	<?php 
	if(isset($_POST['profileInfo']))
	{	
		try
		{
			$sql = 'UPDATE profile SET description = :description, origFrom = :origFrom, lives = :lives, relationship = :relationship WHERE profileID = :profileID';
			$stmt = $conn->prepare($sql); 
			$stmt->bindParam(':description', $_POST['profDesc']);
			$stmt->bindParam(':origFrom', $_POST['profFrom']);
			$stmt->bindParam(':lives', $_POST['profLive']);
			$stmt->bindParam(':relationship', $_POST['profRelationship']);
			$stmt->bindParam(':profileID', $_SESSION['userID']);
			$stmt->execute(); 
		}
		catch(PDOException $e)
		{
			$_SESSION['statusBad'] = 'Error Inserting data into database';
			$_SESSION['debug'] = $e->getMessage();
		}
		
	} 
	
	if(isset($_POST['profPicForm']))
	{
		//process image upload code here
	}
	
	?>
		<section class="rowContainer">	
			<form id="profPicForm" name="uploadProfPic" method="post" action="<?php echo $_SERVER['PHP_SELF'];?>">	
				<h2>Upload Profile Picture</h2>
				<?php echo '<img src="' . getProfilePic($_SESSION['userID']) . '" id="profilePic" alt="My Profile Picture">' ;?>
				<input id="chooseFileBtn" type="file" name="profilePicUpload" id="profilePicUpload" required />
				
				<input id="profPicSaveBtn" name="profileInfo" type="submit" value="Save" name="submit" />
			</form>
			<form id="editProfForm" method="post" action="<?php echo $_SERVER['PHP_SELF'];?>">		
				<h2>Tell us about yourself</h2>
				<label>Name</label>
				<input name="firstName" id="profName" type="text"  minlength="" value="<?php echo getFirstName($_SESSION['userID']);  ?>" />	
				<input name="lastName" id="profName" type="text"  minlength="" value="<?php echo getLastName($_SESSION['userID']);  ?>" />	
				<label>Describe yourself</label>
				<textarea name="profDesc" id="profDesc" maxlength="250" type="text" rows="10" cols="35" value="<?php echo getProfileDesc($_SESSION['userID']); ?>"></textarea>
				<label>Where are you from?</label>
				<input name="profFrom" id="profFrom" type="text"  minlength="" value="<?php echo getProfileFrom($_SESSION['userID']);  ?>" />	
				<label>Where do you live?</label>
				<input name="profLive" id="profLive" type="text"  minlength="" value="<?php echo getProfileLives($_SESSION['userID']); ?>" />							
				<label>Relationship Status</label>
				<select id="profRelationship" name="profRelationship" >
					  <option selected value="">Private</option>
					  <option value="single">Single</option>
					  <option value="In a relationship">In a relationship</option>
					  <option value="It's complicated">It's complicated</option>
					  <option value="I occasionally hire ladys of the night">I occasionally hire ladys of the night</option>
					  <option value="Non Consensual Polygamist">Non Consensual Polygamist</option>
					  <option value="with Buckfast">with Buckfast</option>
					  <option value="with Mary Jane">with Mary Jane</option>
					  <option value="with my car">with my car</option>					  
				</select>
				<input id="editProfileBtn" type="submit" name="profileInfo" value="Save" />
			</form>		
		</section>
		<div class="rowContainer">
				<div id="status">
				<?php
					//Displays Login Errors/ Registration Success			
					echo '<div class="statusGood">';
						if(isset($_SESSION['statusGood']))
						{
							echo $_SESSION['statusGood'];
							unset($_SESSION['statusGood']);
						}		
					echo '</div>';
					
					echo '<div class="statusBad">';
						if(isset($_SESSION['statusBad']))
						{
							echo $_SESSION['statusBad'];
							unset($_SESSION['statusBad']);
						}		
					echo '</div>';
					?>
				</div>
			</div>
	</main>
<?php include "library/footer.php" ?>
