using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CG.Sms.Twilio.QuickStart
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSms(
                Configuration.GetSection("Sms"),
                ServiceLifetime.Transient
                );

            services.AddStrategies(
                Configuration.GetSection("Sms"),
                ServiceLifetime.Transient
                );
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSms(
                env,
                Configuration.GetSection("Sms")
                );

            app.UseStrategies(
                env,
                Configuration.GetSection("Sms")
                );
        }
    }
}
