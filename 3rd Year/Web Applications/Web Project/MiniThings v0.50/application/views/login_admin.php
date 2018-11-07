<div class="main">
<?php
	if($this->session->userdata('id'))
	{
		redirect(main_controller);	
	}

	echo '<div id="login_form">';		
		echo form_open('accounts_controller/login_admin'); 
			echo '<span id="login_heading">Login</span>';
			echo form_input(array('class' => 'form_field', 'name' => 'email', 'type' => 'email', 'placeholder' => 'Email', 'required'=>'required'));	
			echo form_input(array('class' => 'form_field', 'name' => 'password', 'type' => 'password', 'placeholder' => '*********', 'required'=>'required'));	
			echo form_submit(array('id' => 'login_btn', 'value' => 'Login'));
		echo form_close(); 	
		echo '<span id="login_failed">' . $this->session->flashdata('login_failed') . '</span>';			               		 
	echo '</div>';
?>
</div>