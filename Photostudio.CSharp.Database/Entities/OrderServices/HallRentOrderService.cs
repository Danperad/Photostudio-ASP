namespace Photostudio.CSharp.Database.Entities.OrderServices;

public class HallRentOrderService : TimedSimpleOrderService
{
    public Hall Hall { get; set; }
    public uint HallId { get; internal set; }

    internal HallRentOrderService()
    {
        Hall = new Hall();
        HallId = Hall.HallId;
    }

    public HallRentOrderService(Order order, Service service, DateTime startDateTime, uint duration, Hall hall,
        uint hallId, Employee employee) : base(order, service, startDateTime, duration, employee)
    {
        Hall = hall;
        HallId = hallId;
    }
}