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

        $result = $this->accounts_model->get_id($email); //Gets ID of user

        echo $id;

        foreach ($result as $row)
        {
           $id = $row['customer_number'];
        }
        
        $cryptPass = hash('sha256', $id.$password); //Concatonates user id and password and hashes it
           
        $result = $this->accounts_model->login($email, $cryptPass); //Check db for matching email and password hash combo

        foreach ($result as $row)
        {
           $id = $row['customer_number'];
           $email = $row['email'];
        }

        //Checks if user record is present
        if ($result != null) 
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


