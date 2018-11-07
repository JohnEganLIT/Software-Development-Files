<div class="container">
<div class="main">
<?php

echo '<table id="customer_orders">';
echo '<th>Order ID</th><th>Order Date</th><th>Required Date</th><th>Shipped Date</th><th>Status<th>Comments</th><th>Customer ID</th>';
foreach($data as $order)
{
	echo form_open('products_controller/orders'); 	
		echo '<tr>';
		echo form_hidden('order_id', $order['order_id']);
		echo '<td>' . $order['order_id'] . '</td>';
		echo '<td>' . $order['order_date'] . '</td>';
		echo '<td>' . $order['required_date'] . '</td>';
		echo '<td>' . $order['shipped_date'] . '</td>';
		echo '<td>' . $order['status'] . '</td>';
		echo '<td>' . $order['comments'] . '</td>';

		$url = 'index.php/products_controller/cancel_order?order_id=' . $order['order_id'] . '"';
		echo '<td><a class="color1" href="' . base_url($url) . '>Cancel Order </a></td>'; 

		$url = 'index.php/products_controller/customer_order_details?order_id=' . $order['order_id'] . '"';
		echo '<td><a class="color1" href="' . base_url($url) . '>View Order Details </a></td>'; 


		echo '</tr>';
	echo form_close(); 
}
echo '</table>';
?>
</div>
</div>