using Guilherme04.DAL;
using Guilherme04.Infrastructure;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace Guilherme04
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<IdentityDbContextApplication>(IdentityDbContextApplication.Create);
            app.CreatePerOwinContext<UsersManagements>(UsersManagements.Create);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
                {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,LoginPath = new PathString("/Security/Account/Login"),
            });
        }
    }
}