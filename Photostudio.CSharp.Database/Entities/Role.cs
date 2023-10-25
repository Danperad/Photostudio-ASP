using System.ComponentModel.DataAnnotations;

namespace Photostudio.CSharp.Database.Entities;

public sealed class Role
{
    [Key] public uint RoleId { get; internal set; }
    [MinLength(2)] [MaxLength(50)]public string Title { get; internal set; }
    [MinLength(2)] [MaxLength(300)]public string Description { get; internal set; }

    public Role()
    {
        RoleId = 0;
        Title = "";
        Description = "";
    }
    
    public Role(string title, string description)
    {
        Title = title;
        Description = description;
    }
}