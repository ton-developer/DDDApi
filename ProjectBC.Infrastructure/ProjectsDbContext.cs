using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectBC.Domain;
using ProjectBC.Domain.Entities;
using Task = ProjectBC.Domain.Entities.Task;

namespace ProjectBC.Infrastructure
{
    public class ProjectsDbContext : DbContext, IUnitOfWork
    {
        private readonly IPublisher _publisher;
        public DbSet<Project> Projects { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Pbi> Pbis { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Sprint> Sprints { get; set; }

        public ProjectsDbContext(DbContextOptions<ProjectsDbContext> options, IPublisher publisher) : base(options)
        {
            _publisher = publisher;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sprint>()
                .OwnsOne<DateRange>(s => s.DateRange);
        }

        public async System.Threading.Tasks.Task CommitAsync()
        {
            await base.SaveChangesAsync();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var entries = ChangeTracker.Entries<BaseEntity>().Where(x => x.State != EntityState.Unchanged);
            foreach (var entry in entries)
            {
                var events = entry.Entity.Events.ToList();
                entry.Entity.ClearEvents();
                // Publish the entities.
            }
            
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}