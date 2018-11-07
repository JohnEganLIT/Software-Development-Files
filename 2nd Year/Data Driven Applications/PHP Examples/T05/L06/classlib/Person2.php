<?php 
class Person2 {
	
	// explicitly adding class properties are optional - but is good practice
	public $name;	
	protected $PPSN;
	private $PIN;  //PIN number is private

	function __construct($persons_name) {  //class constructor	
		$this->set_name($persons_name);
		$this->PIN=1234;
		$this->PPSN="76543234Q";
	}
	
	
	public function get_name() {	
		return $this->name;
	}
	
	//protected methods and properties restrict access to those elements.
	protected function set_name($new_name) {
		$this->name = strtoupper($new_name);	
	}
	
}  //end class Person2

?>
