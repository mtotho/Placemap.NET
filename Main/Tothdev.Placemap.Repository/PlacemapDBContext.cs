using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Tothdev.Placemap.Repository
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class PlacemapDBContext : DbContext
    {
        public DbSet<Entity.Place> Places { get; set; }
        public DbSet<Entity.PlacemapType> PlacemapTypes { get; set; }
        public DbSet<Entity.PlacemapSurvey> PlacemapSurvey { get; set; }
        public DbSet<Entity.SurveyItem> SurveyItem { get; set; }
        public DbSet<Entity.SurveyItemType> SurveyItemType { get; set; }
        public PlacemapDBContext()
      : base(nameOrConnectionString: "PLACEMAP")
        {
            this.Configuration.LazyLoadingEnabled = false;
            //   this.Configuration.ProxyCreationEnabled = false;
            ////Database.Connection.Open();

            var shouldRefreshDatabase = ConfigurationManager.AppSettings["RefreshDatabase"];
            if (shouldRefreshDatabase == "1")
            {
                Database.SetInitializer<PlacemapDBContext>(new DropCreateDatabaseAlways<PlacemapDBContext>());
            }
            else
            {
                Database.SetInitializer<PlacemapDBContext>(null);
            }


        }

        public PlacemapDBContext(DbConnection existingConnection, bool contextOwnsConnection)
      : base(existingConnection, contextOwnsConnection)
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            //     modelBuilder.Entity<Entity.ProjectUserGroup>().ToTable("ProjectUserGroup").HasKey(i => i.Id);
            modelBuilder.Configurations.Add(new Mapping.Place());
            modelBuilder.Configurations.Add(new Mapping.PlacemapType());
          
        }

        public void Commit()
        {
            SaveChanges();
        }
    }
}
