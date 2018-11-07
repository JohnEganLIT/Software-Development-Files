<?php
echo "Admin Control Panel";
echo "<br>";
echo '<a href="' . base_url("index.php/products_controller/admin_products") . '">View Products</a></div>';
echo "<br>";
echo '<a href="' . base_url("index.php/products_controller/add_product") . '">Add Product</a></div>';
echo "<br>";
echo '<a href="' . base_url("index.php/products_controller/admin_orders") . '">View Orders</a></div>';
echo "<br><br>";
echo '<a href="' . base_url("index.php/main_controller") . '">Return to Mini Things</a></div>';