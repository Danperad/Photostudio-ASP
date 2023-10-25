using System.ComponentModel.DataAnnotations;

namespace Photostudio.CSharp.Database.Entities;

public class Client
{
    public Guid ClientId { get; internal set; }
    [MinLength(2)] [MaxLength(50)] public string LastName { get; set; }
    [MinLength(2)] [MaxLength(50)] public string FirstName { get; set; }
    [MinLength(2)] [MaxLength(50)] public string? MiddleName { get; set; }

    [RegularExpression(@"^\+?[(]?[0-9]{3}[)]?[-\s]?[0-9]{3}[-\s]?[0-9]{4,6}$",
        ErrorMessage = "Not phone number format")]
    public string PhoneNumber { get; set; }

    [RegularExpression(@"^([\w\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Not EMail format")]
    public string EMail { get; set; }
    public bool IsEnabled { get; internal set; }

    internal Client()
    {
        ClientId = Guid.Empty;
        LastName = "";
        FirstName = "";
        MiddleName = null;
        PhoneNumber = "+79999999999";
        EMail = "a@a.aa";
        IsEnabled = false;
    }

    public Client(string lastName, string firstName, string phoneNumber, string eMail) : this()
    {
        ClientId = Guid.NewGuid();
        LastName = lastName;
        FirstName = firstName;
        PhoneNumber = phoneNumber;
        EMail = eMail;
        IsEnabled = true;
    }

    public Client(string lastName, string firstName, string? middleName, string phoneNumber, string eMail) : this(
        lastName, firstName, phoneNumber, eMail)
    {
        MiddleName = middleName;
    }
}