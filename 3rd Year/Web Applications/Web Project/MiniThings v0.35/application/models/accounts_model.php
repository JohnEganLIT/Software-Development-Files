<?php

class accounts_model extends CI_Model
{
    public function __construct() 
    {
        parent::__construct();
    }

    public function login($email, $password)
    {
        //Checks db for matching customer num and password hash
        $this->db->select('customer_number');  
        $this->db->select('email');  
        $this->db->from('customers');        
        $this->db->where('email', $email);
        $this->db->where('password', $password);
        $query = $this->db->get();

        return $query->result_array(); //returns users email and password
    }

    /*
    public function login($type ,$email, $password)
    {
        //Checks db for matching customer num and password hash
        $this->db->select('customerNumber');  
        $this->db->select('email');  

        //Checks if admin or customer is logging in
        if($type = "customer")
            $this->db->from('customers'); 
        else
            $this->db->from('admins');

       
        $this->db->where('email', $email);
        $this->db->where('password', $password);
        $query = $this->db->get();

        return $query->result_array(); //returns users email and password
    }
    */
    public function get_id($email)
    {
        $this->db->select('customer_number');  
        $this->db->from('customers');
        $this->db->where('email', $email);
        $query = $this->db->get();

        return $query->result_array();
    }

    public function admin_login($email, $password)
    {
        $this->db->select('adminID');  
        $this->db->select('password');  
        $this->db->from('customers');
        $this->db->where('email', $email);
        $this->db->where('password', $password);
        $query = $this->db->get();

        return $query->result_array();
    }
}
