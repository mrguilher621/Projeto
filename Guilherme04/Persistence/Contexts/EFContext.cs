
using Model.Register;
using Model.Tables;
using Persistence.Migrations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Persistence.Contexts
{
    public class EFContext : DbContext
    {
        #region [ DbSet Properties ]

        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }


        #endregion [ DbSet Properties ]


        #region [ Constructor ]

        public EFContext() :base("Asp_Net_MCV_CS")
        {
            Database.SetInitializer<EFContext>(new MigrateDatabaseToLatestVersion<EFContext,Configuration>());

        }

        #endregion [ Constructor ]

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}