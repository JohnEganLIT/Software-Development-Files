window.onload = function() 
{
	document.getElementById("pass1").onchange = validatePassword;
	document.getElementById("pass2").onchange = validatePassword;
}
	
function validatePassword()//Makes sure password and confirm password are the same
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