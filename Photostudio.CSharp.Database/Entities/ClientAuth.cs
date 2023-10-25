using System.ComponentModel.DataAnnotations;

namespace Photostudio.CSharp.Database.Entities;

public class ClientAuth
{
    [Key] public Client Client { get; internal set; }
    public Guid ClientId { get; internal set; }
    [MinLength(5)] [MaxLength(50)] public string Login { get; internal set; }
    [MinLength(64)] [MaxLength(64)] public string Password { get; internal set; }

    internal ClientAuth()
    {
        Client = new Client();
        ClientId = Client.ClientId;
        Login = string.Empty;
        Password = string.Empty;
    }

    public ClientAuth(Client client, string login, string password)
    {
        Client = client;
        ClientId = Client.ClientId;
        Login = login;
        Password = password;
    }
}