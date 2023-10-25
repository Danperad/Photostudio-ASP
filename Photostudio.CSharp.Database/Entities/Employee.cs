using System.ComponentModel.DataAnnotations;

namespace Photostudio.CSharp.Database.Entities;

public class Employee
{
    [Key] public Guid EmployeeId { get; internal set; }
    [MinLength(2)] [MaxLength(50)] public string LastName { get; set; }
    [MinLength(2)] [MaxLength(50)] public string FirstName { get; set; }
    [MinLength(2)] [MaxLength(50)] public string? MiddleName { get; set; }

    [RegularExpression(@"^\+?[(]?[0-9]{3}[)]?[-\s]?[0-9]{3}[-\s]?[0-9]{4,6}$",
        ErrorMessage = "Not phone number format")]
    public string PhoneNumber { get; set; }

    [RegularExpression(@"^([\w\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Not EMail format")]
    public string EMail { get; set; }

    public Role Role { get; set; }
    public uint RoleId { get; internal set; }

    public bool IsEnabled { get; internal set; }


    internal Employee()
    {
        EmployeeId = Guid.Empty;
        LastName = "";
        FirstName = "";
        MiddleName = null;
        PhoneNumber = "+79999999999";
        EMail = "a@a.aa";
        Role = new Role();
        RoleId = Role.RoleId;
        IsEnabled = false;
    }

    public Employee(string lastName, string firstName, string phoneNumber, string eMail, Role role) : this()
    {
        EmployeeId = Guid.NewGuid();
        LastName = lastName;
        FirstName = firstName;
        PhoneNumber = phoneNumber;
        EMail = eMail;
        Role = role;
        RoleId = Role.RoleId;
        IsEnabled = true;
    }

    public Employee(string lastName, string firstName, string? middleName, string phoneNumber, string eMail,
        Role role) : this(
        lastName, firstName, phoneNumber, eMail, role)
    {
        MiddleName = middleName;
    }
}