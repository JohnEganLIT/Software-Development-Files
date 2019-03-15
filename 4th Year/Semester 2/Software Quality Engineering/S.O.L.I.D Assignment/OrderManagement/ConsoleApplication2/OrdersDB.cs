using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement
{
    class OrdersDB : IOrdersDB
    {
        ILogger logger;
      
        public OrdersDB(ILogger logger)
        {
            this.logger = logger;
        }

        public void Add(IOrder order)
        {
            try
            {
                // Will call a DAL API here later.
            }
            catch (Exception ex)
            {
                logger.WriteError(ex.ToString());
            }
        }
    }
}
