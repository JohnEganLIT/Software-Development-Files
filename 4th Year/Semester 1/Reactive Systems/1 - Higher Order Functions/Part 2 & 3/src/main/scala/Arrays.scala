object Arrays extends App
{
  var numbers = Array(23, 15, 8, 4, 2, 17, 21, 9, 1, 6)

  def Sum(n:Array[Int]):Int = n.sum

  def Avg(n:Array[Int]):Float = Sum(n).toFloat/n.length

  def Min(n:Array[Int]):Int = n.min

  def Max(n:Array[Int]):Int = n.max

  println("Sum " + Sum(numbers))
  println("Average " + Avg(numbers))
  println("Min " + Min(numbers))
  println("Max " + Max(numbers))
}
