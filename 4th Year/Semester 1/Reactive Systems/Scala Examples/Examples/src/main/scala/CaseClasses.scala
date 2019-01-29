object CaseClasses
{
  case class Money(amount: Int = 1, currency: String = "USD")
  {
    // Define a function called "+" to add two money object.
    def +(other: Money) : Money = Money(amount + other.amount)
  }

  // Creates a money object with 1 USD.
  val defaultAmount = Money()

  // Creates a money object with 5 USD.
  val fiveDollars = Money(5)

  // Creates a money object with 5 USD.
  val fiveDollars2 = Money(5, "USD")

  // Creates a money object with 1 EUR.
  val euro = Money(currency = "EUR")

  // Copy to make a new Money object.
  val tenDollars: Money = euro.copy(10)
  val tenDollars2: Money = tenDollars.copy(currency = "USD")

  val moneyList = List(Money(), Money(50, "GBP"), Money(45, "EUR"))

  // Use the + definition above
  println("add 10 + 15: " + {Money(10) + Money(15)})
}
