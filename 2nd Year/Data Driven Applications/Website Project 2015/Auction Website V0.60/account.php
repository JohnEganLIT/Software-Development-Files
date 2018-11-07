<?php include 'includes/header.php'?>
<div class="main container">
<script src="library/jscript/toggleInput.js"></script>
	<?php
		try
		{
			//Admin Control Panel
			if($_SESSION['user'] == "admin")
			{	
				$sql = 'SELECT * FROM users';
				$stmt = $conn->prepare($sql);
				$stmt->execute();
				
				echo '<div id="adminForm">';
				echo '<table>';
				echo '<tr><th>ID</th><th>Username</th><th>password</th><th>email</th><tr>';
			
				while($row = $stmt->fetch())
				{
					echo '<tr><td>' . $row['id'] . '</td><td>' . $row['username'] . '</td><td>' . $row['password'] . '</td><td>' . $row['email'] . '</td>';
					echo '<td>edit</td>';
					echo '<form name="deleteForm" action="library/deleteScript.php" method="POST">';
					echo '<input type="hidden" name="id" value="' . $row['id'] . '">';
					echo '<td><button name="deleteBtn" type="submit" id="deleteBtn" class="button">x</a></td></tr>';
					echo '</form>';
				}
				echo '</table>';
				echo '</div>';	
			}
			
			//User Account Information
			elseif(isset($_SESSION['user'])) 
			{
				$sql = 'SELECT * FROM users WHERE username = :username';
				$stmt = $conn->prepare($sql);
				$stmt->bindParam(':username', $_SESSION['user']);
				$stmt->execute();
				
				echo '<form name="editForm" id="editForm" class="button" action="library/editScript.php" method="POST">';
				while($row = $stmt->fetch())
				{
					echo 
					'<div class="account">
						<table>
							<legend>Account Details</legend>
								<form name="editAccount" method="POST" action="library/editScript.php">
								    <tr><td class="col1">Username:</td><td class="col2">' . $row['username'] . '</td><td class="col3"><input type="text" id="editUser" value="' . $row['username'] . '" minlength="5" maxlength="15" disabled required/></td></tr>
								    <tr><td class="col1">Password:<td class="col2">' . $row['password'] . '</td><td class="col3"><input type="text" id="editPass" value="' . $row['password'] . '" minlength="5" maxlength="15" disabled required/></td></tr>
								    <tr><td class="col1">Email:</td><td class="col2">' . $row['email'] . '</td><td class="col3"><input type="text" id="editEmail" value="' . $row['email'] . '" minlength="5" maxlength="15" disabled required/></td></tr>
								    <input type="hidden" value="' . $row['id']. '">
									<tr><td class="col1"></td><td class="col2"></td><td class="col3"><input type="button" value="Edit" class="accountBtn button" onclick="toggleInput1()"><input type="submit" value="Save" class="accountBtn button"></td></tr>
							  </form>
						</table>
					</div>
					
					<div class="account">
						<table> 
							<legend>Delivery Information</legend>
							    <form name="editAddress" method="POST" action="library/editScript.php">
							        <tr><td class="col1">Address1:</td><td class="col2">' . $row['address1'] . '</td><td class="col3"><input type="text" id="editAddress1" value="' . $row['address1'] . '" minlength="5" maxlength="15" disabled required/></td></tr>
							        <tr><td class="col1">Address2:<td class="col2">' . $row['address2'] . '</td><td class="col3"><input type="text" id="editAddress2" value="' . $row['address2'] . '" minlength="5" maxlength="15" disabled required/></td></tr>
							        <tr><td class="col1">Town:</td><td class="col2">' . $row['town'] . '</td><td class="col3"><input type="text" id="editTown" value="' . $row['town'] . '" minlength="5" maxlength="15" disabled required/></td></tr>
							        <tr><td class="col1">County:</td><td class="col2">' . $row['county'] . '</td><td class="col3"><input type="text" id="editCounty" value="' . $row['county'] . '" minlength="5" maxlength="15" disabled required/></td></tr>
							        <input type="hidden" value="' . $row['id']. '">
								    <tr><td class="col1"></td><td class="col2"></td><td class="col3"><input type="button" value="Edit" class="accountBtn button" onclick="toggleInput2()"><input type="submit" value="Save" class="accountBtn button"></td></tr>
								</form>
						</table>
					</div>
					
					<div class="account">
						<table> 
							<legend>Change Password</legend>
							  <form name="editPass" method="POST" action="library/editScript.php">
									<tr><td class="passCol1">Password:</td><td class="passCol2"><input type="password" name="pass1" minlength="5" maxlength="20" required/></td></tr>
									<tr><td class="passCol1">Confirm Password:</td><td class="passCol2"><input type="password" name="pass2" minlength="5" maxlength="20" required"/></td></tr>
									<input type="hidden" value="' . $row['id']. '">
									<tr><td></td><td><input class="accountBtn button" type="submit" name="submit" class="button" value="Change" /></td></tr>
							</form>
						</table>
					</div>
					
					<div class="account">
						<legend>Your Auctions</legend>
						<p>Function Coming Soon</p>
					</div>';
				}
			}
			
			else
			{
					echo "<h1>Acess Denied</h1>";
			}
		}
		catch(PDOException $e)
		{
			echo 'Error retrieving data: ' . $e->getMessage();
		}
	?>
</div>
<?php include 'includes/footer.php'?>