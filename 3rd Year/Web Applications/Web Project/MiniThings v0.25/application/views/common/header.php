<html>
    <head>
        <title>Mini Things</title>
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <meta name="keywords" content="Miniature Toys, toy cars, toy planes, toy ships, toy planes, toy motorcycles" />
        <?php 
        echo '<link href="' . base_url() . 'assets/css/style.css" rel="stylesheet" type="text/css" />';
        echo '<link href="' . base_url() . 'assets/css/bootstrap.css" rel="stylesheet" type="text/css" />';
        echo '<link href="' . base_url() . 'assets/css/megamenu.css" rel="stylesheet" type="text/css" media="all" />';
        ?>
        <!--web-fonts-->
	    <link href='//fonts.googleapis.com/css?family=Open+Sans:400,300,400italic,300italic,600,700' rel='stylesheet' type='text/css'>
	    <link href='//fonts.googleapis.com/css?family=Roboto+Slab:300,400,700' rel='stylesheet' type='text/css'>     	
    </head>
    <body>
	<!--header-->
	<div class="header_bg">
	   <div class="container">
	        <div class="header">
	            <div class="head-t">
	                <div class="logo">
	                    <?php echo '<a href="' . base_url() . '"><h1>Mini <span>Things</span></h1> </a>'; ?>
	                </div>      
	 				<?php
	 				echo '<div id="searchForm">';		
					echo form_open('searchController'); 

					echo form_input(array('class' => 'searchBox', 'name' => 'search', 'type' => 'text', 'placeholder' => 'Search'));
					
					echo form_submit(array('id' => 'searchBtn', 'value' => 'Search'));

					echo form_close(); 
					?>		
					</div>
		            <div class="header_right">
			            <?php	        				           
			            	if($this->session->userdata('id'))
							{	
								?>		
								<div class="cart box_1">
				                    <a href="checkout.html">
				                    <div class="total">
				                        <span class="simpleCart_total"></span> (<span id="simpleCart_quantity" class="simpleCart_quantity"></span> items)</div>
				                        <i class="glyphicon glyphicon-shopping-cart"></i></a>
				                    <p><a href="javascript:;" class="simpleCart_empty">Empty Cart</a></p>
				                    <div class="clearfix"> </div>
			            		</div>		
			            		<div id="headerEmail"><?php echo $this->session->userdata('email');?></div>
			            		<div id="logoutBtn"><a href="<?php echo base_url("index.php/loginController/logout"); ?>">(Logout)</a></div>
			            		<?php
							}

							else
							{
								echo '<div id="loginForm">';		
									echo form_open('loginController'); 

									echo form_input(array('class' => 'loginField', 'name' => 'email', 'type' => 'email', 'placeholder' => 'Email'));
									
									echo form_input(array('class' => 'loginField', 'name' => 'password', 'type' => 'password', 'placeholder' => '*********'));
									
									echo form_submit(array('id' => 'loginBtn', 'value' => 'Login'));

									echo form_close(); 
						
							}
			            ?>
			               		 
					</div>
					<div class="clearfix"></div>	
	        	</div>
				<!--start-header-menu-->
				<ul class="megamenu skyblue">
					<li class="grid">
					<a class="color2" href="<?php echo base_url("index.php/productsController/getProducts?category=Classic Cars"); ?>">Classic Cars</a></li>
					<li><a class="color7" href="<?php echo base_url("index.php/productsController/getProducts?category=Vintage Cars"); ?>">Vintage Cars</a>
					<li><a class="color4" href="<?php echo base_url("index.php/productsController/getProducts?category=Planes"); ?>">Planes</a></li>				
					<li><a class="color5" href="<?php echo base_url("index.php/productsController/getProducts?category=Trains"); ?>">Trains</a></li>
					<li><a class="color6" href="<?php echo base_url("index.php/productsController/getProducts?category=Motorcycles"); ?>">Motorcycles</a></li>
					<li><a class="color6" href="<?php echo base_url("index.php/productsController/getProducts?category=Ships"); ?>">Ships</a></li>				
					<li><a class="color7" href="<?php echo base_url("index.php/productsController/getProducts?category=Trucks and Buses"); ?>">Trucks & Buses</a></li>
				</ul>
			</div>
		</div>
	</div>
        
    