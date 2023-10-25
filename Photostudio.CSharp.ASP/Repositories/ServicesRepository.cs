using Microsoft.EntityFrameworkCore;
using Photostudio.CSharp.ASP.Repositories.Interfaces;
using Photostudio.CSharp.Database;
using Photostudio.CSharp.Database.Entities;

namespace Photostudio.CSharp.ASP.Repositories;

public class ServicesRepository : IServicesRepository
{
    private readonly PhotostudioContext _context;

    public ServicesRepository(PhotostudioContext context)
    {
        _context = context;
    }

    public Service FindById(uint id)
    {
        return _context.Services.AsNoTracking().Single(s => s.ServiceId == id);
    }

    public async Task<Service> FindByIdAsync(uint id)
    {
        return await _context.Services.AsNoTracking().SingleAsync(s => s.ServiceId == id);
    }

    public IQueryable<Service> FindAll()
    {
        return _context.Services.AsNoTracking();
    }

    public IQueryable<Service> FindByTitle(string title)
    {
        return _context.Services.AsNoTracking().Where(s => s.Title.ToLower().Contains(title.ToLower()));
    }
}