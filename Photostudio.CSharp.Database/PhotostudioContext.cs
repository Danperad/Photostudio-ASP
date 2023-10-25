using Microsoft.EntityFrameworkCore;
using Photostudio.CSharp.Database.Entities;
using Photostudio.CSharp.Database.Entities.OrderServices;

namespace Photostudio.CSharp.Database;

public class PhotostudioContext : DbContext
{
    public PhotostudioContext(DbContextOptions<PhotostudioContext> contextOptions) : base(contextOptions)
    {
    }

    public DbSet<Client> Clients { get; internal set; } = null!;
    public DbSet<ClientAuth> ClientAuths { get; internal set; } = null!;
    public DbSet<Employee> Employees { get; internal set; } = null!;
    public DbSet<Hall> Halls { get; internal set; } = null!;
    public DbSet<HallRentOrderService> HallRentOrderServices { get; internal set; } = null!;
    public DbSet<ItemRentOrderService> ItemRentOrderServices { get; internal set; } = null!;
    public DbSet<Order> Orders { get; internal set; } = null!;
    public DbSet<RentedItem> RentedItems { get; internal set; } = null!;
    public DbSet<Role> Roles { get; internal set; } = null!;
    public DbSet<Service> Services { get; internal set; } = null!;
    public DbSet<SimpleOrderService> SimpleOrderServices { get; internal set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SimpleOrderService>().UseTphMappingStrategy();
        base.OnModelCreating(modelBuilder);
    }
}