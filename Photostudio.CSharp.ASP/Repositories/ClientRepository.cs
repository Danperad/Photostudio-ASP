using Microsoft.EntityFrameworkCore;
using Photostudio.CSharp.ASP.Repositories.Interfaces;
using Photostudio.CSharp.Database;
using Photostudio.CSharp.Database.Entities;

namespace Photostudio.CSharp.ASP.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly PhotostudioContext _context;

    public ClientRepository(PhotostudioContext context)
    {
        _context = context;
    }

    private IQueryable<Client> FindAllActive()
    {
        return _context.Clients.Where(c => c.IsEnabled);
    }
    
    public Client FindByPhone(string phone)
    {
        return FindAllActive().Single(c => c.PhoneNumber == phone);
    }

    public async Task<Client> FindByPhoneAsync(string phone)
    {
        return await FindAllActive().SingleAsync(c => c.PhoneNumber == phone);
    }

    public Client FindById(Guid id)
    {
        return FindAllActive().Single(c => c.ClientId == id);
    }

    public async Task<Client> FindByIdAsync(Guid id)
    {
        return await FindAllActive().SingleAsync(c => c.ClientId == id);
    }

    public Client Delete(Client client)
    {
        FindAllActive().Where(c => c.ClientId == client.ClientId)
            .ExecuteUpdate(c => c.SetProperty(cc => cc.IsEnabled, false));
        return _context.Clients.AsNoTracking().Single(c => c.ClientId == client.ClientId);
    }

    public async Task<Client> DeleteAsync(Client client)
    {
        await FindAllActive().Where(c => c.ClientId == client.ClientId)
            .ExecuteUpdateAsync(c => c.SetProperty(cc => cc.IsEnabled, false));
        return await _context.Clients.AsNoTracking().SingleAsync(c => c.ClientId == client.ClientId);
    }
}