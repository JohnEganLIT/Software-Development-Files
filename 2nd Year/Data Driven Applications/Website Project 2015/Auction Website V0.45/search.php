<?php 
include 'includes/config.php';
include 'includes/connection.php';
include 'includes/functions.php';
secureSession();
?>
<!DOCTYPE html>
<html>
<head>
	<title>Auction Website</title>
	<link rel="stylesheet" type="text/css" href="<?php echo style; ?>">
</head>
<body>
	<div id="header">
		<?php include header ?>
	</div><!--End Header -->
	
	<div id="categories">
		<?php include categories; ?> 
	</div><!--End Categories -->
	
	<div class="container main">
		<h1> Search function coming soon..... Probably </h1>
	</div><!-- End Main -->
	
	<div id="footer">
		<?php include footer; ?>
	</div><!-- End Footer -->
</body>
</html>