namespace Photostudio.CSharp.Database.Entities.OrderServices;

public class SimpleOrderService
{
    public uint OrderServiceId { get; internal set; }
    public Order Order { get; internal set; }
    public Guid OrderId { get; internal set; }
    public Service Service { get; set; }
    public uint ServiceId { get; internal set; }
    public Employee Employee { get; set; }
    public Guid EmployeeId { get; internal set; }

    internal SimpleOrderService()
    {
        OrderServiceId = 0;
        Order = new Order();
        OrderId = Guid.Empty;
        Service = new Service();
        ServiceId = Service.ServiceId;
        Employee = new Employee();
        EmployeeId = Employee.EmployeeId;
    }

    protected SimpleOrderService(Order order, Service service, Employee employee) : this()
    {
        Order = order;
        OrderId = Order.OrderId;
        Service = service;
        ServiceId = service.ServiceId;
        Employee = employee;
        EmployeeId = employee.EmployeeId;
    }
}