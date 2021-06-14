using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;

namespace CG.Sms.Twilio.QuickStart
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>(); // < -- call our startup class ...
                })
                .Build();

            host.Start();

            try
            {
                Console.WriteLine($"fetching sms service ...");
                var sms = host.Services.GetRequiredService<ISmsService>();

                Console.WriteLine($"sending sms ...");
                var results = sms.SendAsync(
                    new[] { "phone number here ..." },
                    "this is a test sms message"
                    ).Result;
                Console.WriteLine($"sms id: {results.First().SmsId}");
            }
            catch (Exception ex)
            {
                Exception result = ex;
                while (result.InnerException != null)
                    result = result.InnerException;
                Console.WriteLine($"ERROR: {ex.Message}: {result.GetBaseException().Message}");
            }
            finally
            {
                Console.WriteLine("Press any key to exit ...");
                Console.ReadKey();
            }
        }
    }
}
