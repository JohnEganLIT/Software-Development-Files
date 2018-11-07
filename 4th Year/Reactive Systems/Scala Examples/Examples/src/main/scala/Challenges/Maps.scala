package Challenges

object Maps extends App
{
  var movies = Map("Finding Nemo" -> "G", "Finding Dory" -> "PG", "Men in Black" -> "PG-13", "The Avengers" -> "PG-13", "The Room" -> "18")

  println("Finding Nemo: " + movies("Finding Nemo"))
  println("Finding Dory: " + movies("Finding Dory"))
  println("Men in Black: " + movies("Men in Black"))
  println("The Avengers: " + movies("The Avengers"))
  println("The Room: " + movies("The Room"))

  println

  movies += "Moon" -> "R"
  movies -= "Finding Dory"

  for(m<-movies)println(m._1 + ":" + m._2)

  println

  movies.foreach(println)

}
