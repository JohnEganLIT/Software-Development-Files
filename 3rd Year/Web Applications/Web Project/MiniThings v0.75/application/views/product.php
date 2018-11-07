<div class="main">
<div id="product">
    <?php
        echo '<div class="product">';
            echo '<span class="product_name">' . $products[0]['product_name'] . '</span>';   
            echo '<span class="product_image">' . $products[0]['image'] . '</span>';           
            echo '<span class="product_msrp">' . $products[0]['msrp'] . '</span>';

            if($this->session->userdata('customer_id'))
            {
                $url = "index.php/products_controller/add_to_cart?product_id=" . $products[0]['product_id'] . '"';
                echo '<div class="add_cart_btn"><a href="' . base_url($url) . '>Add To Cart</a></div>';

                $this->db->select('customer_id');
                $this->db->select('product_id');
                $this->db->from('wishlist');
                $this->db->where('customer_id', $this->session->userdata('customer_id'));
                $this->db->where('product_id', $products[0]['product_id']);
                $query = $this->db->get();

                if(count($query->result_array()) > 0)
                {
                    $url = "index.php/products_controller/remove_from_wishlist?product_id=" . $products[0]['product_id'] . '"';
                    echo '<div class="add_wishlist_btn"><a href="' . base_url($url) . '>Remove from Wishlist</a></div>';
                }

                else
                {
                    $url = "index.php/products_controller/add_to_wishlist?product_id=" . $products[0]['product_id'] . '"';
                    echo '<div class="add_wishlist_btn"><a href="' . base_url($url) . '>Add To Wishlist</a></div>';
                }
            }
                     
            echo '<span class="product_description">' . $products[0]['product_description'] . '</span>';
                 
        echo '</div>';
        echo '</a>';
    ?>
</div>
</div>