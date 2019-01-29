package Measurement
//SystemOfMeasurement is abstract
//because it can never be used on
//its own. We will derive subtypes
//for Metric and Imperial systems


abstract class SystemOfMeasurement {

//  subtypes must specify CompatibleUnit must have quantity and symbol
//  AbstractUnit subtypes create and output CompatibleUnit

//  We use the type keyword to define CompatibleUnit.
//  The <: syntax indicates that the CompatibleUnit must be derived from AbstractUnit.
// Also, CompatibleUnit is abstract since it is not assigned a type. Hence we will need to specify it in a subtype.
//  We can create abstract types that must be enforced in subtypes.
// This allows the compiler prevent subtle subtype errors at the time

  type CompatibleUnit <: AbstractUnit

//  The create function is abstract since it has no body, but it is defined in terms of CompatibleUnit.
// So, the create in a subtype will only work with whatever is specified as the CompatibleUnit
  def create(n:Double):CompatibleUnit

//  AbstractUnit must have quantity and symbol and must only add compatibleUnits

  abstract class AbstractUnit {
    val quantity: Double

    def symbol: String

    //    We specify that addition only works on CompatibleUnit.
    //    Also, we use the SystemOf-Measurement create function to ensure that we create a CompatibleUnit.
    //    All functions make use of the abstract type CompatibleUnit.
    //    Since type is an alias, the compiler substitutes it for the type in subclass.

    def +(other: CompatibleUnit): CompatibleUnit =
      create(this.quantity + other.quantity)

    //    We also implement toString to make it easier for testing and printing to the console.
    override def toString = quantity + symbol

    //    We are converting from another AbstractUnit defined in a SystemOfMeasurement
    def from(other: SystemOfMeasurement#AbstractUnit): CompatibleUnit = {
      //      Lookup the conversion function to use from the map of converters based on the symbol of the AbstractUnit
      //      passed in, and this AbstractUnit’s symbol .
      val converter = Conversion.converters(other.symbol)(this.symbol)
      create(converter(other))

      //      This allows us to write code such as
      //      val twoFeet = ImperialLength.Foot * 2
      //      val metresFromTwoFeet = MetricLength.Metre.from(twoFeet)
      //      val f = ImperialLength.Feet.from(MetricLength.Metre*2)
    }
  }
}

