using System.IO;
using Configuration;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;

public static class Program
{
    public static void Main(string[] args)
    {
        IWebHost host = WebHost
            .CreateDefaultBuilder(args)
            .UseUrls("http://*:" + Environment.GetEnvironmentVariable("PORT"))
            .UseStartup<Startup>()
            .Build();

        host.Run();
    }
}
