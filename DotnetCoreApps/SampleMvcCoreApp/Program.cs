using Microsoft.EntityFrameworkCore;
using DotNetCorelib.DTOs;
namespace SampleMvcCoreApp
{
    public class Program

    {
        public static IConfiguration Configuration { get; set; }
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<DotNetCorelib.Data.FnftrainingContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("myCon")));

            builder.Services.AddScoped<DotNetCorelib.DTOs.IEmployee, DotNetCorelib.DTOs.EmployeeRepo>();

            var app = builder.Build();
            Program.Configuration = app.Configuration;

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=DllDemo}/{action=Index}/{id?}");

            app.Run();
        }
    }
}





        

           
