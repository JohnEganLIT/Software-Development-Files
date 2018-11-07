<?php

class loginModel extends CI_Model
{
    public function __construct() 
    {
        parent::__construct();
    }

    public function login($email, $password)
    {
        $this->db->select('customerNumber');  
        $this->db->select('email');  
        $this->db->from('customers');
        $this->db->where('email', $email);
        $this->db->where('password', $password);
        $query = $this->db->get();

        return $query->result_array();

    }

    public function getID($email)
    {
        $this->db->select('customerNumber');  
        $this->db->from('customers');
        $this->db->where('email', $email);
        $query = $this->db->get();

        return $query->result_array();
    }

    public function adminLogin($email, $password)
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
