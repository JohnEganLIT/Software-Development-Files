<div class="container">
<div class="main">
<div id="products">
    <?php   
    //echo '<span class="list_product_heading">
    for($i=0; $i<count($products); $i++)
    {
    	$url = 'index.php/products_controller/product_by_id?product_id=' . $products[$i]['product_id'] . '"';
    	echo '<a href="' . base_url($url) . '">';
    	echo '<div class="list_product">';
	    	echo '<span class="list_product_name">' . $products[$i]['product_name'] . '</span>';
	    	echo '<span class="list_product_msrp">' . $products[$i]['msrp'] . '</span>';
	    	echo '<span class="list_product_image">' . $products[$i]['image'] . '</span>';
    	echo '</div>';
    	echo '</a>';
    }
    ?>
</div>
</div>
</div>