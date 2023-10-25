using Photostudio.CSharp.Database.Entities;

namespace Photostudio.CSharp.ASP.Repositories.Interfaces;

public interface IServicesRepository
{
    Service FindById(uint id);
    Task<Service> FindByIdAsync(uint id);
    IQueryable<Service> FindAll();
    IQueryable<Service> FindByTitle(string title);
}