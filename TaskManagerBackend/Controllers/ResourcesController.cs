using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;

[ApiController]
[Route("api/resources")]
public class ResourcesController : ControllerBase
{
    private readonly CalendarDbContext _context;

    public ResourcesController(CalendarDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IEnumerable<Resource> GetResources() => _context.Resources.ToList();
}