using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Photostudio.CSharp.Database.Entities.OrderServices;

namespace Photostudio.CSharp.Database.Entities;

public sealed class Order
{
    [Key] public Guid OrderId { get; internal set; }
    public Client Client { get; internal set; }
    public Guid ClientId { get; internal set; }
    public DateTime OrderDateTime { get; internal set; }
    public decimal? Discount { get; internal set; }
    public List<SimpleOrderService> OrderServices { get; internal set; }

    internal Order()
    {
        OrderId = Guid.Empty;
        Client = new Client();
        ClientId = Client.ClientId;
        OrderDateTime = DateTime.MinValue;
        Discount = null;
        OrderServices = new List<SimpleOrderService>();
    }

    public Order(Client client, DateTime orderDateTime) : this()
    {
        OrderId = Guid.NewGuid();
        Client = client;
        ClientId = client.ClientId;
        OrderDateTime = orderDateTime;
    }

    public Order(Client client, DateTime orderDateTime, decimal? discount) : this(client, orderDateTime)
    {
        Discount = discount;
    }
}