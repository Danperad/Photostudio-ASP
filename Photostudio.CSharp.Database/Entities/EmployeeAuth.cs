using System.ComponentModel.DataAnnotations;

namespace Photostudio.CSharp.Database.Entities;

public class EmployeeAuth
{
    [Key] public Employee Employee { get; internal set; }
    public Guid EmployeeId { get; internal set; }
    [MinLength(5)] [MaxLength(50)] public string Login { get; internal set; }
    [MinLength(64)] [MaxLength(64)] public string Password { get; internal set; }

    internal EmployeeAuth()
    {
        Employee = new Employee();
        EmployeeId = Employee.EmployeeId;
        Login = string.Empty;
        Password = string.Empty;
    }

    public EmployeeAuth(Employee employee, string login, string password)
    {
        Employee = employee;
        EmployeeId = Employee.EmployeeId;
        Login = login;
        Password = password;
    }
}