val double = (i:Int) => i * 2

def higherOrder(x:Int, y:Int=>Int) = y(x)
higherOrder(5, double)

val triple = (i:Int) => i*3
higherOrder(6, triple)

def sayHello = (name:String) => "Hello" + " " + name
sayHello("Colin")

var y = 5
var multiplier = (x:Int)=> x * y
multiplier(10)