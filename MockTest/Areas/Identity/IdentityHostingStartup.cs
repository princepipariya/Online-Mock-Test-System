using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MockTest.Areas.Identity.Data;
using MockTest.Data;

[assembly: HostingStartup(typeof(MockTest.Areas.Identity.IdentityHostingStartup))]
namespace MockTest.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<MockTestContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("MockTestContextConnection")));

                services.AddDefaultIdentity<MockTestUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<MockTestContext>();
            });
        }
    }
}