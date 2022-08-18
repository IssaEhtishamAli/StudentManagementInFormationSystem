using DataAcessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_management.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<student> Student { get; set; }
        public DbSet<Teacher> teacher { get; set; }
        public DbSet<subjects> subjects { get; set; }
        public DbSet<courses> courses { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Usertype> user_type { get; set; }
        public DbSet<degree> degree { get; set; }
        public DbSet<cities> cities { get; set; }
        public DbSet<sections> section { get; set; }
        public DbSet<titles> title { get; set; }
        public DbSet<genders> gender { get; set; }
        public DbSet<countryies> country { get; set; }
        public DbSet<districts> district { get; set; }
        public DbSet<userprofile> user_profile { get; set; }
        public DbSet<languages> language { get; set; }
        public DbSet<qualification> qualifications { get; set; }
        public DbSet<guardian> guardians { get; set; }
        public DbSet<file> files { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}