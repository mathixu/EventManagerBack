using EventManager.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManager.DAL;

public class EventManagerDbContext : DbContext
{
    public EventManagerDbContext(DbContextOptions<EventManagerDbContext> options) : base(options)
    {
    }

    public DbSet<Event> Events { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>().Property(e => e.Id).ValueGeneratedOnAdd();
    }
}
