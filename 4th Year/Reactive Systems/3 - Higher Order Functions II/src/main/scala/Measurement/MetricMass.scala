package Measurement

object MetricMass extends SystemOfMeasurement
{
  override type CompatibleUnit = Gram

  // Overrides the abstract create function from SystemOfMeasurement.
  override def create(n:Double) = new Gram
  {
    // Sets quantity to the passed value n.
    override val quantity:Double = n
  }

  // Inherits from AbstractUnit.
  abstract class Gram extends AbstractUnit
  {
    // Overrides the symbol string declared in abstract unit. Sets the symbol for gram.
    override def symbol = "g"
  }

  // Sets the value of a gram to 1.
  val Gram = create(1.0)

  // Sets the value of a kilogram to 1000. There is 1000 grams in a kilo.
  val Kilogram = create(1000.0)

}

