<?php

echo '<div id="cart_header"><a href="' . base_url("index.php/accounts_controller/control_panel") . '">Return to Control Panel</a></div>';

echo '<table border="1px">';
echo '<th>Order Date</th><th>Required Date</th><th>Shipped Date</th><th>Status<th>Comments</th><th>Customer ID</th>';
foreach($data as $order)
{
	echo form_open('products_controller/admin_orders'); 	
		echo '<tr>';
		echo form_hidden('order_id', $order['order_id']);
		echo '<td>' . form_input(array('name' => 'order_date', 'type' => 'text', 'value' => $order['order_date'], 'required'=>'required')). '</td>';
		echo '<td>' . form_input(array('name' => 'required_date', 'type' => 'text', 'value' => $order['required_date'])). '</td>';
		echo '<td>' . form_input(array('name' => 'shipped_date', 'type' => 'text', 'value' => $order['shipped_date'])). '</td>';
		echo '<td>' . form_input(array('name' => 'status', 'type' => 'text', 'value' => $order['status'], 'required'=>'required')). '</td>';
		echo '<td>' . form_input(array('name' => 'comments', 'type' => 'text', 'value' => $order['comments'])). '</td>';
		echo '<td>' . $order['customer_id'] . '</td>';

		$url = 'index.php/products_controller/delete_order?order_id=' . $order['order_id'] . '"';
		echo '<td><a class="color1" href="' . base_url($url) . '>Delete</a></td>'; 

		$url = 'index.php/products_controller/update_order?order_id=' . $order['order_id'] . '"';
		echo '<td>' . form_submit(array('value' => 'Update')) . '</td>'; 

		echo '</tr>';
	echo form_close(); 
}
echo '</table>';
