using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PropellerTorkenMain.Services;

namespace PropellerTorkenMain
{
    public class Program
    {
        public OrderService orderService = new OrderService();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            CreateDbIfNotThere();
        }

        private static void CreateDbIfNotThere()
        {
            using (var context = new Models.Database.PropellerDataContext())
            {
                context.Database.EnsureCreated();
                context.SaveChanges();
            }
        }
    }
}