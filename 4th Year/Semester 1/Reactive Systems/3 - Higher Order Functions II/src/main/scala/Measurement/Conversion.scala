package Measurement

object Conversion {
  //Define the type of conversion using type alias
  type ConverterFunction =(SystemOfMeasurement#AbstractUnit) => Double

  val noConversion:ConverterFunction = { (m: SystemOfMeasurement#AbstractUnit) => m.quantity }
  val metreToFoot:ConverterFunction = { (m: SystemOfMeasurement#AbstractUnit) => m.quantity * 3.281 }
  val footToMetre:ConverterFunction = { (f: SystemOfMeasurement#AbstractUnit) => f.quantity * 0.305 }


  //Map of convertor functions that can be retrieved using a string
  val converters = Map[String, Map[String,ConverterFunction] ] (
    "m" -> Map( "m" -> noConversion, "ft" -> metreToFoot),
    "ft" -> Map( "ft" -> noConversion, "m" -> footToMetre)
  )


////  Convert between ImperialMass and MetricMass
//
//  //A Gram is 0.002 Pounds
//val gramToPound:ConverterFunction = __________________
//val poundToGram:ConverterFunction = __________________
//val converters = Map ... {
//  ...
//  "g" -> Map("g" -> ________, "lb" -> ________),
//  "lb" -> __________________________________
//}
}
