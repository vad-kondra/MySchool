using System;
using System.Reflection;
using AutoMapper;
using BusinessLogicLayer.GradeService;
using BusinessLogicLayer.StudentService;
using BusinessLogicLayer.SubjectService;
using BusinessLogicLayer.TeacherService;
using DataAccessLayer;
using DataAccessLayer.Repositories.GradeRepository;
using DataAccessLayer.Repositories.StudentRepository;
using DataAccessLayer.Repositories.SubjectRepository;
using DataAccessLayer.Repositories.TeacherRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Server
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
            services.AddRazorPages();
            services.AddServerSideBlazor();
            
            //DI
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            
            services.AddDbContext<SchoolContext>(options =>
            {
                options.UseSqlServer(connectionString,
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
                //options.EnableSensitiveDataLogging();
                
                // Changing default behavior when client evaluation occurs to throw.
                // Default in EFCore would be to log warning when client evaluation is done.
                //options.ConfigureWarnings(warnings => warnings.Throw(
                //                              RelationalEventId.QueryClientEvaluationWarning));
            });
            
            /*services.AddSingleton<Logger>(container => new LoggerConfiguration()
                .ConfigureEnrichers(container)
                .ConfigureElk("http://elk:9200", Configuration.GetSection("Logging:Elk"), container)
                .ConfigureSelfLog(container)
                .CreateLogger());*/
            

            var mapperConfiguration = CreateConfiguration();
            var mapper = mapperConfiguration.CreateMapper();
            
            services.AddSingleton(mapper);
            
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IGradeService, GradeService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ISubjectService, SubjectService>();

            services.AddTransient<ITeacherRepository, TeacherRepository>();
            services.AddTransient<IGradeRepository, GradeRepository>();
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<ISubjectRepository, SubjectRepository>();

        }

        private MapperConfiguration CreateConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                // Add all profiles in current assembly
                cfg.AddProfile<TeacherServiceProfile>();
                cfg.AddProfile<GradeServiceProfile>();
                cfg.AddProfile<StudentServiceProfile>();
                cfg.AddProfile<SubjectServiceProfile>();
            });

            return config;
        }
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}