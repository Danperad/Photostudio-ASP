using Photostudio.CSharp.Database.Entities;

namespace Photostudio.CSharp.ASP.Repositories.Interfaces;

public interface IClientRepository
{
    Client FindByPhone(string phone);
    Task<Client> FindByPhoneAsync(string phone);
    Client FindById(Guid id);
    Task<Client> FindByIdAsync(Guid id);
    Client Delete(Client client);
    Task<Client> DeleteAsync(Client client);
}