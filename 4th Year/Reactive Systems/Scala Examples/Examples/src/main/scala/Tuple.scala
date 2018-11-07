object Tuple extends App
{
  // Tuples start at 1 instead of 0.
  val tuple = (1, false, "Scala")
  println(tuple)

  val tuple2 = "computer" -> "Dell XPS13" // Arrow makes a relationship between the elements.
  println(tuple2)
  println(tuple2._2) // Prints second value from Tuple 2.

  val t = "a" -> 25
  println(t)

  def div10(n:Int):(Int, Int, Int) = (n/100, n/10, n%10) // Returns a Tuple.

  val (hundreds, tens, ones) = div10(185)

  println(hundreds)
  println(tens)
  println(ones)

}
