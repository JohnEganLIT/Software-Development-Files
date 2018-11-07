<?php 
include "includes/header.php";
access(); //Prevents access if not logged in.
?>		
<div class="main container">
	<script src="library/jscript/toggleInput.js"></script> <!-- Toggles input for form fields -->
	<script src="library/jscript/validatePassword.js"></script> <!-- Makes sure pass1 and pass2 are the same -->
	
	<?php	
	$sql = 'SELECT * FROM users WHERE id = :id';
	$stmt = $conn->prepare($sql);
	$stmt->bindParam(':id', $_SESSION['id']);
	$stmt->execute(); //Selects row where id is equal to logged in id 
	
	while($row = $stmt->fetch()) //Gets all the information from $row
	{
		echo '<div class="accountContainer">'; //Outputs date, username and email. Creates form to edit username and email.
			echo '<form method="POST" action="library/accountScript.php">';
			echo '<table>';
				echo '<legend>Account Details</legend><hr>';
				echo '<div id="accDate"> Your account was created : ' . $row['date'] . '</div>';
				echo '<tr><th>Username:</th><td class="col2">' . $row['username'] . ' </td><td class="col3"><input type="text" name="username" id="user" class="inputField" value="' . $row['username'] . '" maxlength="25" disabled required /></td></tr>';
				echo '<tr><th>Email:</th><td class="col2">' . $row['email'] . '</td><td class="col3"><input type="text" name="email" id="email" class="inputField" value="' . $row['email'] . '" maxlength="40" disabled required /></td></tr>';
				echo '<input type="hidden" name="form" value="accDetails"/>';
				echo '<tr><td></td><td></td><td><input type="button" class="formBtn" value="Edit" onclick="toggleInput1()"><input type="submit" id="saveBtn1" class="formBtn" value="Save" disabled></td></tr>';
			echo '</table>';
			echo '</form>';
		echo '</div>';
		
		echo '<div class="accountContainer">'; //Outputs address1, address2, town and county. Creates form to edit your address.
			echo '<form method="POST" action="library/accountScript.php">';
			echo '<table>';
				echo '<legend>Delivery Address</legend><hr>';
				echo '<tr><th>Address1:</th><td class="col2">' . $row['address1'] . ' </td><td><input type="text" name="address1" id="address1" class="inputField" value="' . $row['address1'] . '" maxlength="30" disabled /></td></tr>';
				echo '<tr><th>Address2:</th><td class="col2">' . $row['address2'] . '</td><td><input type="text" name="address2" id="address2" class="inputField"value="' . $row['address2'] . '" maxlength="30" disabled /></td></tr>';
				echo '<tr><th>Town:</th><td class="col2">' . $row['town'] . ' </td><td><input type="text" name="town" id="town" class="inputField" value="' . $row['town'] . '" maxlength="30" disabled /></td></tr>';
				echo '<tr><th>County:</th><td class="col2">' . $row['county'] . '</td><td><input type="text" name="county" id="county" class="inputField" value="' . $row['county'] . '" maxlength="30" disabled /></td></tr>';
				echo '<input type="hidden" name="form" value="accAddress"/>';
				echo '<tr><td></td><td></td><td><input type="button" class="formBtn" value="Edit" onclick="toggleInput2()"><input type="submit" id="saveBtn2" class="formBtn" value="Save" disabled></td></tr>';
			echo '</table>';
			echo '</form>';
		echo '</div>';
	}
	
	echo '<div class="accountContainer">'; //Creates form to edit your password.
		echo '<form method="POST" action="library/accountScript.php">';
		echo '<table>';
			echo '<legend>Change Password</legend><hr>';
			echo '<tr><th>Password:</th><td class="col2"><input type="password" name="pass1" id="pass1" class="inputField" minlength="5" maxlength="30" required/></td></tr>';
			echo '<tr><th>Confirm Password:</th><td class="col2"><input type="password" name="pass2" id="pass2" class="inputField" minlength="5" maxlength="30" required/></td></tr>';
			echo '<input type="hidden" name="form" value="accPassword"/>';
			echo '<tr><td></td><td><input type="submit" class="formBtn" value="Save" onclick="validatePassword()"></td></tr>';
		echo '</table>';
		echo '</form>';
	echo '</div>';
	
	if($_SESSION['id'] == 1) //If Admin is logged in
	{
		echo '<hr>';
		$sql = 'SELECT * FROM users';
		$stmt = $conn->prepare($sql);
		$stmt->execute(); //Selects all rows in users table
		
		while($row = $stmt->fetch()) //Gets all the information from $row
		{
			echo '<div class="accountContainer">'; //Outputs date, username and email. Creates form to edit username and email.
				echo '<table>';
						echo '<legend>' . $row['username'] . '\'s Account || User id= ' . $row['id'] . '</legend><hr>';
						echo '<div id="accDate"> This account was created : ' . $row['date'] . '</div>';
						echo '<tr><th>Username:</th><td class="col2">' . $row['username'] . ' </td><td class="col3"></tr>';
						echo '<tr><th>Email:</th><td class="col2">' . $row['email'] . '</td><td class="col3"></tr>';
						echo '<tr><th>Address1:</th><td class="col2">' . $row['address1'] . ' </td></tr>';
						echo '<tr><th>Address2:</th><td class="col2">' . $row['address2'] . '</td></tr>';
						echo '<tr><th>Town:</th><td class="col2">' . $row['town'] . ' </td></tr>';
						echo '<tr><th>County:</th><td class="col2">' . $row['county'] . '</td></tr>';
				echo '</table>';
			echo '</div>';
		}
	}
	
	//Outputs status sent from accountScript.php
	echo '<div class="accountStatusGood">'; 
		if(isset($_SESSION['statusGood']))
		{
			echo $_SESSION['statusGood'];
			unset($_SESSION['statusGood']);
			unset($_SESSION['statusBad']);
		}		
	echo '</div>';
	
	echo '<div class="accountStatusBad">';
		if(isset($_SESSION['statusBad']))
		{
			echo $_SESSION['statusBad'];
			unset($_SESSION['statusBad']);
			unset($_SESSION['statusGood']);
		}		
	echo '</div>';
	?>	
</div>		
<?php include "includes/footer.php" ?>