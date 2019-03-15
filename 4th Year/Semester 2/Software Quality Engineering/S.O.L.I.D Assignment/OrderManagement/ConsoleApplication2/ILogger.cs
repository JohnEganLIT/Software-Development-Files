namespace OrderManagement
{
    interface ILogger
    {
        void Write(string file, string msg);
        void WriteError(string msg);
        void WriteOrder(string msg);
    }
}