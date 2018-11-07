<?php 
include 'includes/config.php';
include 'includes/functions.php';
include 'includes/connection.php';
secureSession();
?>
<!DOCTYPE html>
<html>
<head>
	<title>Auction Website</title>
	<link rel="stylesheet" type="text/css" href="<?php echo style; ?>">
</head>
<body>
	<div id="wrapper">
		<div id="header">
			<?php include header ?>
		</div><!--End Header -->
		
		<div id="categories">
			<?php include categories ?>
		</div><!--End Categories -->
		
		<div class="container main">
			<?php 
			echo '<h1>' . $_SESSION['user'] . '\'s Account</h1>';
			$stmt = $conn->prepare("SELECT * FROM users"); //Uses PDO prepared statements to prevent sql injection
			
			$result = $stmt->fetchAll();
			
				echo "<tr><td id='idCell'>".$row['id']."</td>". "<td>".$row['username']."</td>". "<td>".$row['password']."</td>". "<td>".$row['email']."</td>"
				."<td>".$row['address1']."</td>". "<td>".$row['address2']."</td>". "<td>".$row['town']."</td>". "<td>".$row['county']."</td>";
				echo "<td><a href='SQL&PHP/edit.php?id=".$row['id']."'>Edit</a></td>";
				echo "<td><a href='SQL&PHP/delete.php?id=".$row['id']."'>x</a></td></tr>";
			
					
			?>
		</div><!-- End Main -->
		
		<div id="footer">
			<?php include footer ?>
		</div><!-- End Footer -->
	</div><!-- End Wrapper -->
</body>
</html>