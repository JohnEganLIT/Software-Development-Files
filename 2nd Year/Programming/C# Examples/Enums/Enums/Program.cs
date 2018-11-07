using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enums
{
    //[Flags]  <-- This tells the program that this is a collection of flags. User permissions etc
    public enum AnimationDirection
    {
        Unknown = 0,
        Left = 1,
        Right = 2,
        Up = 3,
        Down = 4
    }

    class Program
    {
        static void Main(string[] args)
        {
            var a = AnimationDirection.Left;
            Animate(a);

            // Get value of a.
            var aAsInt = (int)a;

            // Change it back to enum.
            var aBackAsItself = (AnimationDirection)a;

            // Directly create enum of value 4 (Down).
            var directCreate = (AnimationDirection)4;

            // Enumerating the enum.
            foreach (var val in Enum.GetValues(typeof(AnimationDirection)))
                Console.WriteLine(val);
            foreach (var val in Enum.GetNames(typeof(AnimationDirection)))
                Console.WriteLine(val);

            Console.Read();
        }

        public static void Animate(AnimationDirection direction)
        {
            switch(direction)
            {
                case AnimationDirection.Left:
                    Console.WriteLine("Animating left...");
                    break;
                case AnimationDirection.Right:
                    Console.WriteLine("Animating Right...");
                    break;
                case AnimationDirection.Up:
                    Console.WriteLine("Animating Up...");
                    break;
                case AnimationDirection Down:
                    Console.WriteLine("Animating Down...");
                    break;
                default:
                    Console.WriteLine("I don't know what to do...");
                    break;

            }
        }
    }
}
