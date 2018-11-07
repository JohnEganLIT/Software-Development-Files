<?php
defined('BASEPATH') OR exit('No direct script access allowed');

class LoginController extends CI_Controller
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
		$this->load->model('loginModel');
    }

    public function login()
    {
        //Get the posted values
        $email = $this->input->post("email");
        $password = $this->input->post("password");
        $id = null;

        //Gets ID of user
        $result = $this->loginModel->getID($email);

        foreach ($result as $row)
        {
           $id = $row['customerNumber'];
        }

        $salt = $id; //Creates a per user salt for increased security 
        $cryptPass = hash('sha256', $salt.$password); //Encrypts password and uses sha256 hashing along with the salt for increased security
        
        //Check db for matching email and password hash combo
        $result = $this->loginModel->login($email, $cryptPass);

        foreach ($result as $row)
        {
           $id = $row['customerNumber'];
           $email = $row['email'];
        }

        //active user record is present
        if ($result != null) 
        {
            //set the session variables
            $sessiondata = array('id' => $id, 'email' => $email);
            $this->session->set_userdata($sessiondata);
            redirect("mainController");
        }

        else
        {
            $this->session->set_flashdata('loginFailed', 'Invalid username and password!');
            echo $this->session->flashdata('loginFailed');
            redirect("mainController");
        }
    } 

    public function logout()
    {
        $this->session->sess_destroy();
        redirect("mainController");

    } 

    public function createAccount()
    {
        $this->load->view('common/header');        
        $this->load->view('createAccount');
        $this->load->view('common/footer'); 
    }
}


