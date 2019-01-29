object Sets extends App
{
  println("Welcome to the Scala Worksheet")
  var fruit = Set("apple", "orange", "peach", "banana")

  println(fruit("peach")) // Returns true or false if set contains peach.
  println(fruit("potato"))

  var s = Set(1,2,3,4,5,5,4,3,2,1) // Repeated values are stripped from the set.
  println(s)

  s+= 6 // Adds 6 to s set.
  s-= 4 // Removes 4 from set.
  println(s)

  if(s.isEmpty)
    println("Set was empty")
  else
    println(s.head) // Prints first element.
    println(s.tail) // Prints everything after first element.

  var s1 = fruit ++ s // Combines 2 sets.

  val s2 = Set(1,2,3)
  println(s2.&(s)) // Gets overlap between s2 and s.

  var g = Map(1->"Milk", 2->"Bread", 3->"Juice", 4->"Eggs")

  println(g)
  println(g(1)) // Prints first element of map.

  g=g+(5->"Potatoes") // Adds potatoes to map.
  println(g)

  println(g.get(6)) // Gets element from map. Returns none if it doesn't exist.
}
