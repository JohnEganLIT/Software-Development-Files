<?php

echo '<div id="cart_header"><a href="' . base_url("index.php/accounts_controller/control_panel") . '">Return to Control Panel</a></div>';

echo '<table border="1px">';
echo '<th>Name</th><th>Scale</th><th>Vendor</th><th>Product Line<th>Description</th><th>Quantity</th><th>Buy Price</th><th>MSRP</th>';

echo form_open('products_controller/add_product'); 	
	echo '<tr>';
	echo '<td>' . form_input(array('name' => 'product_name', 'type' => 'text', 'required'=>'required')). '</td>';
	echo '<td>' . form_input(array('name' => 'product_scale', 'type' => 'text', 'required'=>'required')). '</td>';
	echo '<td>' . form_input(array('name' => 'product_vendor', 'type' => 'text',  'required'=>'required')). '</td>';
	echo '<td>' . form_input(array('name' => 'product_line', 'type' => 'text',  'required'=>'required')). '</td>';
	echo '<td>' . form_input(array('name' => 'product_description', 'type' => 'text' , 'required'=>'required')). ' </td>';
	echo '<td>' . form_input(array('name' => 'quantity_in_stock', 'type' => 'text',  'required'=>'required')). '</td>';
	echo '<td>' . form_input(array('name' => 'buy_price', 'type' => 'text', 'required'=>'required')). '</td>';
	echo '<td>' . form_input(array('name' => 'msrp', 'type' => 'text', 'required'=>'required')). '</td>';
	echo '<td>' . form_submit(array('value' => 'Add')) . '</td>'; 

	echo '</tr>';
echo form_close(); 

echo '</table>';
