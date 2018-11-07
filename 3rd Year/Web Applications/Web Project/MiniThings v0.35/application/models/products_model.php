<?php

class products_model extends CI_Model
{
    public function __construct() 
    {
        parent::__construct();
    }
    
    public function getProducts($category) 
    {

        $this->db->select('product_name');
        $this->db->select('product_description');
        $this->db->select('image');
        $this->db->from('products');
        $this->db->where('product_line', $category);
        $query = $this->db->get();

        return $query->result_array();
    }

    public function products_by_category($category) 
    {

        $this->db->select('product_name');
        $this->db->select('product_description');
        $this->db->select('image');
        $this->db->from('products');
        $this->db->where('product_line', $category);
        $query = $this->db->get();

        return $query->result_array();
    }
}

