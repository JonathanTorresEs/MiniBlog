using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MiniBlog.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MiniBlog.DAL
{
    public class BlogContext : DbContext
    {

        public BlogContext() : base("BlogContext")
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Page> Pages { get; set; }

        public DbSet<PageCategory> PageCategories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}