using Day4InClass.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day4InClass.Data
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options) { }
        public DbSet<Project> Projects { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().HasData(
                new { Id = 1, Description = "Project 1", IsComplete = false, Priority = 1, CreatedOn = DateTime.Now },
                new { Id = 2, Description = "Project 2", IsComplete = false, Priority = 1, CreatedOn = DateTime.Now },
                new { Id = 3, Description = "Project 3", IsComplete = false, Priority = 1, CreatedOn = DateTime.Now });
        }
    }
}
