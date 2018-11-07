object Singletons
{
  // Using the object keyword creates singletons.
  object HelloWorld
  {
    def main(args:Array[String]): Unit =
    {
      println("Hello World!")
    }
  }

  println(HelloWorld.main(null))
}
