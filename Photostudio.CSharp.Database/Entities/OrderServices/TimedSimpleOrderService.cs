namespace Photostudio.CSharp.Database.Entities.OrderServices;

public abstract class TimedSimpleOrderService : SimpleOrderService
{
    public DateTime StartDateTime { get; internal set; }
    public uint Duration { get; internal set; }

    internal TimedSimpleOrderService()
    {
        StartDateTime = DateTime.MinValue;
        Duration = 0;
    }

    protected TimedSimpleOrderService(Order order, Service service, DateTime startDateTime, uint duration, Employee employee) : base(order, service, employee)
    {
        StartDateTime = startDateTime;
        Duration = duration;
    }
}