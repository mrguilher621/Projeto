using Guilherme04.Areas.Safety.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Guilherme04.DAL
{
    public class IdentityDbContextApplication : IdentityDbContext<Users>
    {
        public IdentityDbContextApplication() :base("IdentityDb")
        {
        }

        static IdentityDbContextApplication()
        {
            Database.SetInitializer<IdentityDbContextApplication>(new IdentityDbInit());
        }

        public static IdentityDbContextApplication Create()
        {
            return new IdentityDbContextApplication();
        }

        public System.Data.Entity.DbSet<Guilherme04.Areas.Safety.Models.UserViewModels> UserViewModels { get; set; }
    }

    public class IdentityDbInit : DropCreateDatabaseIfModelChanges<IdentityDbContextApplication>
    {

    }
}