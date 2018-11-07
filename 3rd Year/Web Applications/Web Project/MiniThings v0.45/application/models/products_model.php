<?php

class products_model extends CI_Model
{
    public function __construct() 
    {
        parent::__construct();
    }

    public function get_product_by_id($product_id)
    {
        $this->db->select('*');
        $this->db->from('products');
        $this->db->where('product_id', $product_id);
        $query = $this->db->get();

        return $query->result_array();
    }

    public function get_products_by_category($category) 
    {
        $this->db->select('product_id');
        $this->db->select('product_name');
        $this->db->select('msrp');
        $this->db->select('image');
        $this->db->from('products');
        $this->db->where('product_line', $category);
        $query = $this->db->get();

        return $query->result_array();
    }

    public function get_products_wishlist($customer_id) 
    {
        $this->db->select('product_id');
        $this->db->from('wishlist');
        $this->db->where('customer_id', $customer_id);
        $query = $this->db->get();

        return $query->result_array();
    }
}

