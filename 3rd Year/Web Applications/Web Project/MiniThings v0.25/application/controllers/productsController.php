<?php

class ProductsController extends CI_Controller
{
    public function __construct() 
    {
        parent::__construct();
        $this->load->library('table');

    }

    public function getProducts() 
    {   
        $category = $_GET['category'];
        $data['products'] = $this->productsModel->getProducts($category);
              
        foreach($data['products'] as &$row)
        {
            $img=$row['image'];
            $row['image'] = '<img src="' . base_url() . 'assets/images/thumbs/' . $img . '" alt="' . $img .'"';
        }

        $this->load->view('common/header');        
        $this->load->view('products', $data);
        $this->load->view('common/footer'); 

    }
}
