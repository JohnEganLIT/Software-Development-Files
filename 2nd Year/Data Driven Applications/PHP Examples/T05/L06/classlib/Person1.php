<?php 
class Person1 {
	//class properties
	private $name;	
	
	//constructor
	function __construct($persons_name) 
	{  
		$this->set_name($persons_name);
	}
	
	//class methods
	public function get_name() {	
		return $this->name;
	}
	
	public function set_name($new_name) {
		$this->name = strtoupper($new_name);	
	}
	
}  //end class Person1
?>
