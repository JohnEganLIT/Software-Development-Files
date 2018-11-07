<?php

class products_controller extends CI_Controller
{
    public function __construct() 
    {
        parent::__construct();
        $this->load->library('table');
    }

    public function product($id) 
    {   
        $data['products'] = $this->products_model->products_by_category($category);
              
        foreach($data['products'] as &$row)
        {
            $img=$row['image'];
            $row['image'] = '<img src="' . base_url() . 'assets/images/thumbs/' . $img . '" alt="' . $img .'"';
        }

        $this->load->view('common/header');        
        $this->load->view('products', $data);
        $this->load->view('common/footer'); 
    }

    public function products_by_category() 
    {   
        $category = $_GET['category'];

        $data['products'] = $this->products_model->get_products_by_category($category);
              
        foreach($data['products'] as &$row)
        {
            $img=$row['image'];
            $row['image'] = '<img src="' . base_url() . 'assets/images/thumbs/' . $img . '" alt="' . $img .'"';
        }

        $this->load->view('common/header');        
        $this->load->view('products', $data);
        $this->load->view('common/footer'); 
    }

    public function products_wishlist()
    {
        $customer_id = $this->session->userdata('id');
        $product_list = $this->products_model->get_products_wishlist($customer_id);
        $data = null;

        for($i=0; $i<count($product_list); $i++)
        {
            $product_id = $product_list[$i]['product_id'];

            $product_info = $this->products_model->get_product_by_id($product_id);
            $image = '<img src="' . base_url() . 'assets/images/thumbs/' . $product_info[0]['image'] . '" alt="' . $product_info[0]['image'] .'"';

            $data[$i] = array('product_name' => $product_info[0]['product_name'], 'msrp' => $product_info[0]['msrp'], 'image' => $image);

        }

        $this->load->view('common/header');        
        $this->load->view('wishlist', array('data' => $data));
        $this->load->view('common/footer');

    }


    /*

    public function products_by_name()
    {
        $search = $_GET['search'];
        $data['products'] = $this->productsModel->getProductsByName($search);
              
        foreach($data['products'] as &$row)
        {
            $img=$row['image'];
            $row['image'] = '<img src="' . base_url() . 'assets/images/thumbs/' . $img . '" alt="' . $img .'"';
        }

        $this->load->view('common/header');        
        $this->load->view('products', $data);
        $this->load->view('common/footer'); 
    }

    public function products_by_ID()
    {
        $search = $_GET['id'];
        $data['products'] = $this->products_model->getProductsByID($id);
              
        foreach($data['products'] as &$row)
        {
            $img=$row['image'];
            $row['image'] = '<img src="' . base_url() . 'assets/images/thumbs/' . $img . '" alt="' . $img .'"';
        }

        $this->load->view('common/header');        
        $this->load->view('products', $data);
        $this->load->view('common/footer'); 
    }

    public function addProductToCart()
    {

    }
    */
}
