object SpecialFunctions extends App
{
  println("Welcome to the Scala worksheet")

  // Anonymous Function
  val f = (x:Int) => x+1
  println(f(5))

  val doubler = (i:Int)=>{i*2}

  println(doubler(6))

  // Higher Order function - Function that accepts a function as a parameter
  def someOperation(f:(Int, Int)=>Int): Unit = {println(f(5,5))}

  val add = (x:Int, y:Int) => x+y
  someOperation(add)

  def greeting() = (name:String)=>{"Hello " + name}
  val g = greeting()
  println(g("Colin"))

  var y = 5
  val multiplier = (x:Int) => x*y
  println(multiplier(4))

}
