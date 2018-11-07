<?php 
class Employee extends Person {  // 'extends' is the keyword that enables inheritance

	protected $PPSN;
	protected $jobTitle;
	private $PIN;  //PIN number is private

	
	function __construct($employee_name,$PPS_Number,$Personal_ID_Nr,$dob) { //class constructor	
		$this->set_name($employee_name);
		$this->set_pps($PPS_Number);
		$this->set_dob($dob);
		$this->PIN=$Personal_ID_Nr;
	}
	
	//setters
	private function set_pps($nr) {
		$this->PPSN = $nr;	
	}
	
	public function set_pin($old,$new) {
		if ($this->PIN == $old){  //old PIN must be used to change value
			$this->PIN=$new;
			return TRUE;
		}
		else{
			return FALSE;
		}
	}
	
	//getters
	public function get_ppsn() {
		return $this->PPSN;	
	}
	
	public function get_pin() {
		return $this->PIN;	
	}
	
	//other methods
	public function verify_pin($nr) {
		if ($this->PIN == $nr){ 
			return TRUE;
		}
		else{
			return FALSE;
		}
	}
	
}  //end class Employee
?>

