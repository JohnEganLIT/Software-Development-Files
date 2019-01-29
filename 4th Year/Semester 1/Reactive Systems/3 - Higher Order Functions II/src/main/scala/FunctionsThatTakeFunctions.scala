object FunctionsThatTakeFunctions extends App
{
  // Returns the passed string with "s" concatenated on the end.
  def simplePlural(word: String) = word+"s"

  // This function accepts 2 arguments. (1)A String (2)A function that matches the signature.
  // In this case that signature is any function that takes a string and returns a string.
  // It then passes "aWord" into the decorator function which represents the function passed into decorate.
  def decorate(aWord: String, decorater: String => String) = decorater(aWord)

  // Passes "apple" and the simplePlural function into decorate. Decorate then runs simplePlural and passes "apple" to it. Val apples is set to the result.
  val apples = decorate("apple", simplePlural)
  println(apples)

  // Concatenates parentheses onto the front and end of the passed string.
  def wrapInParens(word: String) = "(" + word + ")"

  // Passes "pineapple" and the wrapInParens function into decorate. Decorate then runs wrapInParens and passes "pineapple" to it. Val inParens is set to the result.
  val inParens = decorate("pineapple", wrapInParens)
  println(inParens)

  // Concatenates "Bacon and " onto the front of the passed string.
  def addBacon(word:String) = "Bacon and " + word

  // Passes "eggs" and the addBacon function into decorate. Decorate then runs addBacon and passes "eggs" to it. Val bacon is set to the result.
  val bacon = decorate("eggs", addBacon)
  println(bacon)
}
