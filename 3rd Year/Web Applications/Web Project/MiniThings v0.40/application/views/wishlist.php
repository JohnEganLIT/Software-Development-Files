<div class="container">
<div class="main">
<div id="products">
    <?php   
    $this->table->set_heading('');
 
    echo $this->table->generate($data);

    foreach($data as $row)
    {
    	echo $row['product_name'];
    	echo $row['msrp'];
    	echo $row['image'];
    }

    ?>
</div>
</div>
</div>