using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using CabBook.Data.Configuration;
using CabBook.Model;
using CabBook.Model.Models;
using CabBook.Model.Models.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabBook.Data
{
    public class DatabaseEnities : IdentityDbContext<AppUser>//: DbContext
    {
        public DatabaseEnities()
            : base("StoreEntities")
        {
            Database.SetInitializer<DatabaseEnities>(null);// Remove default initializer
            Database.SetInitializer<DatabaseEnities>(new CreateDatabaseIfNotExists<DatabaseEnities>());
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = true;
        }

        public static DatabaseEnities Create()
        {
            return new DatabaseEnities();
        }

        //Identity and Authorization
        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<UserClaim> UserClaims { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Demo> demo { get; set; }
        //Driver
        public DbSet<RideInformation> RideInformation { get; set; }
        public DbSet<CarDetails> CarDetails { get; set; }
        public DbSet<RideDetails> RideDetails { get; set; }
        // ... your custom DbSets

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            
            modelBuilder.Configurations.Add(new DemoConiguration());
            //modelBuilder.Configurations.Add(new CategoryConfiguration());

            // Configure Asp Net Identity Tables
            
        }
    }

    
}
