using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement
{
    class Factory
    {
        public static ILogger CreateLogger()
        {
            return new Logger();
        }

        public static IOrder CreateOrder()
        {
            return new Order();
        }

        public static IOrdersDB CreateOrdersDB()
        {
            return new OrdersDB(Factory.CreateLogger());
        }
    }
}
