using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        { 
            OrdersDB db = new OrdersDB();
            Logger logger = new Logger();

            List<IOrder> OrderList = new List<IOrder>();

            // Generate Orders.
            for (int i = 0; i <= 3; i++)
            {
                OrderList.Add(new Order()); // Create orders.             
            }

            // Schedule the orders and add to DB where appropriate.
            if (OrderList[0].ScheduleOrder("Low"))
                db.Add(OrderList[0]);

            else
                logger.WriteOrder("");

            if (OrderList[1].ScheduleOrder("Standard"))
                db.Add(OrderList[1]);

            else
                logger.WriteOrder("");

            if (OrderList[2].ScheduleOrder("Rush"))
                db.Add(OrderList[2]);

            else
                logger.WriteOrder("");

            if (OrderList[3].ScheduleOrder("None"))
                db.Add(OrderList[3]);

            else
                logger.WriteOrder("");
        }
    }
}
