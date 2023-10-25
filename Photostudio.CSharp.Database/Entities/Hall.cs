using System.ComponentModel.DataAnnotations;

namespace Photostudio.CSharp.Database.Entities;

public class Hall
{
    [Key] public uint HallId { get; internal set; }
    [MinLength(2)] [MaxLength(50)]public string Title { get; internal set; }
    [MinLength(2)] [MaxLength(300)]public string Description { get; internal set; }

    internal Hall()
    {
        HallId = 0;
        Title = "";
        Description = "";
    }

    public Hall(string title, string description)
    {
        Title = title;
        Description = description;
    }
}