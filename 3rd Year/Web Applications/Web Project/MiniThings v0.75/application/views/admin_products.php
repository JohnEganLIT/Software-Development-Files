<?php

echo '<div id="cart_header"><a href="' . base_url("index.php/accounts_controller/control_panel") . '">Return to Control Panel</a></div>';

echo '<table border="1px">';
echo '<th>Name</th><th>Scale</th><th>Vendor</th><th>Product Line<th>Description</th><th>Quantity</th><th>Buy Price</th><th>MSRP</th>';
foreach($data as $product)
{
	echo form_open('products_controller/update_product'); 	
		echo '<tr>';
		echo form_hidden('product_id', $product['product_id']);
		echo '<td>' . form_input(array('name' => 'product_name', 'type' => 'text', 'value' => $product['product_name'], 'required'=>'required')). '</td>';
		echo '<td>' . form_input(array('name' => 'product_scale', 'type' => 'text', 'value' => $product['product_scale'], 'required'=>'required')). '</td>';
		echo '<td>' . form_input(array('name' => 'product_vendor', 'type' => 'text', 'value' => $product['product_vendor'], 'required'=>'required')). '</td>';
		echo '<td>' . form_input(array('name' => 'product_line', 'type' => 'text', 'value' => $product['product_line'], 'required'=>'required')). '</td>';
		echo '<td>' . form_input(array('name' => 'product_description', 'type' => 'text', 'value' => $product['product_description'] , 'required'=>'required')). '</td>';
		echo '<td>' . form_input(array('name' => 'quantity_in_stock', 'type' => 'text', 'value' => $product['quantity_in_stock'] , 'required'=>'required')). '</td>';
		echo '<td>' . form_input(array('name' => 'buy_price', 'type' => 'text', 'value' => $product['buy_price'], 'required'=>'required')). '</td>';
		echo '<td>' . form_input(array('name' => 'msrp', 'type' => 'text', 'value' => $product['msrp'], 'required'=>'required')). '</td>';
		echo '<td>' . $product['image'] . '</td>';

		$url = 'index.php/products_controller/delete_product?product_id=' . $product['product_id'] . '"';
		echo '<td><a class="color1" href="' . base_url($url) . '>Delete</a></td>'; 

		$url = 'index.php/products_controller/update_product?product_id=' . $product['product_id'] . '"';
		echo '<td>' . form_submit(array('value' => 'Update')) . '</td>'; 

		echo '</tr>';
	echo form_close(); 
}
echo '</table>';
