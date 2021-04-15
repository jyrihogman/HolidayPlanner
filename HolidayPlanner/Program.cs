using HolidayPlanner.DateLogic;
using HolidayPlanner.HolidayLogic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace HolidayPlanner
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();
            var appService = host.Services.GetService<IApp>();
            Console.WriteLine("Hello World!");
            Console.WriteLine("Input start date: ");
            var start = Console.ReadLine();

            Console.WriteLine("Input end date: ");
            var end = Console.ReadLine();

            appService.Run(start, end);

        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    services.AddSingleton<IApp, App>()
                            .AddSingleton<IDateWrapper, DateWrapper>()
                            .AddSingleton<IHolidayPlanner, HolidayPlanner>()
                            .AddSingleton<IHolidayService, HolidayService>()
                );
    }
}
