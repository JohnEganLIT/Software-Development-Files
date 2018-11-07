<div class="container">
<div class="main">
<?php 

echo '<table id="customer_orders">';
echo '<th>Order ID</th><th>Product ID</th><th>Quantity Ordered</th><th>Price Each</th>';

foreach($data as $order)
{
	echo form_open('products_controller/order_details'); 	
		echo '<tr>';
		echo form_hidden('order_id', $order['order_id']);
		echo form_hidden('product_id', $order['product_id']);
		echo '<td>' . $order['order_id'] . '</td>';
		echo '<td>' . $order['product_id'] . '</td>';
		echo '<td>' . $order['quantity_ordered'] . '</td>';
		echo '<td>' . $order['price_each'] . '</td>';
		echo '<td>' . $order['image'] . '</td>';


		echo '</tr>';
	echo form_close(); 
}
echo '</table>';
?>
</div>
</div>