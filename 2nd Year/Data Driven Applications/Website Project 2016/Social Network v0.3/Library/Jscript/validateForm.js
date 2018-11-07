window.onload = function() 
{
	document.getElementById("pass1").onchange = validatePassword;
	document.getElementById("pass2").onchange = validatePassword;
	document.getElementById("email1").onchange = validateEmail;
	document.getElementById("email2").onchange = validateEmail;
}
	
function validatePassword()//Checks if password and re-type password are the same
{
	var pass1=document.getElementById("pass1").value;
	var pass2=document.getElementById("pass2").value;
	
	if(pass1 != pass2)
	{
		document.getElementById("pass2").setCustomValidity("Passwords Don't Match");
	}
		
	else
	{
		document.getElementById("pass2").setCustomValidity('');
	}		
}

function validateEmail()//Checks email and re-type email are the same
{
	var email1=document.getElementById("email1").value;
	var email2=document.getElementById("email2").value;

	if(email1 != email2)
	{
		document.getElementById("email2").setCustomValidity("Emails Don't Match");
	}
		
	else
	{
		document.getElementById("email2").setCustomValidity('');
	}		
}