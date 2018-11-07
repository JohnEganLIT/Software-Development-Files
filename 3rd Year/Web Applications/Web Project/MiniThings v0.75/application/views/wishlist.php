<div class="container">
<div class="main">
<div id="products">
    <?php   

    echo '<div class="wishlist_heading">' . $this->session->userdata('contact_first_name') . '\'s Wishlist</div>';
    for($i=0; $i<count($data); $i++)
    {
    	$url = 'index.php/products_controller/product_by_id?product_id=' . $data[$i]['product_id'] . '"';
    	echo '<a href="' . base_url($url) . '">';
    	echo '<div class="list_product">';
	    	echo '<span class="list_product_name">' . $data[$i]['product_name'] . '</span>';
	    	echo '<span class="list_product_msrp">' . $data[$i]['msrp'] . '</span>';
	    	echo '<span class="list_product_image">' . $data[$i]['image'] . '</span>';
    	echo '</div>';
    	echo '</a>';
    }
    ?>
</div>
</div>
</div>