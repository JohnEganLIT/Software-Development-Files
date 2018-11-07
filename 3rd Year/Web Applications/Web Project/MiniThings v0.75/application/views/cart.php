<div class="main">
<div class="cart">
<?php
	foreach ($this->cart->contents() as $item)
	{
		echo '<div class="cart_item">';
			echo $item['name'] . "</br>";
			echo '<div class="cart_image">' . $item['image'] . '</div>';
			
			echo form_open('products_controller/cart_quantity'); 
				echo form_hidden('rowid', $item['rowid']);
				echo 'Quantity: ' . form_input(array('class' => 'quantity_box', 'name' => 'quantity', 'type' => 'text', 'value' => $item['qty']));
				echo form_submit(array('class' => 'quantity_btn', 'value' => 'Update'));
			echo form_close(); 

			echo '<div class="cart_price">' . '€' . $item['price'] * $item['qty'] . '</div></br>';

			$url = "index.php/products_controller/remove_from_cart?rowid=" . $item['rowid'] . '"';
            echo '<div class="remove_cart_btn"><a href="' . base_url($url) . '>[X]Remove Item</a></div>';
		echo '</div>';
	}

	if($this->cart->contents())
	{
		echo form_open('products_controller/cart_order'); 
			echo form_submit(array('id' => 'cart_order_btn', 'value' => 'Order'));
		echo form_close(); 
	}

	else
	{
		echo '<div id="empty_cart_msg">Cart is empty</div>';
	}
?>
</div>
</div>