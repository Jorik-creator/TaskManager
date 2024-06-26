using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;

[ApiController]
[Route("api/events")]
public class EventsController : ControllerBase
{
    private readonly CalendarDbContext _context;

    public EventsController(CalendarDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IEnumerable<Event> GetEvents() => _context.Events.ToList();

    [HttpPost]
    public IActionResult CreateEvent([FromBody] Event newEvent)
    {
        _context.Events.Add(newEvent);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetEvents), new { id = newEvent.Id }, newEvent);
    }
}