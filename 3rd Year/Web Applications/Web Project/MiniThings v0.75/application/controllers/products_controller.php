<?php

class products_controller extends CI_Controller
{
    public function __construct() 
    {
        parent::__construct();
        $this->load->library('table');
    }

    public function product_by_id() 
    {   
        $product_id = $_GET['product_id'];
        $data['products'] = $this->products_model->get_product_by_id($product_id);
              
        foreach($data['products'] as &$row)
        {
            $img=$row['image'];
            $row['image'] = '<img src="' . base_url() . 'assets/images/products/' . $img . '" alt="' . $img .'"';
            $row['msrp'] = '€' . $row['msrp']; 
        }

        $this->load->view('common/header');        
        $this->load->view('product', $data);
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
            $row['msrp'] = '€' . $row['msrp']; 
        }

        $this->load->view('common/header');        
        $this->load->view('products', $data);
        $this->load->view('common/footer'); 
    }

    public function products_wishlist()
    {
        $customer_id = $this->session->userdata('customer_id');
        $product_list = $this->products_model->get_products_wishlist($customer_id);
        $data = null;


        for($i=0; $i<count($product_list); $i++)
        {
            $product_id = $product_list[$i]['product_id'];

            $product_info = $this->products_model->get_product_by_id($product_id);
            $image = '<img src="' . base_url() . 'assets/images/thumbs/' . $product_info[0]['image'] . '" alt="' . $product_info[0]['image'] .'"';

            $data[$i] = array('product_id' => $product_info[0]['product_id'], 'product_name' => $product_info[0]['product_name'], 'msrp' => $product_info[0]['msrp'], 'image' => $image);

        }

        $this->load->view('common/header');        
        $this->load->view('wishlist', array('data' => $data));
        $this->load->view('common/footer');

    }

    public function products_cart()
    {


        $this->load->view('common/header');        
        $this->load->view('cart');
        $this->load->view('common/footer');

    }


    public function add_to_wishlist()
    {
        $customer_id = $this->session->userdata('customer_id');
        $product_id = $_GET['product_id'];
       
        $this->products_model->add_to_wishlist($customer_id, $product_id);

        redirect(main_controller);
        
    }

    public function remove_from_wishlist()
    {
        $customer_id = $this->session->userdata('customer_id');
        $product_id = $_GET['product_id'];

        $this->products_model->remove_from_wishlist($customer_id, $product_id);

        redirect(main_controller);
    }

    public function add_to_cart()
    {
        $product = $this->products_model->get_product_by_id($_GET['product_id']);
        $image = '<img src="' . base_url() . 'assets/images/thumbs/' . $product[0]['image'] . '" alt="' . $product[0]['image'] .'">';

        $data = array(
            'id'      => $product[0]['product_id'],
            'qty'     => 1,
            'price'   => $product[0]['msrp'],
            'name'    => $product[0]['product_name'],
            'image'   => $image
        );

        $this->cart->insert($data);
        redirect(main_controller);
    }

     public function remove_from_cart()
    {
        $data = array(
            'rowid'  => $_GET['rowid'],
            'qty' => 0
        );

        $this->cart->update($data);
        redirect(main_controller);
    }

    public function cart_quantity()
    {
        $rowid = $this->input->post("rowid");
        $quantity = $this->input->post("quantity");

        $data = array(
            'rowid'  => $rowid,
            'qty' => $quantity
        );

        $this->cart->update($data);

        $this->load->view('common/header');        
        $this->load->view('cart');
        $this->load->view('common/footer');
    }

    public function cart_order()
    {
        $this->load->view('order');
        
    }

    public function order_quantity()
    {
        $rowid = $this->input->post("rowid");
        $quantity = $this->input->post("quantity");

        $data = array(
            'rowid'  => $rowid,
            'qty' => $quantity
        );

        $this->cart->update($data);
     
        $this->load->view('order');
    }

      public function remove_from_order()
    {
        $data = array(
            'rowid'  => $_GET['rowid'],
            'qty' => 0
        );

        $this->cart->update($data);
        $this->load->view('order');
    }

    public function checkout()
    {
        $order_date = 
        $required_date = "0000-00-00";
        $order_id = null;
        $loop = true;

        while($loop == true)
        {
            $order_id = mt_rand(1000,9999);

            if(!$this->products_model->if_order_exists($order_id))
            {
                $loop = false;
            }
        }

        $data = array(
            'order_id' => $order_id,
            'order_date' => date('Y-m-d'),
            'required_date' => "0000-00-00",
            'status' => "In Process",
            'customer_id' => $this->session->userdata('customer_id')
        );

        if($this->products_model->create_order($data))
        {
            foreach ($this->cart->contents() as $item)
            {
                $data = array(
                    'order_id' => $order_id,
                    'product_id' => $item['id'],
                    'quantity_ordered' => $item['qty'],
                    'price_each' => $item['price']
                );
                
                $this->products_model->create_order_details($data);
            }        

            $this->cart->destroy();
            echo "Order Successful";
            echo '<br><a href="' . base_url() .'">Return To Homepage</a>'; 
        }

        else
        {
            echo "Error Creating order";
            echo '<br><a href="' . base_url() .'">Return To Homepage</a>'; 
        }

    }

    public function admin_products()
    {
        $products = $this->products_model->get_products();
        $data = null;
        $num = 0;
        for($i=0; $i<count($products); $i++)
        {
            $id = $products[$i]['product_id'];
            $name = $products[$i]['product_name'];
            $scale = $products[$i]['product_scale'];
            $vendor = $products[$i]['product_vendor'];
            $product_line = $products[$i]['product_line'];
            $description = $products[$i]['product_description'];
            $quantity = $products[$i]['quantity_in_stock'];
            $buy_price = $products[$i]['buy_price'];
            $msrp = $products[$i]['msrp'];
            $image = '<img src="' . base_url() . 'assets/images/thumbs/' . $products[$i]['image'] . '" alt="' . $products[$i]['image'] .'"';

            $data[$i] = array('product_id' => $id, 'product_name' => $name, 'product_scale' => $scale, 'product_vendor' => $vendor, 'product_line' => $product_line, 'product_description' => $description, 
                'quantity_in_stock' => $quantity, 'buy_price' => $buy_price, 'msrp' => $msrp, 'image' => $image);

        }
      
        $this->load->view('admin_products', array('data' => $data));
    }

    public function add_product()
    {
        $this->load->view('add_product');

        if($this->input->post('product_name'))
        {
            $loop = true;

            while($loop == true)
            {
                $product_id = mt_rand(1000,9999);

                if(!$this->products_model->if_product_exists($product_id))
                {
                    $loop = false;
                }
            }

            $data = $this->input->post();
            $data['product_id'] = $product_id;
            $data['image'] = "noimage.jpg";
            $this->products_model->add_product($data);

           redirect('products_controller/admin_products');
        }
    }

    public function delete_product()
    {
        $this->products_model->delete_product($_GET['product_id']);

        redirect('products_controller/admin_products');
    }

    public function admin_orders()
    {
        if($this->input->post('order_id'))
        {
            $order_id = $this->input->post('order_id');
            $data['required_date'] = $this->input->post('required_date');
            $data['shipped_date'] = $this->input->post('shipped_date');
            $data['status'] = $this->input->post('status');
            $data['comments'] = $this->input->post('comments');

            $this->products_model->update_order($order_id, $data);
        }  

        $data = $this->products_model->get_orders();
        $this->load->view('admin_orders', array('data' => $data));
    }

    public function orders()
    {
        if($this->input->post('order_id'))
        {
            $order_id = $this->input->post('order_id');
            $data['required_date'] = $this->input->post('required_date');
            $data['shipped_date'] = $this->input->post('shipped_date');
            $data['status'] = $this->input->post('status');
            $data['comments'] = $this->input->post('comments');

            $this->products_model->update_order($order_id, $data);
        }  

        $data = $this->products_model->get_orders_by_customer($this->session->userdata('customer_id'));
        $this->load->view('common/header');
        $this->load->view('orders', array('data' => $data));
        $this->load->view('common/footer');
    }

    public function delete_order()
    {
        $this->products_model->delete_order($_GET['order_id']);
        $this->products_model->delete_order_details($_GET['order_id']);
        redirect('products_controller/admin_orders');
    }

    public function cancel_order()
    {
        $this->products_model->delete_order($_GET['order_id']);
        $this->products_model->delete_order_details($_GET['order_id']);
        redirect('products_controller/orders');
    }

    public function update_product()
    {
        if($this->input->post('product_id'))
        {
            $this->products_model->update_product($this->input->post());

            redirect('products_controller/admin_products');

        }  
    }

    public function order_details()
    {
        if($_GET['order_id'])
        {
            $data = $this->products_model->get_order_details($_GET['order_id']);

            $this->load->view('common/header');
            $this->load->view('admin_order_details',  array('data' => $data));
            $this->load->view('common/footer');
        }  
    }

    public function customer_order_details()
    {
        if($_GET['order_id'])
        {
            $data = $this->products_model->get_order_details($_GET['order_id']);

            foreach($data as &$product)
            {
                $current_product = $this->products_model->get_product_by_id($product['product_id']);
                $current_product[0]['image'] = '<img src="' . base_url() . 'assets/images/thumbs/' . $current_product[0]['image'] . '" alt="' . $current_product[0]['image'] .'"';
                $product['image'] = $current_product[0]['image'];
            }

            $this->load->view('common/header');
            $this->load->view('order_details',  array('data' => $data));
            $this->load->view('common/footer');
        }  
    }

    public function update_order_details()
    {
        if($this->input->post('order_id'))
        {
            $data = $this->products_model->update_order_details($this->input->post('order_id'), $this->input->post('product_id'), $this->input->post('quantity_ordered'));

            $data = $this->products_model->get_order_details($this->input->post('order_id'));

            $this->load->view('admin_order_details',  array('data' => $data));
        }  
    }
}
