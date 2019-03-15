using System;

namespace ConsoleApplication2
{
    class Order : IOrder
    {
        public string OrderType { get; set; }

        private DateTime orderDate;
        private DateTime scheduledShipDate;
        private enum Priority { Rush, Standard, Low, None };       
        
        public Order()
        {
            orderDate = DateTime.Now;
        }
 
        public bool ScheduleOrder(string status)
        {
            int leadtime=30;
            for (Priority orderPriority = Priority.Rush; orderPriority <= Priority.None; orderPriority++)
            {
                if (status == orderPriority.ToString())
                {
                    if (orderPriority == Priority.Rush)
                        leadtime = 7;

                    else if (orderPriority == Priority.Standard)
                        leadtime = 14;

                    else if (orderPriority == Priority.Low)
                        leadtime = 30;

                    else if (orderPriority == Priority.None)
                    {
                        OrderType = orderPriority.ToString();
                        return false; // Business rule not allowed schedule an order with no priority
                    }
                    OrderType = orderPriority.ToString();
                    scheduledShipDate = DateTime.Now.AddDays(leadtime);
                }
            } 
            return true;
        }
    }
}
