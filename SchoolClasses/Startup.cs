using System;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SchoolClasses.Repositories;
using SchoolClasses.Services;

namespace SchoolClasses
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "SchoolClasses", Version = "v1"
                });
            });
            
            InitDependencyInjection(services);
        }
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SchoolClasses v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseCors(builder => builder
                                   .AllowAnyOrigin()
                                   .AllowAnyMethod()
                                   .AllowAnyHeader());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        
        private void InitDependencyInjection(IServiceCollection services)
        {
            services.AddDbContext<SchoolClassesContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionString"],
                 sqlServerOptionsAction: sqlOptions =>
                 {
                     sqlOptions.MigrationsAssembly(
                         typeof(Startup).GetTypeInfo().Assembly.GetName().Name);

                     //Configuring Connection Resiliency:
                     sqlOptions.
                         EnableRetryOnFailure(maxRetryCount: 5,
                                              maxRetryDelay: TimeSpan.FromSeconds(30),
                                              errorNumbersToAdd: null);

                 });
                
                // Changing default behavior when client evaluation occurs to throw.
                // Default in EFCore would be to log warning when client evaluation is done.
                //options.ConfigureWarnings(warnings => warnings.Throw(
                //                              RelationalEventId.QueryClientEvaluationWarning));
            });
            
            
            services.AddScoped<ISchoolClassService, SchoolClassService>();
            services.AddScoped<ISchoolClassRepository, SchoolClassRepository>();
        }
    }
}