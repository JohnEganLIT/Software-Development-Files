<?php 
include "includes/header.php";
access(); //Prevents access if not logged in
?>		
<div class="main container">
<script src="library/jscript/toggleVisibility.js"></script>
	<div id="auctionForm">
		<form action="library/auctionScript.php" method="POST" enctype="multipart/form-data" onsubmit="toggleVisibility()">
			<h1>Create Auction</h1>
			<hr>
			<label>Title</label>
			<input name="title" id="title" class="inputField" type="text" maxlength="20" required />
			<p>Max 20 characters</p>
			
			<label>Description</label>
			<textarea name="description" id="description" type="email" required maxlength="200"></textarea>
			<p>Max 200 characters</p>
			<label id="priceLabel">Price</label>
			<span id="euro">€</span><input name="price" id="price" class="inputField" type="number" required />
			
			<label>Category</label>
			<select name="category" id="category">
				<option value="laptops">Laptop</option>
				<option value="tablets">Tablet</option>
				<option value="desktops">Desktop</option>
				<option value="desktops">Smartphone</option>
				<option value="components">Component</option>
				<option value="peripherals">Peripheral</option>
				<option value="other">Other</option>
			</select>
			
			<label>Image</label>
			<input type="file" name="file" id="chooseFile" required/> 
			<p>Max image size = 5MB || 300x300 recommended || .jpg only</p>
			
			<div id="auctionBtn"><input type="submit" class="formBtn" value="Submit" name="submit" /></div>
			<div id="loader"></div>
		</form>	
    </div>
	
	<?php
	//Outputs status sent from auctionScript.php
	echo '<div class="auctionStatusGood">';
		if(isset($_SESSION['statusGood']))
		{
			echo $_SESSION['statusGood'];
			unset($_SESSION['statusGood']);
			unset($_SESSION['statusBad']);
		}	
	echo '</div>';
	
	echo '<div class="auctionStatusBad">';
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