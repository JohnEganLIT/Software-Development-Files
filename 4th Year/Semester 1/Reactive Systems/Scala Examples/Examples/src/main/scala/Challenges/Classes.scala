package Challenges

object Classes extends App
{
  case class Employee(id: Int, firstName: String, lastName: String)
  {
    override def toString:String = "Employee ID: " + id + "\nFull Name: " + firstName + " " + lastName + "\n"
  }

  var employees = List(Employee(17364, "Colin", "Maher"),
    Employee(95723, "Jimmy", "Reilly"))

  employees.foreach(println)

}
