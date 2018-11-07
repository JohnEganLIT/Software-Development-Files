using System;
using System.Collections.Generic;
using System.Numerics;

namespace Application
{
    class Program
    {
        static void Main()
        {
            mainMenu("");
        }

        //Q1. Main Menu
        static string mainMenu(string errorMsg)
        {
            bool exit = false;

            do
            {
                try
                {
                    Console.Clear();

                    Console.WriteLine("\t=========================");
                    Console.WriteLine("\t|       Main Menu       |");
                    Console.WriteLine("\t=========================\n");
                    Console.WriteLine("\t1: Sum of Multiples of 3 and 5");
                    Console.WriteLine("\t2: Prime Factorization ");
                    Console.WriteLine("\t3: Sum of Fibonacci Numbers");
                    Console.WriteLine("\t4: Extended Euclidian Algorithm");
                    Console.WriteLine("\t5: RSA Encryption");
                    Console.WriteLine("\t6: RSA Decryption");
                    Console.WriteLine("\t7: Exit Application\n");

                    Console.WriteLine("   {0}", errorMsg);
                    Console.Write("\tEnter Option: ");
               
                    int option = int.Parse(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            program1("");
                            break;
                        case 2:
                            program2("");
                            break;
                        case 3:
                            program3("");
                            break;
                        case 4:
                            program4("");
                            break;
                        case 5:
                            program5("");
                            break;
                        case 6:
                            program6("");
                            break;
                        case 7:
                            Console.WriteLine("\n     Goodbye :)\n");
                            exit = true;
                            break;
                        default:
                            Console.Clear();
                            return mainMenu("\tIncorrect Option, Enter A Number Between 1 and 6!");
                    }
                }

                catch
                {
                    Console.Clear();
                    return mainMenu("\tIncorrect Option, Enter A Number Between 1 and 6!");
                }
            }
            while (exit == false);

            return("");
        }

        //Q1. Adds the multiples of 3 and 5
        static string program1(string errorMsg)
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("\t===================================");
                Console.WriteLine("\t|   Sum of Multiples of 3 and 5   |");
                Console.WriteLine("\t===================================");
                Console.WriteLine("\tCalculate sum of multiples of 3 and 5 below entered number.\n");

                try
                {
                    Console.WriteLine(errorMsg);

                    Console.Write("\tEnter a number: ");
                    int number = Convert.ToInt32(Console.ReadLine());

                    long sum = 0;

                    for (int i = 3; i < number; i += 3)
                    {
                        sum += i;
                    }

                    for (int x = 5; x < number; x += 5)
                    {
                        if (x % 3 > 0)
                        {
                            sum += x;
                        }
                    }

                    Console.WriteLine("\n\tThe Sum of multiples of 3 and 5 below {0:N0} = {1:N0}.", number, sum);
                }

                catch
                {
                    return program1("\tIncorrect Option, enter number between 0 And 2,147,483,647!");
                }

                if (returnToMenu() == true)
                    return("");
            }
        }

        //Q2. Checks prime factors of number
        static string program2(string errorMsg)
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("\t=========================");
                Console.WriteLine("\t|  Prime factorization  |");
                Console.WriteLine("\t=========================");
                Console.WriteLine("\tMay take a couple of seconds!\n");

                try
                {
                    List<long> factorList = new List<long>();

                    Console.WriteLine(errorMsg);

                    Console.Write("\tEnter a Number: ");
                    long number = long.Parse(Console.ReadLine());
                    long n = number;

                    for (long k = 2; k <= n; k++)
                    {
                        while (n % k == 0)
                        {
                            n /= k;
                            factorList.Add(k);
                        }
                    }

                    if (factorList.Count > 1)
                        Console.Write("\n\tThe Prime factors of {0:N0} are [", number);

                    foreach (long factor in factorList)
                    {
                        if (factorList.Count > 1) //If there is more than 1 item in the list then n is not a prime number
                        {
                            Console.Write(" {0:N0}", factor);
                        }

                        else
                            Console.WriteLine("\n\t   {0:N0} is a prime number", factor);
                    }

                    if (factorList.Count > 1)
                        Console.Write(" ]\n");

                }

                catch
                {
                    return program2("\tIncorrect Option, enter number between 0 And 2,147,483,647!");
                }

                if (returnToMenu() == true)
                    return("");
            }

        }

        //Q3. Adds Fibonacci Numbers
        static string program3(string errorMsg)
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("\t==============================");
                Console.WriteLine("\t|  Sum of Fibonacci Numbers  |");
                Console.WriteLine("\t==============================");

                try
                {
                    Console.WriteLine(errorMsg);

                    Console.Write("\tEnter a Number: ");
                    long number = int.Parse(Console.ReadLine());

                    long a = 1;
                    long b = 1;
                    long sum = 0;

                    do
                    {
                        long temp = a;
                        a = b;
                        b = temp + b;

                        if (b % 2 == 0)
                        {
                            sum += b;
                        }
                    }
                    while (sum < number);

                    Console.WriteLine("\n\tThe sum of all even fibonacci numbers below {0:N0} = {1:N0}.", number, sum);
                }

                catch
                {
                    return program3("\tIncorrect Option, enter number between 0 And 2,147,483,647!");
                }

                if (returnToMenu() == true)
                    return("");
            }
        }

        //Q4
        static string program4(string errorMsg)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\t====================================");
                Console.WriteLine("\t|   Extended Euclidian Algorithm   |");
                Console.WriteLine("\t====================================\n");

                List<int> resultList = new List<int>();

                try
                {
                    Console.WriteLine(errorMsg);

                    Console.Write("\tEnter 1st Number: ");
                    int num1 = int.Parse(Console.ReadLine());

                    Console.Write("\tEnter 2nd Number: ");
                    int num2 = int.Parse(Console.ReadLine());

                    if (num1 < num2) //If num1 is less than num2 it switches them
                    {
                        int temp = num1;
                        num1 = num2;
                        num2 = temp;
                    }

                    int a = num2;
                    int b = 0;
                    int x0 = 1;
                    int y0 = 0;
                    int x1 = 0;
                    int y1 = 1;
                    int x = 0, y = 0;

                    while (a > 1)
                    {
                        a = num1 % num2;
                        b = num1 / num2;
                        x = x0 - b * x1;
                        y = y0 - b * y1;
                        x0 = x1;
                        y0 = y1;
                        x1 = x;
                        y1 = y;
                        num1 = num2;
                        num2 = a;
                    }

                    resultList.Add(a);
                    resultList.Add(x);
                    resultList.Add(y);

                    Console.WriteLine("\n\tGCD: {0}", resultList[0]);
                    Console.WriteLine("\tX: {0}", resultList[1]);
                    Console.WriteLine("\tY: {0}", resultList[2]);
                }

                catch
                {
                    return program4("\tIncorrect option, enter number between 0 And 2,147,483,647!");
                }

                if (returnToMenu() == true)
                    return("");
            }
        }

        //Q5
        static string program5(string errorMsg)
        {
            Console.Clear();

            Console.WriteLine("\t===========================");
            Console.WriteLine("\t|      RSA Encryption      |");
            Console.WriteLine("\t===========================\n");

            Console.WriteLine("\tFunction Incomplete!");

            if (returnToMenu() == true)
                return ("");

            return ("");
        }


        //Q6
        static string program6(string errorMsg)
        {
            Console.Clear();

            Console.WriteLine("\t=========================================");
            Console.WriteLine("\t|        C = RSAEncrypt (P, e, n) t       ");
            Console.WriteLine("\t=========================================\n");

            Console.WriteLine("\tFunction Incomplete!");

            if (returnToMenu() == true)
                return ("");

            return ("");
        }

        //Decides What to do if Enter or Escape is pressed 
        static bool returnToMenu()
        {
            Console.WriteLine("\n\tPress Enter to check another number.");
            Console.WriteLine("\tPress Escape to return to main menu.");

            do
            {
                ConsoleKeyInfo keyboard = Console.ReadKey(true);

                if (keyboard.Key == ConsoleKey.Escape)
                {
                    return true;
                }

                else if (keyboard.Key == ConsoleKey.Enter)
                {
                    return false;
                }
            }
            while (true);
        }
    }
}

