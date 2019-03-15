namespace ConsoleApplication2
{
    interface IOrder
    {
        string OrderType { get; set; }

        bool ScheduleOrder(string status);
    }
}