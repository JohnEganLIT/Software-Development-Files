<?php

class productsModel extends CI_Model
{
    public function __construct() 
    {
        parent::__construct();
    }
    
    public function getProducts($category) 
    {

        $this->db->select('productName');
        $this->db->select('productDescription');
        $this->db->select('image');
        $this->db->from('products');
        $this->db->where('productLine', $category);
        $query = $this->db->get();

        return $query->result_array();
    }
}

