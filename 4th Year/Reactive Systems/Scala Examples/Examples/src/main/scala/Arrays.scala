object Arrays extends App
{
  var movies:Array[String] = new Array[String] (5)
  movies(0) = "Bladerunner 2049"

  var furniture = Array("Chair", "Couch", "Table")

  println(movies) // Prints address of where array is stored.
  println(movies(0)) // Prints value at position 0.

  println(furniture)
  println(furniture(0))

  def print(strArray:Array[String]):Unit = strArray.foreach(println) // Iterates through and prints every element of array.
  print(furniture)

  var t = new Array[AnyVal](3) // Allows all data types.
  t(0) = 1
  t(1) = true
  t(2) = 3.0
}
