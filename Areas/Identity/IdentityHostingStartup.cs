using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserAuthorityProject.Areas.Identity.Data;
using UserAuthorityProject.Data;

[assembly: HostingStartup(typeof(UserAuthorityProject.Areas.Identity.IdentityHostingStartup))]
namespace UserAuthorityProject.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<UserAuthDBContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("UserAuthDBContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<UserAuthDBContext>();
            });
        }
    }
}