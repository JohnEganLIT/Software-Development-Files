namespace OrderManagement
{
    class Logger : ILogger
    {
        public void WriteOrder(string msg)
        {
            Write(@"c:\OrderAdministratorLog.txt", "");
        }

        public void WriteError(string msg)
        {
            Write(@"c:\Error.txt", "");
        }

        public void Write(string file, string msg)
        {
            System.IO.File.AppendAllText(@file, msg);
        }
    }
}
