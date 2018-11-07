var loadFile = function(event) 
{
	var currentProfPic = document.getElementById('currentProfilePic');
	currentProfPic.style.display='none';
	
	var newProfPic = document.getElementById('newProfilePic');
	newProfPic.style.display='inline';
	
    var output = document.getElementById('newProfilePic');
    output.src = URL.createObjectURL(event.target.files[0]);
};