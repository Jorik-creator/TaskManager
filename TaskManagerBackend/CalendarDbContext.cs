using Microsoft.EntityFrameworkCore;
using TaskManager.Models;

public class CalendarDbContext : DbContext
{
    public DbSet<Event> Events { get; set; }
    public DbSet<Resource> Resources { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=calendar.db");
    }
}
