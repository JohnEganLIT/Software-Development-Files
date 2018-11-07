<html><head>
<title>PHP_SuperGlobal1</title>
</head>
<body>
<h1>Get the $_SERVER['REMOTE_ADDR']</h1>
<p>This code will display the IP address of the requesting BROWSER
<p>This can be a useful diagnostic tool.
<hr>

<h2>Output NOT Formatted</h2>
<p>Your computer IP is :<?php echo $_SERVER['REMOTE_ADDR'];?>

<hr>
<h2>OUTPUT with a bit of styling</h2>
<p>This is an example of how PHP can be combined with HTML code to achieve a formatted output.
<p style="font-size:18px">Your computer IP is :
<?php echo '<font color="red">'.$_SERVER['REMOTE_ADDR']."</font";?>
<hr>
</body>
</html> 
