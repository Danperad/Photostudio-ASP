using Photostudio.CSharp.Database.Entities;

namespace Photostudio.CSharp.ASP.Repositories.Interfaces;

public interface IOrderRepository
{
    IQueryable<Order> GetAllOrdersByClient(Client client);
    Order GetOrderById(Guid orderId);
    Task<Order> GetOrderByIdAsync(Guid orderId);
    Order SaveOrder(Order order);
    Task<Order> SaveOrderAsync(Order order);
}