using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5___Lotto_Program
{
    [Serializable]
    class Lotto
    {
        private int ticketNum;
        private int uniqueNum1;
        private int uniqueNum2;
        private int uniqueNum3;
        private int uniqueNum4;
        private int uniqueNum5;
        private int uniqueNum6;

        public void printDetails()
        {
            Console.WriteLine("{0}: {1}-{2}-{3}-{4}-{5}-{6}", ticketNum, uniqueNum1, uniqueNum2, uniqueNum3, uniqueNum4, uniqueNum5, uniqueNum6);
        }

        public void setDetails(int tickNum, int num1, int num2, int num3, int num4, int num5, int num6)
        {
            this.ticketNum = tickNum;
            this.uniqueNum1 = num1;
            this.uniqueNum2 = num2;
            this.uniqueNum3 = num3;
            this.uniqueNum4 = num4;
            this.uniqueNum5 = num5;
            this.uniqueNum6 = num6;
        }

        public int GetTicketNum()
        {
            return this.ticketNum;
        }

        public int GetUniqueNum1()
        {
            return this.uniqueNum1;
        }

        public int GetUniqueNum2()
        {
            return this.uniqueNum2;
        }

        public int GetUniqueNum3()
        {
            return this.uniqueNum3;
        }

        public int GetUniqueNum4()
        {
            return this.uniqueNum4;
        }

        public int GetUniqueNum5()
        {
            return this.uniqueNum5;
        }

        public int GetUniqueNum6()
        {
            return this.uniqueNum6;
        }
    }
}
