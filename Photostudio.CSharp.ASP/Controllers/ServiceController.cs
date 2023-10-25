using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Photostudio.CSharp.ASP.Repositories;
using Photostudio.CSharp.ASP.Repositories.Interfaces;

namespace Photostudio.CSharp.ASP.Controllers;

[ApiController]
[Route("api/services")]
public class ServiceController : ControllerBase
{
    private readonly IServicesRepository _servicesRepository;
    private readonly ILogger<ServiceController> _logger;

    public ServiceController(ILogger<ServiceController> logger,IServicesRepository servicesRepository)
    {
        _logger = logger;
        _servicesRepository = servicesRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] string? search)
    {
        _logger.LogTrace("Getting all Services witch search: {search}", search);
        var services = search switch
        {
            null => _servicesRepository.FindAll(),
            _ => _servicesRepository.FindByTitle(search)
        };
        return Ok(await services.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromQuery] uint id)
    {
        _logger.LogTrace("Getting Service with id: {search}", id);

        var service = await _servicesRepository.FindByIdAsync(id);
        return Ok(service);
    }
}