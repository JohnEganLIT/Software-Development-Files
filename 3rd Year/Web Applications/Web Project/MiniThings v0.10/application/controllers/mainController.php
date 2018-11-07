<?php
defined('BASEPATH') OR exit('No direct script access allowed');

class MainController extends CI_Controller
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
    	$this->load->view('common/header');  	
        $this->load->view('homepage');       
        $this->load->view('common/footer');
    }  

    public function header()
    {  	
		$this->form_validation->set_rules('email', 'Email', 'trim|required|xss_clean', 'required');
		$this->form_validation->set_rules('password', 'Password', 'trim|required|xss_clean', 'required');

    	
    }
}

