using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Classes
{
    public class MyGenericClass<T>
    {
        public T MyVariable { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var a = new MyGenericClass<int>();
            a.MyVariable = 5;

            var b = new MyGenericClass<string>();
            b.MyVariable = "Hello";
        }
    }
}
