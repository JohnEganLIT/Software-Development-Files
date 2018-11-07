<?php

class accounts_model extends CI_Model
{
    public function __construct() 
    {
        parent::__construct();
    }

    public function get_customer($email)
    {
        //Checks db for customer with matching email
        $this->db->select('customer_id');  
        $this->db->select('password');  
        $this->db->from('customers');        
        $this->db->where('email', $email);
        $query = $this->db->get();

        return $query->result_array(); //returns users email and password
    }

    public function get_admin($email, $password)
    {
        $this->db->select('adminID');  
        $this->db->select('password');  
        $this->db->from('customers');
        $this->db->where('email', $email);
        $this->db->where('password', $password);
        $query = $this->db->get();

        return $query->result_array();
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
}
