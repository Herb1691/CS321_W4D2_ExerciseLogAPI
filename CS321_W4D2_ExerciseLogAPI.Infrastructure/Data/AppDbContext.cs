using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using CS321_W4D2_ExerciseLogAPI.Core.Models;

namespace CS321_W4D2_ExerciseLogAPI.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        //public DbSet<Book> Books { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<ActivityType> ActivityTypes { get; set; }
        public DbSet<User> Users { get; set; }

        // This method runs once when the DbContext is first used.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // TODO: use optionsBuilder to configure a Sqlite db
            optionsBuilder.UseSqlite("Data Source=ExerciseLog.db");
        }

        // This method runs once when the DbContext is first used.
        // It's a place where we can customize how EF Core maps our
        // model to the database. 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // TODO: configure some seed data in the authors table
            modelBuilder.Entity<ActivityType>().HasData(
                new ActivityType { Id = 1, Name = "Running", RecordType = RecordType.DurationAndDistance },
                new ActivityType { Id = 2, Name = "Weights", RecordType = RecordType.DurationOnly },
                new ActivityType { Id = 3, Name = "Walking", RecordType = RecordType.DurationAndDistance }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Test User" }
            );

            // TODO: configure some seed data in the books table
            modelBuilder.Entity<Activity>()
                //.ToTable("Activities")
                .HasData(
                new Activity { Id = 1, UserId = 1, ActivityTypeId = 1, Date = new DateTime(2019, 6, 19), Distance = 3, Duration = 30, Notes = "Hot!!!!" }
            );

        }
    }
}
