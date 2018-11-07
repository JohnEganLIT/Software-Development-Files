<script type="text/javascript">
	function toggle_visibility(id) //Toggles visability of categories
	{
		var e = document.getElementById(id);
		if(e.style.display == 'block')
		{
			e.style.display = 'none';
		}
		
		else
		{
			e.style.display = 'block';
		}
	}
	
	window.onload = function() 
	{
		document.getElementById("pass1").onchange = validatePassword;
		document.getElementById("pass2").onchange = validatePassword;
	}
	
	function validatePassword()
	{
		var pass2=document.getElementById("pass2").value;
		var pass1=document.getElementById("pass1").value;
	
		if(pass1 != pass2)
		{
			document.getElementById("pass2").setCustomValidity("Passwords Don't Match");
		}
			
		else
		{
			document.getElementById("pass2").setCustomValidity('');
		}		
	}
</script>