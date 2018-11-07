<?php include 'includes/header.php'?>
<div class="main container">
	<?php
		try
		{
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
			
			elseif(isset($_SESSION['user'])) 
			{
				$sql = 'SELECT * FROM users WHERE username = :username';
				$stmt = $conn->prepare($sql);
				$stmt->bindParam(':username', $_SESSION['user']);
				$stmt->execute();
				
				echo '<div id="userInfo">';
				echo '<table>';
				echo '<legend>Account Details</legend>';
				echo '<form name="editForm" id="editBtn" class="button" action="library/editScript.php" method="POST">';
				while($row = $stmt->fetch())
				{
					echo '<tr><td>ID</td><td>' . $row['id'] . '</td><td><input id="user" type="text" name="user" value="' . $row['id'] . '" minlength="5" maxlength="15" required/></td></tr>
						  <tr><td>Username</td><td>' . $row['username'] . '</td><td><input id="user" type="text" name="user" value="' . $row['username'] . '" minlength="5" maxlength="15" required/></td></tr>
						  <tr><td>Password<td>' . $row['password'] . '</td><td><input id="user" type="text" name="user" value="' . $row['password'] . '" minlength="5" maxlength="15" required/></td></tr>
						  <tr><td>Email</td><td>' . $row['email'] . '</td><td><input id="user" type="text" name="user" value="' . $row['email'] . '" minlength="5" maxlength="15" required/></td></tr>
						  <td>Address 1</td><td>' . $row['address1'] . '</td><td><input id="user" type="text" name="user" value="' . $row['address1'] . '" minlength="5" maxlength="15" required/></td></tr>
						  <td>Address2</td><td>'. $row['address2'] . '</td><td><input id="user" type="text" name="user" value="' . $row['address2'] . '" minlength="5" maxlength="15" required/></td></tr>
						  <td>Town</td><td>'. $row['town'] . '</td><td><input id="user" type="text" name="user" value="' . $row['town'] . '" minlength="5" maxlength="15" required/></td></tr>
						  <td>County</td><td>' . $row['county'] . '</td><td><input id="user" type="text" name="user" value="' . $row['county'] . '" minlength="5" maxlength="15" required/></td></tr>';
					
				}
				
			
				echo '<input type="hidden" name="id" value="' . $row['id'] . '">';
				echo '<tr><td></td><td></td><td><input type="submit" value="Edit" id="editBtn" class="button"></td></tr>';
				echo '</form>';
				echo '</table>';
				echo '</div>';
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