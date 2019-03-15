namespace OrderManagement
{
    interface IOrder
    {
        string OrderType { get; set; }

        bool ScheduleOrder(string status);
    }
}