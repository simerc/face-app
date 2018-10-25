using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace FaceImage.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseUrls("https://*:44325")
                .UseStartup<Startup>();
    }
}
