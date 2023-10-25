using Microsoft.EntityFrameworkCore;
using Photostudio.CSharp.ASP.Repositories.Interfaces;
using Photostudio.CSharp.Database;
using Photostudio.CSharp.Database.Entities;

namespace Photostudio.CSharp.ASP.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly PhotostudioContext _context;

    public OrderRepository(PhotostudioContext context)
    {
        _context = context;
    }

    public IQueryable<Order> GetAllOrdersByClient(Client client)
    {
        var orders = _context.Orders.AsNoTracking().OrderByDescending(o => o.OrderDateTime)
            .Include(o => o.OrderServices).Where(o => o.ClientId == client.ClientId);
        return orders;
    }

    public Order GetOrderById(Guid orderId)
    {
        return _context.Orders.AsNoTracking().Include(o => o.OrderServices).Single(o => o.OrderId == orderId);
    }

    public Task<Order> GetOrderByIdAsync(Guid orderId)
    {
        return _context.Orders.AsNoTracking().Include(o => o.OrderServices).SingleAsync(o => o.OrderId == orderId);
    }

    public Order SaveOrder(Order order)
    {
        // if order_id != default - Update, else add
        var addedOrder = order.OrderId != Guid.Empty ? _context.Orders.Update(order) : _context.Orders.Add(order);
        _context.SaveChanges();
        return addedOrder.Entity;
    }

    public async Task<Order> SaveOrderAsync(Order order)
    {
        var addedOrder = order.OrderId != Guid.Empty ? _context.Orders.Update(order) : _context.Orders.Add(order);
        await _context.SaveChangesAsync();
        return addedOrder.Entity;
    }
}