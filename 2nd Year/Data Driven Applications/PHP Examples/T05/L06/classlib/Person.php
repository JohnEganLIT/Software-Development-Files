<?php 
class Person {
	//class properties
	private $name;	
	private $dateOfBirth;
	
	//constructor
	function __construct($persons_name,$dob) 
	{  
		$this->set_name($persons_name);
		$this->set_dob($dob);
	}
	
	//class methods
	
	//getters
	public function get_name() {	
		return $this->name;
	}
	
	public function get_dob() {	
		return $this->dateOfBirth;
	}
	
	//setters
	public function set_name($new_name) {
		$this->name = strtoupper($new_name);	
	}
	
	protected function set_dob($date) {
		$this->dateOfBirth = $date;	
	}
	
}  //end class Person
?>
