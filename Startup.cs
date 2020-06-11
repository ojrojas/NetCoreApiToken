using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using RappiApi.Data;
using RappiApi.Models;
using RappiApi.Repository;
using RappiApi.Repository.Interfaces;
using RappiApi.Services;
using RappiApi.Services.Interfaces;
using RappiApi.Services.Tokens;

namespace RappiApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.ValidacionJwtServicesExtensions(Configuration);
            services.AddControllers();
            services.AddDbContext<RappiApiDbContext>(options =>
            {
                options.UseSqlite(Configuration["SqliteConnections"]);
            });

            services.AddIdentity<UsuarioAplicacion, IdentityRole>()
            .AddEntityFrameworkStores<RappiApiDbContext>()
            .AddDefaultTokenProviders();


            services.AddScoped<IGeneradorToken, GeneradorToken>();
            services.AddScoped<IEmpleadoService, EmpleadoService>();
            services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();
            services.AddScoped<IAreaService, AreaServices>();
            services.AddScoped<IAreaRepository, AreaRepository>();
            services.AddScoped<ISubAreaService, SubAreaService>();
            services.AddScoped<ISubAreaRepository, SubAreaRepository>();


            services.AddCors(options =>
          {
              options.AddPolicy("CorsPolicy",
                  builder => builder
                  .SetIsOriginAllowed((host) => true)
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .AllowCredentials());
          });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RappiApiInfo", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "RappiApiInfo v1");
                c.RoutePrefix = string.Empty;
            });



            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
