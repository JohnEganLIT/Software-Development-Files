// Using directive allows access to classes in other namespaces without having
// to manually type the namespace each time e.g System.Console.ReadLine();
using System;
using System.Linq;
using System.Text;

namespace Basics
{
    // AssemblyInfo.cs contains information about program version numbers, company name etc. --->
    // References contains .Net Framework class libraries, assemblies, Com components etc. --->
    // App.config contains XML used to configure the project. --->
    class Program
    {
        // Access Modifiers.
        public string test1;                // Unrestricted access.
        protected string test2;             // Access from this class and derived classes.
        internal string test3;              // Access from this assembly eg. .exe or .dll file.
        protected internal string test4;    // Access from this assembly or derived classes.
        private string test5;               // Access from this class.

        // Static functions & variables cannot be instantiated. It won't exist in other instances of the Program class.
        static void Main(string[] args)
        {
            // Variables.
            byte myByte = 255;                          // 8 bits.
            char myChar = 'a';                          // 16 bits.
            short myShort = 32767;                      // 16 bits.
            int myInt = -2147483647;                    // 32 bits.
            uint myUnsignedInt = 4294967295;            // 32 bits.
            float myFloat = 1.2345f;                    // 32 bits.
            double myDouble = 1.2345;                   // 64 bits.
            decimal myDecimal = (decimal)1.2345D;       // 128 bits.
            bool myBool = true;                         // 1 Byte

            //Console input/output
            Console.Write("Enter a string: ");
            string response = Console.ReadLine();
            Console.WriteLine($"Your response was {response}");

        }
    }
}

/*
--------------
 Tips & Stuff
--------------
1. To rename all instaces of a variable, select the variable, hold control and double click R
2. Write comments on everything
3. Press ctrl, shift, space too see overloads of a function
4. Use alt-enter to create functions you have typed the call to
5. Use the call stack in vs to see what functions are on the stack in memory

Capitalisation 
1. Variable = variableName
2. Public member = VariableName
3. Function = MyFunction()

C# Coding Conventions
https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/inside-a-program/coding-conventions


*/

