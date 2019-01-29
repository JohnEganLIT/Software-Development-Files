package Challenges

object Decisions extends App
{
  var grades = List(100, 99, 75, 67, 89, 85, 92, 93, 60, 97)

  for(g <- grades)
    if(g > 92) println("A")
    else if(g > 85) println("B")
    else if(g > 76) println("C")
    else if(g > 68) println("D")
    else println("F")

  var count:Double = 0.0
  for(g <- grades) count=count+1
  val sum =  grades.foldLeft(0.0) (_+_) // Adds all values in list

  def avg(c:Double):Double =
  {
    sum/c
  }

  println(avg(count))
}