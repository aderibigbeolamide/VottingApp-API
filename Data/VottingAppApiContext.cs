using Microsoft.EntityFrameworkCore;
using VottingAPI.Model;

namespace VottingAPI.Data
{
    public class VottingAppApiContext : DbContext
    {
         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));
            optionsBuilder.UseMySql("server=localhost;user=root;database=VottingAppAPI;port=3306;password=html12345;", serverVersion);
        }

        public DbSet<ElectoralOfficer> ElectoralOfficers { get; set; }
        public DbSet<Student> Students {get; set;}
        public DbSet<Contestant> Contestants {get; set;}
        public DbSet<Voter> Voters {get; set;}
        public DbSet<Election> Elections {get; set;}
        public DbSet<Position> Positions {get; set;}
        public DbSet<Vote> Votes {get; set;}
    }
}