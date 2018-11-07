<div class="main">
<?php
	if($this->session->userdata('id'))
	{
		redirect(main_controller);	
	}

	echo '<div id="create_account_form">';
		echo form_open('accounts_controller/create_account'); 	
			echo '<span id="create_account_heading">Create Account</span>';
			echo form_input(array('class' => 'form_field', 'name' => 'email', 'type' => 'email', 'placeholder' => 'Email', 'required'=>'required'));
			echo form_input(array('class' => 'form_field', 'name' => 'password', 'type' => 'password', 'placeholder' => 'Password', 'required'=>'required'));
			echo form_input(array('class' => 'form_field', 'name' => 'customer_name', 'type' => 'text', 'placeholder' => 'Customer Name', 'required'=>'required'));
			echo form_input(array('class' => 'form_field', 'name' => 'contact_first_name', 'type' => 'text', 'placeholder' => 'First Name', 'required'=>'required'));
			echo form_input(array('class' => 'form_field', 'name' => 'contact_last_name', 'type' => 'text', 'placeholder' => 'Last Name', 'required'=>'required'));
			echo form_input(array('class' => 'form_field', 'name' => 'address1', 'type' => 'text', 'placeholder' => 'Address 1', 'required'=>'required'));
			echo form_input(array('class' => 'form_field', 'name' => 'address2', 'type' => 'text', 'placeholder' => 'Address 2'));
			echo form_input(array('class' => 'form_field', 'name' => 'city', 'type' => 'text', 'placeholder' => 'City', 'required'=>'required'));
			echo form_input(array('class' => 'form_field', 'name' => 'state', 'type' => 'text', 'placeholder' => 'State', 'required'=>'required'));
			echo form_input(array('class' => 'form_field', 'name' => 'postal_code', 'type' => 'text', 'placeholder' => 'Postal Code'));
			echo form_input(array('class' => 'form_field', 'name' => 'country', 'type' => 'text', 'placeholder' => 'Country', 'required'=>'required'));	
			echo form_submit(array('id' => 'create_account_btn', 'value' => 'Create Account'));
		echo form_close(); 
		echo '<span id="create_account_failed">' . $this->session->flashdata('create_account_failed') . '</span>';
		echo '<span id="create_account_success">' . $this->session->flashdata('create_account_failed') . '</span>';
	echo '</div>';

	echo '<div id="login_form">';		
		echo form_open('accounts_controller/login_user'); 
			echo '<span id="login_heading">Login</span>';
			echo form_input(array('class' => 'form_field', 'name' => 'email', 'type' => 'email', 'placeholder' => 'Email', 'required'=>'required'));	
			echo form_input(array('class' => 'form_field', 'name' => 'password', 'type' => 'password', 'placeholder' => '*********', 'required'=>'required'));	
			echo form_submit(array('id' => 'login_btn', 'value' => 'Login'));
		echo form_close(); 	
		echo '<span id="login_failed">' . $this->session->flashdata('login_failed') . '</span>';			               		 
	echo '</div>';
?>
</div>