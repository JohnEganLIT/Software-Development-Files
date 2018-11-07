using System;

namespace DateAndTime
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime myValue = DateTime.Now;

            Console.WriteLine(myValue.ToString());
            Console.WriteLine(myValue.ToShortDateString());
            Console.WriteLine(myValue.ToShortTimeString());
            Console.WriteLine(myValue.ToLongDateString());
            Console.WriteLine(myValue.ToLongTimeString());

            Console.WriteLine(myValue.AddDays(3).ToLongDateString());
            Console.WriteLine(myValue.AddHours(3).ToShortTimeString());

            Console.WriteLine(myValue.AddDays(-3).ToShortDateString());

            Console.WriteLine(myValue.Month.ToString());
            Console.WriteLine(myValue.Year.ToString());

            DateTime myBirthday = new DateTime(1994, 09, 27);
            Console.WriteLine(myBirthday.ToShortDateString());

            DateTime myBirthday2 = DateTime.Parse("27/9/1994");
            TimeSpan myAge = DateTime.Now.Subtract(myBirthday2);

            Console.WriteLine(myAge.TotalDays);
        }
    }
}
