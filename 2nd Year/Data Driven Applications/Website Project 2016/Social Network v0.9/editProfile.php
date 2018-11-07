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
		$info = pathinfo($_FILES['profPic']['name']); 
		
		$newname = "profilePic." . ".jpg"; //Renames file to profilePic.jpg

		$target = 'images/' . $_SESSION['userID'] . '/' . $newname;
		
		unlink("images/" . $_SESSION['userID'] . "profilePic.jpg"); //Deletes old profile picture
		
		move_uploaded_file( $_FILES['profPic']['tmp_name'], $target); //Places image in users picture 
			
		try
		{
			$sql = 'UPDATE profile SET profilePic = :profilePic WHERE profileID = :profileID';
			
			$stmt = $conn->prepare($sql); 
			
			$stmt->bindParam(':profilePic', $target);
			$stmt->bindParam(':profileID', $_SESSION['userID']);
			$stmt->execute(); 
			
			$result = $stmt->fetch();
			
			$_SERVER['PHP_SELF'];
		}
		catch(PDOException $e)
		{
			$_SESSION['error'] = $e;
		}
	}	
	?>
		
		<script src="library/jscript/profPicChange.js"></script> <!--- Javascript Changes Image on Change --->
		
		<section class="rowContainer">	
			<form id="profPicForm" method="post" enctype="multipart/form-data" action="<?php echo $_SERVER['PHP_SELF'];?>">	
				<h2>Upload Profile Picture</h2>
				<?php echo '<img src="' . getProfPic($_SESSION['userID']) . '" id="currentProfilePic" alt="My Profile Picture">' ;?>
				<img id="newProfilePic" />
				<input id="chooseFileBtn" type="file" name="profPic" id="profilePicUpload" onchange="loadFile(event)"required />
				
				<input id="profPicSaveBtn" name="profPicForm" type="submit" value="Save"  />
			</form>
			<form id="editProfForm" method="post" action="<?php echo $_SERVER['PHP_SELF'];?>">		
				<h2>Tell us about yourself</h2>
				<label>Name</label>
				<input name="firstName" id="profName" type="text"  minlength="" value="<?php echo getFirstName($_SESSION['userID']);  ?>" />	
				<input name="lastName" id="profName" type="text"  minlength="" value="<?php echo getLastName($_SESSION['userID']);  ?>" />	
				<label>Describe yourself</label>
				<textarea name="profDesc" id="profDesc" maxlength="250" type="text" rows="10" cols="35"  ><?php echo getProfDesc($_SESSION['userID']); ?> </textarea>
				<label>Where are you from?</label>
				<input name="profFrom" id="profFrom" type="text"  minlength="" value="<?php echo getProfFrom($_SESSION['userID']);  ?>" />	
				<label>Where do you live?</label>
				<input name="profLive" id="profLive" type="text"  minlength="" value="<?php echo getProfLives($_SESSION['userID']); ?>" />							
				
				<label>Relationship Status</label>
				<select id="profRelationship" name="profRelationship" />
					<?php 
					$currentValue = getProfRelationship($_SESSION['userID']);
					  
					echo '<option selected value="">' . $currentValue  . '</option>';
					 
					if($currentValue != 'Private')
						echo '<option value="Private">Private</option>';
					
				    if($currentValue != 'Single')
						echo '<option value="Single">Single</option>';
					
					if($currentValue != 'In a relationship')
						echo '<option value="In a relationship">In a relationship</option>';
					
					if($currentValue != 'It\'s complicated')
						echo '<option value="It\'s complicated">It\'s complicated</option>';
					
					if($currentValue != 'I occasionally hire ladys of the night')
						echo '<option value="I occasionally hire ladys of the night">I occasionally hire ladys of the night</option>';
					
					if($currentValue != 'Non Consensual Polygamist')
						echo '<option value="Non Consensual Polygamist">Non Consensual Polygamist</option>';
					
					?>
				</select>
				
				<?php
					$date = getDOB($_SESSION['userID']);
					$date = explode('-', $date);
					
					$day = $date[0];
					$month = $date[1];
					$year = $date[2];
					
					if($month == 1)
						$month = 'January';
					if($month == 2)
						$month = 'February';
					if($month == 3)
						$month = 'March';
					if($month == 4)
						$month = 'April';
					if($month == 5)
						$month = 'May';
					if($month == 6)
						$month = 'June';
					if($month == 7)
						$month = 'July';
					if($month == 8)
						$month = 'August';
					if($month == 9)
						$month = 'September';
					if($month == 10)
						$month = 'October';
					if($month == 11)
						$month = 'November';
					if($month == 12)
						$month = 'December';
										
					
				?>
				
				<div id="birthday">
					<label> Date of Birth </label>
					
					<select id="day" name="birthDay" >
						<option selected value="<?php echo $day ?>"><?php echo $day ?></option>
						<?php 
						for($i = 1; $i < 32; $i++)
						{
							echo "<option value=\"$i\">$i</option>";
						}
						?>
					</select>
					
					<select id="month" name="birthMonth" >
					  <option selected value="<?php echo $month ?>"><?php echo $month ?></option>
					  <option value="1">January</option>
					  <option value="2">February</option>
					  <option value="3">March</option>
					  <option value="4">April</option>
					  <option value="5">May</option>
					  <option value="6">June</option>
					  <option value="7">July</option>
					  <option value="8">August</option>
					  <option value="9">September</option>
					  <option value="10">October</option>
					  <option value="11">November</option>
					  <option value="12">December</option>
					</select>
					
					<select id="year" name="birthYear" >
					  <option selected value="<?php echo $year ?>"><?php echo $year ?></option>
						<?php 
						for($i = 2016; $i > 1915; $i--)
						{
							echo "<option value=\"$i\">$i</option>";
						}
						?>		  
					</select>
				</div>
				
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
