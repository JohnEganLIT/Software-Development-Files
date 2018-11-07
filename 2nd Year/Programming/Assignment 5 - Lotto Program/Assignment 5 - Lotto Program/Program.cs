using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Assignment_5___Lotto_Program
{
    class Program
    {
        static List<Lotto> lottoList = new List<Lotto>();
        static int[] winningNums = new int [6];

        static void Main()
        {
            Console.WriteLine("1. Set Up Data");
            Console.WriteLine("2. Display Data");
            Console.WriteLine("3. Enter 6 Winning Numbers");
            Console.WriteLine("4. Find Winner");
            Console.WriteLine("5. Match 3 ticket");
            Console.WriteLine("6. Write Results to File");
            Console.WriteLine("7. Read Results from File");
            Console.WriteLine("8. Exit");

            Console.Write("\nEnter Option: ");
            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    option1();
                    break;
                case 2:
                    option2();
                    break;
                case 3:
                    option3();
                    break;
                case 4:
                    option4();
                    break;
                case 5:
                    option5();
                    break;
                case 6:
                    option6();
                    break;
                case 7:
                    option7();
                    break;
                case 8:
                    Console.WriteLine("Goodbye :)");
                    break;
                default:
                    break;
            }
        }

        static void option1()
        {
            Random random = new Random();

            for (int x = 0; x < 1000; x++)
            {
                Lotto lotto = new Lotto();

                int tickNum = x;
                int num1 = random.Next(1, 43);
                int num2 = random.Next(1, 43);
                int num3 = random.Next(1, 43);
                int num4 = random.Next(1, 43);
                int num5 = random.Next(1, 43);
                int num6 = random.Next(1, 43);

                lotto.setDetails(tickNum, num1, num2, num3, num4, num5, num6);
                lottoList.Add(lotto);
                   
            }
            returnToMenu();
        }

        static void option2()
        {
            foreach(Lotto ticket in lottoList)
            {
                ticket.printDetails();
            }
            returnToMenu();
        }

        static void option3()
        {
            Console.WriteLine("Enter 6 ticket\n");

            for(int i = 0; i < 6; i++)
            {
                Console.Write("Enter Number {0}: ", i+1);
                winningNums[i] = Convert.ToInt32(Console.ReadLine());
            }
            returnToMenu();
        }

        static void option4()
        {
            foreach (Lotto ticket in lottoList)
            {
                if(winningNums[0] == ticket.GetUniqueNum1() && 
                    winningNums[1] == ticket.GetUniqueNum2() && 
                    winningNums[2] == ticket.GetUniqueNum3() && 
                    winningNums[3] == ticket.GetUniqueNum4() && 
                    winningNums[4] == ticket.GetUniqueNum5() &&
                    winningNums[5] == ticket.GetUniqueNum6())
                {
                    Console.WriteLine("Winning Ticket(s)");
                    ticket.printDetails();
                }
            }
            returnToMenu();
        }

        static void option5()
        {
            int counter = 0;

            foreach (Lotto ticket in lottoList)
            {
                for (int i = 0; i < 6; i++)
                {
                    if (winningNums[i] == ticket.GetUniqueNum1() || winningNums[i] == ticket.GetUniqueNum2() || 
                        winningNums[i] == ticket.GetUniqueNum3() || winningNums[i] == ticket.GetUniqueNum4() || 
                        winningNums[i] == ticket.GetUniqueNum5() || winningNums[i] == ticket.GetUniqueNum6())
                    {
                        counter++;
                    }         
                }

                if (counter >= 3)
                {
                    ticket.printDetails();
                }
                counter = 0;
            }

            returnToMenu();
        }

        static void option6()
        {
            //I have no idea how to get this to work properly
            /*
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("data.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            
            foreach (Lotto ticket in lottoList)
            {
                formatter.Serialize(stream, ticket);
            }

            stream.Close();
            */
            returnToMenu();
        }

        static void option7()
        {
            /*
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("data.bin", FileMode.Open, FileAccess.Read, FileShare.Read);

            Lotto ticket = (Lotto)formatter.Deserialize(stream);

            while (!stream.EndOfStream)
            {
                Console.WriteLine(ticket.GetTicketNum(), ticket.GetUniqueNum1(), ticket.GetUniqueNum2(), ticket.GetUniqueNum3(), ticket.GetUniqueNum4(), ticket.GetUniqueNum5(), ticket.GetUniqueNum6());
                stream.Close();
            }
            

            returnToMenu();
            */
        }

        static void returnToMenu()
        {
            Console.WriteLine("=================");
            Console.WriteLine("    Complete     ");
            Console.WriteLine("================="); 
            Console.WriteLine("Press Any Key To Return To Menu");
            Console.ReadLine();
            Console.Clear();
            Main();
        }
    }
}