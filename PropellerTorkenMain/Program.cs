using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using PropellerTorkenMain.Models.Database;
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
            CreateDb();
            CreateHostBuilder(args).Build().Run();
        }

        private static void CreateDb()
        {
            using (var context = new PropellerDataContext())

            {
                context.Database.EnsureCreated();
                context.SaveChanges();
            }
        }
    }
}