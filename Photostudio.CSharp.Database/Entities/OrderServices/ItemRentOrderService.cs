namespace Photostudio.CSharp.Database.Entities.OrderServices;

public class ItemRentOrderService : TimedSimpleOrderService
{
    public RentedItem RentedItem { get; set; }
    public uint RentedItemId { get; internal set; }
    public uint Count { get; internal set; }

    internal ItemRentOrderService()
    {
        RentedItem = new RentedItem();
        RentedItemId = RentedItem.RentedItemId;
        Count = 0;
    }

    public ItemRentOrderService(Order order, Service service, DateTime startDateTime, uint duration, RentedItem rentedItem,
        uint count, Employee employee) : base(order, service, startDateTime, duration,employee)
    {
        RentedItem = rentedItem;
        Count = count;
    }
}