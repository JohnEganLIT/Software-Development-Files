package Measurement

object ImperialLength extends SystemOfMeasurement {

  override type CompatibleUnit = Foot

  override def create(n:Double) = new Foot {
    override val quantity:Double = n
  }

  abstract class Foot extends AbstractUnit {
    override def symbol = "ft"
  }
  val Foot = create(1.0)
  val Yard = create(3.0)
}
