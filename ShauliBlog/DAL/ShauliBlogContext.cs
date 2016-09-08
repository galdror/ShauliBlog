using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using ShauliBlog.Models;

namespace ShauliBlog.DAL
{
    public class ShauliBlogContext : DbContext
    {
        public ShauliBlogContext()
            : base("ShauliBlogContext")
        {
        }

        static ShauliBlogContext()
        {
            Database.SetInitializer<ShauliBlogContext>(
            new DropCreateDatabaseAlways<ShauliBlogContext>());
        }
        public DbSet<Fan> Fans { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Manager> Managers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}