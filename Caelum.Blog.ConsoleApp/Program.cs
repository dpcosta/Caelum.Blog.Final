using Microsoft.AspNetCore.Hosting;

namespace Caelum.Blog.ConsoleApp
{
    class Program
    {
        static void Main()
        {

            IWebHost host = new WebHostBuilder()
                .UseStartup<Startup>()
                .UseKestrel()
                .Build();

            host.Run();
            
        }
    }
}
