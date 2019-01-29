// While Loop.
var x = 5
while(x >= 0)
{
  println(x)
  x -= 1
}

// Do While Loop.
var y = 5
do
{
  println(y)
  y-=1
}
while(y >=0)

// For Loop.
var a = 5
for(a <- 10 to 0 by -1) println(a)

var b = for(num <- 1 to 10) yield num + 1

var word = "Monday"
for(x <- 0 until word.length) println(word(x)) // Prints each letter one by one.
