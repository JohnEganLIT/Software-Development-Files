import scala.annotation.tailrec

object TailRecursion extends App
{
  val numList = List.range(1, 10)
  println(numList + "\n")

  @tailrec
  private def sum(Ints: List[Int], accumulator: Int): Int = Ints match
  {

    case Nil => accumulator // If list is empty returns the accumulator.
    case head :: tail => sum(tail, accumulator + head) // Removes the head of the list, adds it to the accumulator and recursively calls sum.
  }

  println("Sum: " + sum(numList, 0) + "\n")


  @tailrec
  private def product(Ints: List[Int], accumulator: Int) : Int = Ints match
  {
    case Nil => accumulator
    case head :: tail => product(tail, accumulator * head)
  }

  println("Product: " + product(numList, 1) + "\n")


  @tailrec
  private def max(Ints: List[Int], accumulator: Int) : Int = Ints match
  {
    case Nil => accumulator
    case head :: tail => if(head > accumulator)max(tail, head) else max(tail, accumulator)

  }

  println("Max: " + max(numList, 0) + "\n")


  private def fibonacci(index: Int): Int =
  {
    @tailrec
    def getTailRec(index: Int, prev: Int, current: Int): Int =
    {
      if (index <= 0) current
      else getTailRec(index - 1, prev = prev + current, current = prev)
    }

    getTailRec(index, prev = 1, current = 0)
  }

  println("Fibonacci: ")
  for(num<-numList)println(num + " = " + fibonacci(num))
  println()


  def factorial(fibSeqTerm: Int) : Int =
  {
    @tailrec
    def calcFactorial(num: Int, accumulator: Int) : Int =
    {
      if (num == 1) accumulator
      else calcFactorial(num - 1, accumulator * num)
    }
    calcFactorial(fibSeqTerm, 1)
  }

  println("Factorial: ")
  for(num<-numList)println(num + "! = " + factorial(num))

}


