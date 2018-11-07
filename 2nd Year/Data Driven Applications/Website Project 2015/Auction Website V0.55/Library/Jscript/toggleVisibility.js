function toggleVisibility(id) //Toggles visibility of a div
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
