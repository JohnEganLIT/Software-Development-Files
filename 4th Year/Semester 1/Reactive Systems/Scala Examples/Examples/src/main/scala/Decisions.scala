object Decisions extends App
{
  var hoursWorked = 40
  var rate = 10

  def earnings(h:Double):Double =
  {
    if(h<=40)
      h*rate

    else
    (h-40)*rate*1.5 + 40*rate
  }

  println("€" + earnings(hoursWorked))
  println("€" + earnings(30))
  println("€" + earnings(45))

  var x = -1
  if(x < 0)
    println("negative")

  else if(x == 0)
    println("zero")

  else
    println("positive")

  val day1 = "FRI"
  val day2 = "SAT"
  val day3 = "AAA"

  val result = day3 match
  {
    case "MON" | "TUE" | "WED" | "THUR" | "FRI" => "Weekday"
    case "SAT" | "SUN" => "Weekend"
    case _ => "Invalid Day"
  }

  println(result)
}
