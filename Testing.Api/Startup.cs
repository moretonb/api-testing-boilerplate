using System.Diagnostics;
using JustEat.StatsD;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Testing.Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var statsDConfig = new StatsDConfiguration
            {
                Host = Configuration.GetValue<string>("StatsdHost")
            };
            var statsDPublisher = new StatsDPublisher(statsDConfig);

            app.Use(async (context, next) =>
            {
                var stopWatch = Stopwatch.StartNew();
                await next();
                stopWatch.Stop();

                if (context.Items["MetricName"] != null)
                {
                    var statName = $"boilerplate-api.{((string)context.Items["MetricName"]).ToLower()}.{context.Request.Method.ToLower()}.{context.Response.StatusCode}";
                    statsDPublisher.Timing(stopWatch.Elapsed, statName);
                }
            });

            app.UseMvc();
        }
    }
}
