<?php
include '../includes/connection.php'; //Connection Parameters 

$id = $_POST['id'];
$username = $_POST['username'];
$password = $_POST['password'];
$email = $_POST['email'];
$address1 = $_POST['address1'];
$address2 = $_POST['address2'];
$town = $_POST['town'];
$county = $_POST['county'];

$query3 = mysql_query("UPDATE users SET username='$username', password='$password', email='$email', 
address1='$address1', address2='$address2', town='$town', county'$county' WHERE userID='$userID'");

if($query3)
{
	header('location:../account.php');
}
	
	$query1=mysql_query("select * from users where userID='$userID'");
	$query2=mysql_fetch_array($query1);

?>

		<form action="SQL&PHP/register.php" method="POST">
			<tr>
				<td></td>
				<td><input type="text" name="user" required ="required" /></p></td>
				<td><input type="password" name="pass" required ="required" /></p></td>
				<td><input type="email" name="email" required ="required" /></p></td>
				<td><input type="text" name="address1" /></p></td>
				<td><input type="text" name="address2" /></p></td>
				<td><input type="text" name="town"  /></p></td>
				<td><input type="text" name="county" /></p></td>
				<td><input type="submit" name="submit" value="Register" /></td>	
			</tr>
		</form>
	</body>
</html>

