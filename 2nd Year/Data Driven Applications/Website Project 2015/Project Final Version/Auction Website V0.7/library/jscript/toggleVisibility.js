function toggleVisibility() //Toggles visibilty of loading animation in auction.php
{
   var e = document.getElementById("loader");
   var g = document.getElementById("auctionBtn");
   
   e.style.display = 'inline';
   g.style.display = 'none';
}