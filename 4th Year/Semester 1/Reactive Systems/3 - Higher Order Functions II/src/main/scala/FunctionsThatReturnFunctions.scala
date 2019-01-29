object FunctionsThatReturnFunctions extends App
{
  // Takes a decorator function and returns it.
  def makeDecorator(fn: String => String) : String => String =
  {
    fn
  }

  // Creates a decorator function that concatenates "s" onto the end of the passed string.
  val plural = makeDecorator( word => word + "s")

  val lotsOfApples = plural("apple")

  // Creates a decorator function that concatenates brackets to the front and end of the passed string.
  val brackets = makeDecorator(word => "[" + word + "]")

  val inBrackets = brackets("pineapple")

  // Creates a decorator function that concatenates "Bacon and " onto the front of the passed string.
  val bacon = makeDecorator(word => "Bacon and " + word)
  val withBacon = bacon("eggs")
}

