<?php 
echo '<div id="cart_header"><a href="' . base_url("index.php/products_controller/admin_orders") . '">Return to Orders</a></div>';

echo '<table border="1px">';
echo '<th>Order ID</th><th>Product ID</th><th>Quantity Ordered</th><th>Price Each</th>';
foreach($data as $order)
{
	echo form_open('products_controller/update_order_details'); 	
		echo '<tr>';
		echo form_hidden('order_id', $order['order_id']);
		echo form_hidden('product_id', $order['product_id']);
		echo '<td>' . $order['order_id'] . '</td>';
		echo '<td>' . $order['product_id'] . '</td>';
		echo '<td>' . form_input(array('name' => 'quantity_ordered', 'type' => 'text', 'value' => $order['quantity_ordered'], 'required'=>'required')). '</td>';
		echo '<td>' . $order['price_each'] . '</td>';

		echo '<td>' . form_submit(array('value' => 'Update')) . '</td>'; 

		echo '</tr>';
	echo form_close(); 
}
echo '</table>';