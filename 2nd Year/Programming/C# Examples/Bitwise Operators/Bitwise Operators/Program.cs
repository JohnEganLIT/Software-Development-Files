using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitwise_Operators
{
    public enum SomeValues
    {
        Red = 1, 
        Blue = 2,
        Green = 4,
        White = 8,
        Orange = 32,
        Yellow = 64,
        Pink = 128
    }

    class Program
    {
        static void Main(string[] args)
        {

            //
            // Bitwise Operators.
            //
            // And & (Both).
            // OR | (Either).
            // Xor ^ (Exclusive or, different).
            // Not ~ (Invert).

            byte a = 25;
            byte b = 14;

            var result1 = a & b;
            var result2 = a | b;
            var result3 = a ^ b;
            var result4 = ~a;       

            Console.WriteLine($"A: {Convert.ToString(a, 2).ToString().PadLeft(8, '0')}");
            Console.WriteLine($"B: {Convert.ToString(b, 2).ToString().PadLeft(8, '0')}");
            Console.WriteLine("---------");
            Console.WriteLine($"And: {Convert.ToString(result1, 2).PadLeft(8, '0')}");
            Console.WriteLine($"Or: {Convert.ToString(result2, 2).PadLeft(8, '0')}");
            Console.WriteLine($"Xor: {Convert.ToString(result3, 2).PadLeft(8, '0')}");
            Console.WriteLine($"Not A: {Convert.ToString(result4, 2).PadLeft(8, '0')}");

            //
            // Bitwise Shifting.
            //
            // Left <<.
            // Right >>.

            byte c = 25;

            Console.WriteLine($"Original: {Convert.ToString(c, 2).PadLeft(8, '0')}");

            // Shifts bytes to left once.
            c = (byte)(c << 1);

            Console.WriteLine($"Shifted 1 left: {Convert.ToString(c, 2).PadLeft(8, '0')}");

            // Invert Booleans.
            var d = true;
            d ^= true;

            //
            // Enum Flags.
            //

            var someVals = (byte)(SomeValues.Blue | SomeValues.White);

            // Each bit represents a colour
            Console.WriteLine($"Colours: {Convert.ToString((byte)someVals, 2).PadLeft(8, '0')}");

            // Check if blue is contained within someVals
            if((someVals & (byte)SomeValues.Blue) == (byte)SomeValues.Blue)
            {
                Console.WriteLine("Blue was included");
            }

            // Check if blue is contained within someVals
            if ((someVals & (byte)SomeValues.White) == (byte)SomeValues.White)
            {
                Console.WriteLine("White was included");
            }

            //
            // Masking
            //
            // 0011100 Input
            // 0000010 Important bit
            // 0000000 Rest of input is masked 
            // Output is masked or not mask, which tells you if that bit there

            var input = (byte)SomeValues.White;
            var mask = (byte)SomeValues.Blue;
            var r = input * mask;

            Console.ReadLine();
        }
    }
}
