<?php
$marks = array();

$subjectAverages = array("WP"=> 0,"WD"=>0,"ID"=>0,"DV"=>0,"HC"=>0,"PR"=>0);

$classAverage = 0;

fillArray($marks);

findSubjectAverages($marks,$subjectAverages);

studentAverages($marks,$studentAverages);

printArray($marks,$studentAverages,$classAverage,$subjectAverages);

echo "<br>Class Average is: " . round($classAverage,1) . "<br><br>";

analysisOverAverages($classAverage, $studentAverages);

//////////////////////////////////////////////////////////////////////////////////////////
function fillArray(&$marks){

	for($k=1; $k<=10;$k++){
		$studentNumber = "K00". $k;
		$marks[$studentNumber]=array("WP"=> rand(0, 100),"WD"=>rand(0, 100),"ID"=>rand(0, 100),"DV"=>rand(0, 100),"HC"=>rand(0, 100),"PR"=>rand(0, 100));
	}//end for

	
}//end function fillArray

//////////////////////////////////////////////////////////////////////////////////////////
function printArray($marks,&$studentAverages,&$classAverage,$subjectAverages){
	echo "Student marks below average displayed in red <br>";
	
	foreach($marks as $student=>$grades){
		echo "Student: " . $student . " marks are as follows: ";
			foreach($grades as $subject=>$value){
				if($value < $subjectAverages[$subject])
					echo ("<font color=\"red\">" . $subject . " = " .$value ."</font>");
				else
					echo (" " . $subject . " = " .$value); 
				
			}//end foreach
			
			echo " <i>(Avg:" . round($studentAverages[$student],1) . ")</i>";
			$classAverage = $classAverage + $studentAverages[$student];
			echo "<br>";	
	}//end foreach

	$classAverage = $classAverage/count($marks);
	echo("<br>Subject Averages are ");

	foreach($subjectAverages as $subject=>$value){
		echo $subject . "  = " . round($value,1)."     ";
	}//end foreach
	echo "<br>";	

}//end function printArray

//////////////////////////////////////////////////////////////////////////////////////////
function studentAverages($marks,&$averages){
	$average = 0;
	$totalMarks = 0;
	foreach($marks as $student=>$grades){
	
		foreach($grades as $subject=>$value){
			$totalMarks = $totalMarks + $value;
		}//end foreach
		
		$average = $totalMarks/count($grades);
		$averages[$student] = $average;
		$totalMarks = 0;
	
	}//end foreach
	
}//end funtion studentAverages
//////////////////////////////////////////////////////////////////////////////////////////
function findSubjectAverages($marks,&$subjectAverages){
	
	foreach($marks as $student=>$grades){
	
		foreach($grades as $subject=>$value){
			$subjectAverages[$subject] += $value;
		}//end foreach

	}//end foreach
	
	foreach($subjectAverages as $subject=>$total){
		$subjectAverages[$subject] = $subjectAverages[$subject] / count($marks);
	}//end foreach
	
}//end function findSubjectAverages

//////////////////////////////////////////////////////////////////////////////////////////
function analysisOverAverages($overallAverage, $studentAverages){
	$totalBelowAverage=0;
	
	foreach($studentAverages as $student=>$value){
		if(round($value,0) < round($overallAverage,0)){
			echo "Student " .$student . " with an average of " . round($value,1) ." is below the class average of ". round($overallAverage,1) . "</font><br>";
			$totalBelowAverage++;
		}//end if
	}//end foreach
	
	echo "Total number of students below the average is " .$totalBelowAverage;

}//end function AnalysisOver`

//////////////////////////////////////////////////////////////////////////////////////////

?>