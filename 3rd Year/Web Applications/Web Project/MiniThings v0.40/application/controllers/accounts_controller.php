<?php
defined('BASEPATH') OR exit('No direct script access allowed');

class accounts_controller extends CI_Controller
{
	public function __construct()
    {
    	parent::__construct();

    	$this->load->database();
        $this->load->helper('form');
        $this->load->helper('url');
        $this->load->helper('html');    
        $this->load->library('session');
        $this->load->library('form_validation');
    }

    public function login()
    {
        //Get the posted values
        $email = $this->input->post("email");
        $password = $this->input->post("password");
        $id = null;
        $stored_password = null;

        $result = $this->accounts_model->get_customer($email); //Gets ID and password hash of user

        foreach ($result as $row)
        {
           $id = $row['customer_id'];
           $stored_password = $row['password'];
        }
        
        $hashed_password = hash('sha256', $id.$password); //Concatonates user id and password and hashes it
        
        if($hashed_password == $stored_password) //Compares entered password and stored password hashes
        {        
            if ($result != null) //Checks if user record is present
            {
                //Set the session variables, logging the user in
                $sessiondata = array('id' => $id, 'email' => $email);
                $this->session->set_userdata($sessiondata);
                redirect("main_controller");
            }

            else
            {
                $this->session->set_flashdata('login_failed', 'Invalid username or password!');
                redirect("accounts_controller/create_account");
            }
        }        
    } 

    public function logout()
    {
        //Ends the session, logging the user out
        $this->session->sess_destroy();
        redirect("main_controller");
    } 

    public function create_account()
    {
        $this->load->view('common/header');        
        $this->load->view('create_account');
        $this->load->view('common/footer'); 
    }
}


