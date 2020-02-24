using LWarp.Server.Contracts;
using LWarp.Server.Data.Configs;
using LWarp.Server.Data.Contexts;
using LWarp.Server.Data.Repositories;
using LWarp.Server.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LWarp.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGrpc();
            services.AddOptions();

            services.Configure<MongoConfig>(c => this.Configuration.GetSection("MongoDB").Bind(c));

            services.AddSingleton<ILinksContext, LinksContext>();
            services.AddScoped<ILinksRepository, LinksRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<LinkService>();
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Only grpc calls.");
                });
            });
        }
    }
}