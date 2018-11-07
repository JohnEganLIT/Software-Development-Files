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

    public function index()
    {
        //get the posted values
        $email = $this->input->post("email");
        $password = $this->input->post("password");

        echo $email . $password;

        $result = $this->loginModel->login($email, $password);

        if ($result > 0) //active user record is present
        {
            //set the session variables
             $sessiondata = array('id' => $result);
             $this->session->set_userdata($sessiondata);
        }

        redirect("mainController");
        /*
        //set validations
        $this->form_validation->set_rules("email", "Email", "trim|required");
        $this->form_validation->set_rules("password", "Password", "trim|required");

        //check if username and password is correct
        $result = $this->login_model->login($email, $password);
        if ($result > 0) //active user record is present
        {
            //set the session variables
             $sessiondata = array(
                  'username' => $username,
                  'loginuser' => TRUE
             );
             $this->session->set_userdata($sessiondata);
             redirect("index");
        }

        else
        {
             $this->session->set_flashdata('msg', '<div class="alert alert-danger text-center">Invalid username and password!</div>');
             redirect('login/index');
        }
        */

    }    
    public function logout()
    {
        $this->session->sess_destroy();
        redirect("mainController");

    }  
}


