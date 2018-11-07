using System;

namespace String_Concatenation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Jimmy";
            int age = 56;
            double worth = 54958.34;

            // This method of string concatenation is called Interpolated Strings
            string c = ($"Your name is {name}, you are {age} years old and you are worth {worth:c}.");     

            Console.WriteLine(c);

            Console.ReadLine();
        }
    }
}
