package Measurement

object ImperialMass extends SystemOfMeasurement
{
  override type CompatibleUnit = Pound

  // Overrides the abstract create function from SystemOfMeasurement.
  override def create(n:Double) = new Pound
  {
    // Sets quantity to the passed value n.
    override val quantity:Double = n
  }

  // Inherits from AbstractUnit.
  abstract class Pound extends AbstractUnit
  {
    // Overrides the symbol string declared in abstract unit. Sets the symbol for pound.
    override def symbol = "pnd"
  }

  // Sets value of pound to 1.
  val Pound = create(1.0)

  // Sets value of stone to 14. There is 14 pounds in a stone.
  val Stone = create(14.0)
}
