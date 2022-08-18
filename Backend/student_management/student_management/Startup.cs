using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using student_management.DataContext;
using student_management.Repositries;
namespace student_management
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
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
                //options.AddPolicy("mpolicy", builder => builder.WithOrigins(""));
            });
            services.Configure<FormOptions>(o =>
            {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IStudentRepositriy, StudentRepositriy>();
            services.AddScoped<ITeacherRepositriy, TeacherRepositriy>();
            services.AddScoped<ICourseRepositriy, CourseRepositriy>();
            services.AddScoped<ISubjectsRepositriy, SubjectRepositriy>();
            services.AddScoped<IUserRepositriy, UserRepositriy>();
            services.AddScoped<IUserTypeRepositriy, UserTypeRepositriy>();
            services.AddScoped<IDegreeRepositriy, DegreeRepositriy>();
            services.AddScoped<ISectionsRepositriy, SectionsRepositriy>();
            services.AddScoped<ICitiesRepositriy, CitiesRepositriy>();
            services.AddScoped<ICountryRepositriy, CountryRepositriy>();
            services.AddScoped<IDistrictRepositriy, DistrictRepositriy>();
            services.AddScoped<IGenderRepositriy, GenderRepositriy>();
            services.AddScoped<ITitleRepositriy, TitleRepositriy>();
            services.AddScoped<IUserProfileRepositriy, UserProfileRepositriy>();
            services.AddScoped<ILanguagesRepositriy, LanguageRepositriy>();
            services.AddScoped<IGuardianRepositriy, GuardianRepositriy>();
            services.AddScoped<IQualificationRepositriy, QualificationRepositriy>();
            services.AddScoped<IFileRepositriy, FileRepositriy>();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors();
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
                RequestPath = new PathString("/Resources")
            });
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
