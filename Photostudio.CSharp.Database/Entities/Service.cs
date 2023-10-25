using System.ComponentModel.DataAnnotations;

namespace Photostudio.CSharp.Database.Entities;

public class Service
{
    [Key] public uint ServiceId { get; internal set; }
    [MinLength(2)] [MaxLength(50)] public string Title { get; internal set; }
    [MinLength(2)] [MaxLength(300)] public string Description { get; internal set; }
    public decimal BasePrice { get; internal set; }
    public ServiceType Type { get; internal set; }

    internal Service()
    {
        ServiceId = 0;
        Title = string.Empty;
        Description = string.Empty;
        BasePrice = 0;
        Type = ServiceType.Simple;
    }

    public Service(string title, string description, decimal basePrice, ServiceType type)
    {
        Title = title;
        Description = description;
        BasePrice = basePrice;
        Type = type;
    }
    public enum ServiceType : byte
    {
        Simple,
        HallRent,
        ItemRent
    }
}