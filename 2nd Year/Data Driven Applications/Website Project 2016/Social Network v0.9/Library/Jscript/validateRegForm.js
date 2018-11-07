window.oninput = function()
{	
	document.getElementById("pass2").setCustomValidity("");
	document.getElementById("email2").setCustomValidity("");
	document.getElementById("birthDay").setCustomValidity("");
	document.getElementById("birthMonth").setCustomValidity("");
	document.getElementById("birthYear").setCustomValidity("");
}

function validateRegForm()
{	
	var pass1 = document.getElementById("pass1").value;
	var pass2 = document.getElementById("pass2").value;
	var email1 = document.getElementById("email1").value;
	var email2 = document.getElementById("email2").value;
	var birthDay = document.getElementById("birthDay").value;
	var birthMonth = document.getElementById("birthMonth").value;
	var birthYear = document.getElementById("birthYear").value;
	
	if(pass1 != pass2)
	{
		document.getElementById("pass2").setCustomValidity("Password's don't match!");
		return false;
	}
	
	if(email1 != email2)
	{	
		document.getElementById("email2").setCustomValidity("Email's don't match!");
		return false;
	}	
	
	if(birthDay == "")
	{	
		document.getElementById("birthDay").setCustomValidity("Please select a Day!");
		return false;
	}
	
	if(birthMonth == "")
	{
		document.getElementById("birthMonth").setCustomValidity("Please select a Month!");
		return false;
	}

	if(birthYear == "")
	{
		document.getElementById("birthYear").setCustomValidity("Please select a Year!");
		return false;
	}	
	
	return true;	
}

