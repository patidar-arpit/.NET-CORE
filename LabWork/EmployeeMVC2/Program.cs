using EmployeeMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<EmployeeLabExamContext>(options =>
                        options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeLabExamContext")));

            var app = builder.Build();

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
                pattern: "{controller=Employees}/{action=Index}/{id?}");

            app.Run();
        }
    }
}

//Scaffold-DbContext "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Employee_LabExam;Integrated Security=true" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models