using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Application
{
    class Program
    {
        static void Main()
        {
            mainMenu("");
        }

        //Q1. Main Menu
        static void mainMenu(string incorrect)
        {
            try
            {
                Console.WriteLine(" =========================================");
                Console.WriteLine("                Main Menu                 ");
                Console.WriteLine(" =========================================");
                Console.WriteLine("   1: Prime Number                   ");
                Console.WriteLine("   2: Prime Factorisation            ");
                Console.WriteLine("   3: Euclidean Algorithm            ");
                Console.WriteLine("   4: Extended Euclidian Algortithm  ");
                Console.WriteLine("   5: RSA Encryption                 ");
                Console.WriteLine("   6: RSA Decryption                 ");
                Console.WriteLine("   7: Exit Application             \n");

                Console.WriteLine("   {0}", incorrect);
                Console.Write("   Enter Option: ");

                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        prime("");
                        break;
                    case 2:
                        primeFactors("");
                        break;
                    case 3:
                        euclidianAlgorithm();
                        break;
                    case 4:
                        extEuclidianAlgorithm();
                        break;
                    case 5:
                        RSAEncryption();
                        break;
                    case 6:
                        RSADecryption();
                        break;
                    case 7:
                        
                        break;
                    default:
                        Console.Clear();
                        mainMenu("Incorrect Option, Enter A Number Between 1 and 6!");
                        break;
                }
            }
            
            catch
            {
                Console.Clear();
                mainMenu("Incorrect Option, Enter A Number Between 1 and 6!");
            }    
        }

        //Q1. Checks if number is prime
        static void prime(string incorrect)
        {
            Console.Clear();

            Console.WriteLine(" =========================================");
            Console.WriteLine("           Prime Number Checker           ");
            Console.WriteLine(" =========================================");

            try
            {
                Console.WriteLine(incorrect);
                Console.Write("   Enter a number: ");
                long number = long.Parse(Console.ReadLine());
                long answer = checkPrime(number);

                if (answer == 0)
                {
                    Console.WriteLine("\n   {0} is not a prime number.\n", number);
                }

                else
                {
                    Console.WriteLine("\n   {0} is a prime number.\n", number);
                }
            }
            
            catch 
            {
                prime("   Incorrect Option, enter number between 0 And 9,223,372,036,854,775,807!");
            }

            menuChoice(1, "");
        }

        //Q1a. Equation For Checking Prime
        private static int checkPrime(long number)
        {
            long x;
            long floor = (long)Math.Sqrt(number);

            if (number < 0)
            {
                return 0;
            }

            for (x = 2; x <= floor; x++)
            {
                if (number % x == 0)
                {
                    return 0;
                }
            }
            return 1;
        }

        //Q2. Checks prime factors of number
        static void primeFactors(string incorrect)
        {
            Console.Clear();

            Console.WriteLine(" =========================================");
            Console.WriteLine("              Prime Factors               ");
            Console.WriteLine(" =========================================");

            try
            {
                Console.WriteLine(incorrect);
                Console.Write("   Enter a Number: ");
                long a = long.Parse(Console.ReadLine());

                Console.Write("\n   The Prime Factors of {0} are [ ", a);

                for (long b = 2; a > 1; b++)
                {
                    while (a % b == 0)
                    {
                        a /= b;

                        Console.Write("{0} ", b);
                    }
                }

                Console.WriteLine("]\n");
            }

            catch
            {
                primeFactors(" Incorrect Option, enter number between 0 And 9,223,372,036,854,775,807!");
            }

            menuChoice(2, "");
        }

        //Q3
        static void euclidianAlgorithm()
        {
            Console.Clear();

            Console.WriteLine(" =========================================");
            Console.WriteLine("            Euclidian Algorithm          ");
            Console.WriteLine(" =========================================\n");

            Console.Write("   Enter 1st Number: ");
            long num1 = long.Parse(Console.ReadLine());

            Console.Write("   Enter 2nd Number: ");
            long num2 = long.Parse(Console.ReadLine());

            Console.Write("\n   The Greatest Common Divisor of {0} and {1} is ", num1, num2);
            while (num1 != 0 && num2 != 0)
            {
                if (num1 > num2)
                    num1 -= num2;

                else
                    num2 -= num1;
            }

            long gcd = Math.Max(num1, num2);

            Console.WriteLine("{0}", gcd);
            menuChoice(3, "");

	    } 

        //Q4
        static void extEuclidianAlgorithm()
        {
            Console.Clear();

            Console.WriteLine(" =========================================");
            Console.WriteLine("            ExtendedEuclidianAlgorithm    ");
            Console.WriteLine(" =========================================\n");

            Console.WriteLine("Function Incomplete!");
            menuChoice(6, "");
        }

        //Q5
        static void RSAEncryption()
        {
            Console.Clear();

            Console.WriteLine(" =========================================");
            Console.WriteLine("            RSA Encryption                ");
            Console.WriteLine(" =========================================\n");

            Console.WriteLine("Function Incomplete!");

            menuChoice(6, "");
		}
        

        //Q6
        static void RSADecryption()
        {
            Console.Clear();

            Console.WriteLine(" =========================================");
            Console.WriteLine("            RSA Encryption                ");
            Console.WriteLine(" =========================================\n");

            Console.WriteLine("Function Incomplete!");

            menuChoice(6, "");
        }

        static void returnToMenu()
        {
            Console.Clear();
            Main();
        }

        //Decides What to do if Enter or Escape is pressed 
        static void menuChoice(int choice, string incorrect)
        {
            Console.WriteLine(incorrect);
            Console.WriteLine("   Press Enter to check another number.");
            Console.WriteLine("   Press Escape to return to main menu.");
            ConsoleKeyInfo keyboard = Console.ReadKey();
            
            if (keyboard.Key != ConsoleKey.Escape && keyboard.Key != ConsoleKey.Enter)
            {
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write("                         ");
                Console.SetCursorPosition(0, Console.CursorTop - 3);

                menuChoice(choice, " ");
            }

            else if (keyboard.Key == ConsoleKey.Escape)
            {
                returnToMenu();
            }

            else if (keyboard.Key == ConsoleKey.Enter)
            {
                switch(choice)
                {
                    case 1:
                        prime("");
                        break;
                    case 2:
                        primeFactors("");
                        break;
                    case 3:
                        euclidianAlgorithm();
                        break;
                    case 4:
                        extEuclidianAlgorithm();
                        break;
                    case 5:
                        RSAEncryption();
                        break;
                    case 6:
                        RSADecryption();
                        break;
                }

            }
        }
    }
}
