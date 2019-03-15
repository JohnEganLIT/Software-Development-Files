using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class OrdersDB
    {
        public void Add(IOrder order)
        {
            Logger logger = new Logger();

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
