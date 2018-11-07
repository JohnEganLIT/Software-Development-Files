<div class="main">
<?php
	echo form_open('loginController/CreateAccount'); 

	echo form_input(array('class' => 'createAccountField', 'name' => 'customerName', 'type' => 'text', 'placeholder' => 'Customer Name'));
	echo form_input(array('class' => 'createAccountField', 'name' => 'lastName', 'type' => 'text', 'placeholder' => 'First Name'));
	echo form_input(array('class' => 'createAccountField', 'name' => '', 'type' => 'text', 'placeholder' => 'Last Name'));
	echo form_input(array('class' => 'createAccountField', 'name' => 'search', 'type' => 'text', 'placeholder' => 'Address 1'));
	echo form_input(array('class' => 'createAccountField', 'name' => 'search', 'type' => 'text', 'placeholder' => 'Address 2'));
	echo form_input(array('class' => 'createAccountField', 'name' => 'search', 'type' => 'text', 'placeholder' => 'Town'));
	echo form_input(array('class' => 'createAccountField', 'name' => 'search', 'type' => 'text', 'placeholder' => 'Address 1'));

	
	echo form_submit(array('id' => 'searchBtn', 'value' => 'Search'));

	echo form_close(); 
?>
</div>