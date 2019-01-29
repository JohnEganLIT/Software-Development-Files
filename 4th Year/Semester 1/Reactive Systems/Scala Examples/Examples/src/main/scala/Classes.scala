object Classes extends App
{
  class Computer(val make:String, val model:String, val ram:String)
  {
    override def toString:String = "["+make + ", " + model + ", " + ram + "]\n"
  }

  val myComputer = new Computer("Dell", "XPS13", "16GB")

  // Uses the overridden toString method in Computer class.
  println(myComputer.toString)

  println("Make: " + myComputer.make)
  println("Model: " + myComputer.model)
  println("Ram: " + myComputer.ram)

  val computers = List(new Computer("Dell", "Laptop", "16GB"),
    new Computer("HP", "Desktop", "32gb"),
    new Computer("Macbook", "Laptop", "8gb"),
    new Computer("Asus", "Ultrabook", "16gb"))

  // Gets the first element in the list.
  val first = computers.head
  println(first)

  // Gets every element except the first from he list.
  val rest = computers.tail
  println(rest)
}
