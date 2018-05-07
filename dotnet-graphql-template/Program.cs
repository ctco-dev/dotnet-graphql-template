using System.IO;
using Configuration;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

public static class Program
{
    public static void Main(string[] args)
    {
        IWebHost host = WebHost
            .CreateDefaultBuilder(args)
            .UseUrls("http://*:5000")
            .UseStartup<Startup>()
            .Build();

        host.Run();
    }
}