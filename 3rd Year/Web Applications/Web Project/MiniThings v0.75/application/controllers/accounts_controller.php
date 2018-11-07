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

    public function login_user()
    {
        //Get the posted values
        $email = $this->input->post("email");
        $password = $this->input->post("password");
        $customer_id = null;
        $stored_password = null;
        $contact_first_name = null;

        $result = $this->accounts_model->get_customer($email); //Gets ID and password hash of user

        foreach ($result as $row)
        {
           $customer_id = $row['customer_id'];
           $stored_password = $row['password'];
           $contact_first_name = $row['contact_first_name'];
        }
        
        $hashed_password = hash('sha256', $customer_id.$password); //Concatonates user id and password and hashes it
        
        if($result != null && $hashed_password == $stored_password) //Compares entered password and stored password hashes
        {        
            //Set the session variables, logging the user in
            $sessiondata = array('customer_id' => $customer_id, 'email' => $email, 'contact_first_name' => $contact_first_name);
            $this->session->set_userdata($sessiondata);
            echo "logged in";
            redirect("main_controller");        
        }    

        else
        {
            $this->session->set_flashdata('login_failed', 'Invalid username or password!');
            redirect("accounts_controller/login");
        } 
    } 

    public function logout_user()
    {
        //Ends the session, logging the user out
        $this->session->sess_destroy();
        redirect("main_controller");
    }

    public function login()
    {
        $this->load->view('common/header');        
        $this->load->view('login');
        $this->load->view('common/footer'); 
    } 

    public function create_account()
    {
        $values = $_POST;

        $loop = true;

        while($loop == true)
        {
            $customer_id = mt_rand(1000,9999);

            if(!$this->accounts_model->if_id_exists($customer_id))
            {
                $loop = false;
            }
        }

        $hashed_password = hash('sha256', $customer_id.$this->input->post('password')); //Concatonates user id and password and hashes it

        $values['customer_id'] = $customer_id;
        $values['password'] = $hashed_password;

        $result = $this->accounts_model->create_account($values);

        if($result)
        {
            $this->session->set_flashdata('create_account_success', 'Account Created');
        }
            
        else
        {
            $this->session->set_flashdata('create_account_failed', 'Error! Account creation failed');
        }
        
        $this->load->view('common/header');        
        $this->load->view('login');
        $this->load->view('common/footer'); 

    }

    public function login_admin()
    {    
        $this->load->view('login_admin');

        if($this->input->post("username"))
        {
            //Get the posted values
            $username = $this->input->post("username");
            $password = $this->input->post("password");
            $admin_id = null;
            $stored_password = null;

            $result = $this->accounts_model->get_admin($username); //Gets ID and password hash of user

            //var_dump($result);
            foreach ($result as $row)
            {
               $admin_id = $row['admin_id'];
               $stored_password = $row['password'];
            }
            
            $hashed_password = hash('sha256', $admin_id.$password); //Concatonates user id and password and hashes it

            if($result != null && $hashed_password == $stored_password) //Compares entered password and stored password hashes
            {        
                //Set the session variables, logging the user in
                $sessiondata = array('admin_id' => $admin_id, 'username' => $username);
                $this->session->set_userdata($sessiondata);
                redirect("main_controller");        
            }    

            else
            {
                $this->session->set_flashdata('login_failed', 'Invalid username or password!');
                redirect("accounts_controller/login_admin");
            }       
        }   
    }

    public function control_panel()
    {
        $this->load->view('control_panel');
    }
}


