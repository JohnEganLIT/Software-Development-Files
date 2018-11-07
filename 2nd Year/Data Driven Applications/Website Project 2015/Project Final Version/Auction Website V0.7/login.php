<?php include "includes/header.php" ?>		
<div class="main container">
	<form id="loginForm" action="library/loginScript.php" method="POST">
		<fieldset>
			<legend>Login</legend>
			
			<label>Username</label>
			<input name="username" class="inputField" type="text" maxlength="25" required />
			
			<label>Password</label>
			<input name="pass" class="inputField" type="password" maxlength="30" required />
			
			<input id="loginBtn" type="submit" value="Sign In"/>
		</fieldset>
		<?php
		//Outputs status sent from loginScript.php
		echo '<div class="statusGood">';
			if(isset($_SESSION['statusGood']))
			{
				echo $_SESSION['statusGood'];
				unset($_SESSION['statusGood']);
				unset($_SESSION['statusBad']);
			}	
		echo '</div>';
		
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