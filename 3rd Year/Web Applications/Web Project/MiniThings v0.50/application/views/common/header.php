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
	 				echo '<div id="search">';		
					echo form_open('products_controller/search_products'); 

					echo form_input(array('id' => 'search_box', 'name' => 'search', 'type' => 'text', 'placeholder' => 'Search'));
					
					echo form_submit(array('id' => 'search_btn', 'value' => 'Search'));

					echo form_close(); 
					?>		
					</div>
		            <div class="header_right">
			            <?php	
			            	if($this->session->userdata('admin_id'))
			            	{
			            		echo 'logged in as Admin';
			            		echo '<div id="logout_btn"><a href="<?php echo base_url("index.php/accounts_controller/logout_user"); ?>">(Logout)</a></div>';
			            	}      

			            	if($this->session->userdata('customer_id'))
							{	

								$this->db->select('product_id');
						        $this->db->from('wishlist');
						        $this->db->where('customer_id', $this->session->userdata('customer_id'));
						        $query = $this->db->get();

			        			$wishlist_size = count($query->result_array());
						?>

								<div id="wishlist_header">
									<?php echo '<a href="' . base_url("index.php/products_controller/products_wishlist")  . '">Wishlist(' . $wishlist_size . ')</a>'; ?>
								</div>
			            		
			            		<div id="email_header"><?php echo $this->session->userdata('email');?></div>
			            		<div id="logout_btn"><a href="<?php echo base_url("index.php/accounts_controller/logout_user"); ?>">(Logout)</a></div>
			            <?php
							}

							else
							{
								echo '<div id="header_login">';	
								echo '<a href="' . base_url() . "index.php/accounts_controller/login" . '">Login/Create Account</a>';	
								echo '</div>';								
							}
			            ?>
			          	</div> 		
					<div class="clearfix"></div>	
	        	</div>

	        	<?php
	        		$this->db->select('*');
			        $this->db->from('categories');
			        $query = $this->db->get();

        			$data['categories'] = $query->result_array();

        			echo '<ul class="megamenu skyblue">';
        			//echo '<li class="grid">';
        			
        			foreach($data['categories'] as &$row)
        			{
        				$url = 'index.php/products_controller/products_by_category?category=' . $row['category_name'] . '"';
						echo '<li><a class="color1" href="' . base_url($url); 
						echo '>' . $row['category_name'] . '</a></li>';
        			}

        			echo '</ul>';
	        	?>
				
			</div>
		</div>
	</div>
        
    