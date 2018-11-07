<?php include "library/header.php" ?>	
	<main>	
		<section class="rowContainer">	
				<div class="rowContainer">
						<?php 
						if(isset($_SESSION['userID']))
						{
							echo "<h2>You are logged in as User ID: " . $_SESSION['userID'] . "</h2>";
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
