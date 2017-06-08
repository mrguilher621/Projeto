using Guilherme04.Areas.Safety.Models;
using Guilherme04.DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace Guilherme04.Infrastructure
{
    public class UsersManagements : UserManager<Users>
    {
        public UsersManagements(IUserStore<Users> store): base(store){
    }
        public static UsersManagements Create(IdentityFactoryOptions<UsersManagements> options,IOwinContext context)
        {
            IdentityDbContextApplication db = context.Get<IdentityDbContextApplication>();
            UsersManagements manager = new UsersManagements(new UserStore<Users>(db));
            return manager;
        }
    }
}