using Microsoft.EntityFrameworkCore;
using Proj3MvcCoreApp.Models;
using System.Web.Mvc;
using AspNetCore.Unobtrusive.Ajax;
using static System.Net.Mime.MediaTypeNames;

namespace Proj3MvcCoreApp
    {
    public class Program
        {
        //The place where the Program runs.......
        public static void Main(string[] args)
            {
            // CreateBuilder will build a min ASP .NET Web application. It takes the command lines argument if required for the application
            var builder = WebApplication.CreateBuilder(args);
            //U can add middleware for UR app like authentication, db server, asp .net pipelines: webforms, mvc, web api
            builder.Services.AddDbContext<MyDbContext>((context) =>
            {
                context.UseSqlServer("Data Source=W-674PY03-2;Initial Catalog=SMRUTI_db;Persist Security Info=True;User ID=SA;Password=Password@123456-=; TrustServerCertificate = True");
            });

            builder.Services.AddTransient<IDBComponent, DbComponent>();
            builder.Services.AddMvc();
            builder.Services.AddControllersWithViews();
            var app = builder.Build();
            app.UseStaticFiles();
            app.UseUnobtrusiveAjax();

            /********************* Routes for UR URL Pattern ***********************/

            app.MapControllerRoute("default", "{controller}/{action}/{id}", new {controller = "Employee", action="Index", id = UrlParameter.Optional});
            //const string pattern = "{controller}/{action}/{id}";
            //app.MapControllerRoute("default", pattern, new { controller = "Home", action = "Index", id = UrlParameter.Optional });
            //app.MapGet("/", () => "Hello World!");

            //app.MapControllerRoute("default", "{controller=Employee}/{action=Index}/{id=?}");


            app.Run();
            }
        }
    }