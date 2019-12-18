using Microsoft.EntityFrameworkCore;
using ProjectBC.Domain.Entities;

namespace ProjectBC.Infrastructure
{
    public class ProjectsDbContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Pbi> Pbis { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Sprint> Sprints { get; set; }
    }
}