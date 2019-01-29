package com.mad.lab2_temperatureconverter;

public class ConverterUtil
{
    // Converts to celsius.
    public static float convertFahrenheitToCelsius(float fahrenheit)
    {
        return ((fahrenheit - 32) * 5/9);
    }

    // Converts to fahrenheit.
    public static float convertCelsiusToFahrenheit(float celcius)
    {
        return ((celcius * 9)/5) + 32;
    }
}
