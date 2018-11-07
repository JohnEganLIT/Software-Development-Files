<?php

class products_controller extends CI_Controller
{
    public function __construct() 
    {
        parent::__construct();
        $this->load->library('table');
    }

    public function products_by_category() 
    {   
        $category = $_GET['category'];
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
