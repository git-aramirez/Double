using Double.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Double.Domain
{
    public class DoubleDbContext : DbContext
    {
        public DoubleDbContext(DbContextOptions<DoubleDbContext> options) : base(options)
        {

        }

        public DbSet<Person> People { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person>().ToTable("People");
            modelBuilder.Entity<User>().ToTable("User");
        }
    }
}
