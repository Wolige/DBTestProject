using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTestProject
{
    public class TestDbContext : DbContext
    {
        public DbSet<Song> Songs { get; set; }
        public DbSet<Group> Groups { get; set; }
        public TestDbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MusicDB;Trusted_Connection=True;");
        }
    }
}
