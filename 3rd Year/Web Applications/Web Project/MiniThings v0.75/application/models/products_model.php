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

    public function get_products() 
    {
        $this->db->select('*');
        $this->db->from('products');
        $query = $this->db->get();

        return $query->result_array();
    }

    public function add_to_wishlist($customer_id, $product_id)
    {
        $data = array(
            'customer_id' => $customer_id,
            'product_id' => $product_id
        );

        $this->db->insert('wishlist', $data);

    }

    public function remove_from_wishlist($customer_id, $product_id)
    {
        $this->db->where('customer_id', $customer_id);
        $this->db->where('product_id', $product_id);
        $this->db->delete('wishlist');    
    }

    public function create_order($data)
    {
        if($this->db->insert('orders', $data))
            return true;

        else
            return false;
    }

    public function create_order_details($data)
    {
        $this->db->insert('order_details', $data);
    }

    public function if_order_exists($order_id)
    {
        $this->db->select('order_id');  
        $this->db->from('orders');        
        $this->db->where('order_id', $order_id);
        $query = $this->db->get();

        if(count($query->result_array()) > 0) 
            return true;

        else
            return false;
    }

    public function if_product_exists($product_id)
    {
        $this->db->select('product_id');  
        $this->db->from('products');        
        $this->db->where('product_id', $product_id);
        $query = $this->db->get();

        if(count($query->result_array()) > 0) 
            return true;

        else
            return false;
    }

    public function delete_product($product_id)
    {
        $this->db->where('product_id', $product_id);
        $this->db->delete('products');   
    }

    public function update_product($data)
    {
        $this->db->where('product_id', $data['product_id']);
        $this->db->update('products', $data);

        //$this->db->update('products', $data, array('id' => $id));
    }

    public function add_product($data)
    {
        if($this->db->insert('products', $data))
            return true;

        else
            return false;
    }

    public function get_orders()
    {
        $this->db->select('*');
        $this->db->from('orders');

        $query = $this->db->get();

        return $query->result_array();
    }

    public function get_orders_by_customer($customer_id)
    {
        $this->db->select('*');
        $this->db->from('orders');
        $this->db->where('customer_id', $customer_id);

        $query = $this->db->get();

        return $query->result_array();
    }

    public function delete_order($order_id)
    {
        $this->db->where('order_id', $order_id);
        $this->db->delete('orders');    
    }

    public function delete_order_details($order_id)
    {
        $this->db->where('order_id', $order_id);
        $this->db->delete('order_details'); 
    }

    public function get_order_details($order_id)
    {
        $this->db->select('*');
        $this->db->from('order_details'); 
        $this->db->where('order_id', $order_id);

        $query = $this->db->get();

        return $query->result_array();
    }

     public function update_order_details($order_id, $product_id, $quantity_ordered)
    {
          $data = array(
            'quantity_ordered' => $quantity_ordered
        );

        $this->db->where('order_id', $order_id);
        $this->db->where('product_id', $product_id);
        $this->db->update('order_details', $data);
    }

     public function update_order($order_id, $data)
    {
        $this->db->where('order_id', $order_id);
        $this->db->update('orders', $data);
    }
}



