using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProjectBC.Domain.Entities;
using ProjectBC.Infrastructure;

namespace ProjectsBC.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetService<ProjectsDbContext>();
                db.Database.Migrate();

                Seed(db);
            }

            
            host.Run();
        }

        private static void Seed(ProjectsDbContext db)
        {
            if (db.Users.Any())
            {
                return;
            }
            
            var user = new User()
            {
                Email = "oscar.jara@infojobs.com.br",
                Name = "Oscar"
            };
            db.Users.Add(user);

            var team = new Team()
            {
                Name = "Mega team",
                Members = new[] {user}
            };
            db.Teams.Add(team);

            var project = new Project()
            {
                Description = "test project",
                Team = team
            };
            db.Projects.Add(project);
            
            db.SaveChanges();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}