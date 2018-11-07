<?php
echo '<link href="' . base_url() . 'assets/css/style.css" rel="stylesheet" type="text/css" />';

$total_price = 0;

foreach ($this->cart->contents() as $item)
{
    echo '<div id="order_item">';
    echo $item['name'] . "</br>";
    echo '<div class="order_image">' . $item['image'] . '</div><br>';
    echo form_open('products_controller/order_quantity'); 
		echo form_hidden('rowid', $item['rowid']);
		echo 'Quantity: ' . form_input(array('id' => 'order_quantity_box', 'name' => 'quantity', 'type' => 'text', 'value' => $item['qty']));
		echo form_submit(array('class' => 'quantity_btn', 'value' => 'Update'));
	echo form_close(); 

    echo '<br><div class="cart_price">' . '€' . $item['price'] * $item['qty'] . '</div></br>';
    $total_price += $item['price'] * $item['qty'];

    $url = "index.php/products_controller/remove_from_order?rowid=" . $item['rowid'] . '"';
    echo '<div id="remove_order_btn"><a href="' . base_url($url) . '>[X]Remove Item</a></div>';
    echo '</div>';
    echo '<hr>';
}

echo '<span id="total_price">Total Price: €' . $total_price . '</div>';

echo form_open('products_controller/checkout'); 
	echo form_submit(array('id' => 'pay_btn', 'value' => 'Pay'));
echo form_close(); 