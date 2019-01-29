// Takes number. If it's negative makes it positive.
def abs(x: Int) = if(x < 0) -x else x
abs(-5)
abs(5)

def factorial(n:Int) =
{
  var r = 1
  for(i <- 1 to n) r = r*i
  r
}
factorial(5)

def factorial2(n:Int) :Int = if(n<=0) 1 else n* factorial2(n-1)
factorial2(5)

def printName(left:String="[", firstName:String, lastName:String, right:String="]") // Left and right are default values.
{
  println(left + firstName + " " + lastName + right)
  printName(lastName = "Maher", firstName = "Colin") // The order is backwards but it still works. Scala can use the variable names instead of the order.
}

def sum(args:Int*) =
{
  var result = 0
  for(arg <- args) result += arg
    result
}

sum(1, 2, 3, 4, 5)


