object Objects extends App
{
  var account = new BankAccount(4000, "Savings", "Colin", "Maher", "That Road, That Street, Limerick", "0831234567"  )
  account.displayDetails()

  var account2 = new BankAccount(1950, "Checkings", "Jimmy", "Reilly", "Fake Road, Fake Street, Tipperary", "0879876543"  )
  account2.displayDetails()

  var account3 = new BankAccount(2230, "Savings", "Tom", "Reidy", "Some Place, Somewhere, Dublin", "0862837463"  )
  account2.displayDetails()

  object Client
  {
    var firstName = ""
    var lastName = ""
    var address = ""
    var phone = ""

    def getTuple: (String, String, String, String) = (firstName, lastName, address, phone)
  }

  class BankAccount(balance: Float, accountType: String, firstName: String, lastName: String, address: String, phone: String)
  {
    Client.firstName = firstName
    Client.lastName = lastName
    Client.address = address
    Client.phone = phone

    //private var StartBal: Float = 0
    private val Balance : Float = balance
    private val AccountType: String = accountType

    def displayDetails(): Unit =
    {
      val tuple = Client.getTuple

      println("First Name: " + tuple._1)
      println("Last Name: " + tuple._2)
      println("Address: " + tuple._3)
      println("Phone: " + tuple._4)
      println("Balance:" + Balance )
      println("Account Type: " + AccountType)
      println()
    }
  }
}

