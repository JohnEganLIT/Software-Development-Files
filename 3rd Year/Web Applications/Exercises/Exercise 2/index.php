<!DOCTYPE HTML>
<html>
	<head>
		<title>LIT Realty</title>	
		<link rel="stylesheet" href="style.css"/>
	</head>
	<body>
	<div id="header">
		<img src="litLogo.jpg" id="litLogo"/>
		<h1 id="headerTitle">LIT Realty</h1>
		<img src="litLogo.jpg" id="litLogo"/>
	</div>	
		
		<form id="searchForm" method="post" action="search.php">
			<p span id="searchCriteria">Please enter your search criteria</p>
			<label>Enter Property Location</label>
			<input id="location" name="location" type="text" id="inputField">

			<label>Enter Price Range</label>
			<select name="priceRange">
				<option value="any">Any</option>
				<option value="150">&#8364 150,000 - &#8364 200,000</option>
				<option value="200">&#8364 200,000 - &#8364 250,000</option>
				<option value="250">&#8364 300,000 - &#8364 350,000</option>
				<option value="300">&#8364 350,000 - &#8364 500,000</option>
			</select>
			
			<input id="submit" type="submit" value="Submit Order" id="submitBtn" />
		</form>
	</body>
</html>


