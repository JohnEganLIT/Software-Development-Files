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
        $this->db->select('contact_first_name');
        $this->db->select('customer_id');  
        $this->db->select('password');  
        $this->db->from('customers');        
        $this->db->where('email', $email);
        $query = $this->db->get();

        return $query->result_array(); //returns users email and password
    }

    public function get_admin($username)
    {
        $this->db->select('admin_id');  
        $this->db->select('password');  
        $this->db->from('admins');
        $this->db->where('username', $username);
        $query = $this->db->get();

        return $query->result_array();
    }

    public function create_account($values)
    {
        if($this->db->insert('customers', $values))
            return true;
        
        else
            return false;
    }

    public function if_id_exists($customer_id)
    {
        $this->db->select('customer_id');  
        $this->db->from('customers');        
        $this->db->where('customer_id', $customer_id);
        $query = $this->db->get();

        if(count($query->result_array()) > 0) 
            return true;

        else
            return false;
    }
}
