using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectBC.Domain;
using ProjectBC.Domain.Entities;
using Task = ProjectBC.Domain.Entities.Task;

namespace ProjectBC.Infrastructure
{
    public class ProjectsDbContext : DbContext, IUnitOfWork
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Pbi> Pbis { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Sprint> Sprints { get; set; }

        public ProjectsDbContext(DbContextOptions<ProjectsDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sprint>()
                .OwnsOne<DateRange>(s => s.DateRange);
        }

        public async System.Threading.Tasks.Task CommitAsync()
        {
            await SaveChangesAsync();
        }
    }
}