Contributor: Jisoo Yoon

using Microsoft.EntityFrameworkCore;
using FitnessAndCalorieTracker.Models;

namespace FitnessAndCalorieTracker.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<CalorieEntry> CalorieEntries { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Reminder> Reminders { get; set; }
    }
}
