using System;
using System.Diagnostics;
using External.Library;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Injection;

namespace Konsol
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddExternalLibraryServices();
            services.AddSerilogServices();
            services.AddTransient<Runner>();

            var provider = services.BuildServiceProvider();

            var log = provider.GetService<ILogger>();
            log.Information("ILogger service reference obtained.");

            var runner = provider.GetService<Runner>();

            runner.DoAction("Hello there");
            var divider = provider.GetService<IDivideByZero>();
            divider.CrashThyself(999);


            log.Information("Ready to exit.");
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }

    }


}
