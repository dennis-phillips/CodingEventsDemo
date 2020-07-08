using System;
using CodingEventsDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace CodingEventsDemo.Data
{
    public class EventDbContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<EventCategory> Categories { get; set; }

        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options)
        {
        }

        public EventDbContext(DbSet<Event> events, DbSet<EventCategory> categories)
        {
            Events = events;
            Categories = categories;
        }
    }
}
