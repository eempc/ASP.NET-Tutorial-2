using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebApplication2.Models;

namespace WebApplication2 {
    public class Program {
        public static void Main(string[] args) {
            //CreateWebHostBuilder(args).Build().Run(); // remove the auto run and replace without the .run as a var
            var host = CreateWebHostBuilder(args).Build();

            // Seed data stuff, otherwise none of this is needed (migration?). Yeah apparently this is unnecessary in a real thing, it's just for test data
            using (var scope = host.Services.CreateScope()) {
                var services = scope.ServiceProvider; // I wonder what services it is grabbing

                try {
                    var context = services.GetRequiredService<WebApplication2Context>(); // I need WebApp2.Models, really?
                    context.Database.Migrate();
                    SeedData.Initialize(services);
                }
                catch (Exception ex) {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error in seeding the DB.");
                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
