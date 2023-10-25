using System.ComponentModel.DataAnnotations;

namespace Photostudio.CSharp.Database.Entities;

// TODO: Rename
public class RentedItem
{
    [Key] public uint RentedItemId { get; internal set; }
    [MinLength(2)] [MaxLength(50)]public string Title { get; internal set; }
    [MinLength(2)] [MaxLength(300)] public string Description { get; internal set; }
    internal RentedItem()
    {
        RentedItemId = 0;
        Title = string.Empty;
        Description = string.Empty;
    }

    public RentedItem(string title, string description) : this()
    {
        Title = title;
        Description = description;
    }
}