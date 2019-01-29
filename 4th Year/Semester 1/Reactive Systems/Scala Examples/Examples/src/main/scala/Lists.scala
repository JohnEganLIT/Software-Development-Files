object Lists extends App
{
  val empty: List[Nothing] = List() // Creates empty list.
  println(empty)

  var a = List(3,0, "Hello")
  println(a)

  var x1 = List(1,2,3,4,5,6)
  println(x1)

  var x2 = 1::2::3::4::5::6::Nil // Cons operator.
  println(x2)

  var x3 = List.range(10,20) // Creates list with every number from 10 to 20.
  println(x3)

  var x4 = List.range(3,21,3) // Start at 3, go to 21 and step every 3rd number.
  println(x4)

  var x5 = x1:::x3 // Concatenates x1 and x3.
  println(x5)

  var x6 = List.concat(x1,x3) // Concatenates x1 and x3.
  println(x6)

  x1.foreach(println)
  var sum=0
  x1.foreach(sum+=_) // Iterates through and adds values together. Underscore represents each iterated value.
  println(sum)

  var rainbow = List("Red", "Orange", "Yellow", "Green", "Blue", "Indigo", "Violet")
  for(c<-rainbow)println(c) // Prints values in rainbow

  var z = x1.map(_*2) // Multiples every value in x1 by 2.
  println(z)
}
