<?php include "includes/header.php" ?>		
<div class="main container">	
<script src="library/jscript/validatePassword.js"></script>
	<form id="loginForm" action="library/registerScript.php" method="POST">
		<fieldset>
			<legend>Register</legend>
			
			<label>Username</label>
			<input name="username" class="inputField" type="text" maxlength="25" required />
			
			<label>Email</label>
			<input name="email" class="inputField" type="email" maxlength="40" required />
			
			<label>Password</label>
			<input name="pass1" id="pass1" class="inputField" type="password" maxlength="30"required />
			
			<label>Confirm Password</label>
			<input name="pass2" id="pass2" class="inputField" type="password" maxlength="30" required />
			
			<input id="loginBtn" type="submit" value="Register" onsubmit="validatePassword()"/>
		</fieldset>
		<?php
		echo '<div class="statusBad">';
			if(isset($_SESSION['statusBad']))
			{
				echo $_SESSION['statusBad'];
				unset($_SESSION['statusBad']);
				unset($_SESSION['statusGood']);
			}		
		echo '</div>';
		?>
	</form>
</div>		
<?php include "includes/footer.php" ?>	
