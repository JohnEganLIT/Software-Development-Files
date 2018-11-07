<?php include "library/header.php" ?>
	
	<div id="main">	
		<form id="regForm" method="post" autocomplete="off" action="<?php echo $_SERVER['PHP_SELF'];?>">
			<h3>Create Account</h3>
			<div><input name="firstName" type="text" maxlength="25" placeholder="First Name" required="true" /></div>	
			<div><input name="lastName" type="text" maxlength="25" placeholder="Last Name" required="true"  /></div>			
			<div><input name="email" type="email" maxlength="30" placeholder="Email" required="true"  /></div>		
			<div><input name="pass2" type="password" maxlength="20" placeholder="Password" required="true"  /></div>		
			<div><input name="pass1" type="password" maxlength="20" placeholder="Re-type Password" required="true"  /></div>
			
			<div><input type="submit" value="Register" onsubmit="" /></div>
		</form>
				
		<form id="loginForm" method="post" autocomplete="off" action="<?php echo $_SERVER['PHP_SELF'];?>">		
			<h3>Log In</h3>
			<div><input name="email" type="text" maxlength="25" placeholder="First Name" required="true"  /></div>	
			<div><input name="password" type="text" maxlength="25" placeholder="Last Name" required="true"  /></div>				
			
			<div><input type="submit" value="Log In" onsubmit="" /></div>
		</form>
	</div>
	
<?php include "library/footer.php" ?>
