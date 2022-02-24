using Applied_WebApp.SQLite;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;


namespace Applied_WebApp
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Applied_Middleware
    {
        private readonly RequestDelegate _next;

        public Applied_Middleware(RequestDelegate next)
        {
            CreateDatabase MyDataBase = new();
            CreateTables MyTables = new();

            if(MyDataBase.DBFile_Exist)
            {
                _next = next;
            }
            else
            {
                MyDataBase.CreateAppliedDB();
                MyTables.CreateTable("Users");
                _next = next;
            }
        }

        public Task Invoke(HttpContext httpContext)
        {

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class Applied_MiddlewareExtensions
    {
        public static IApplicationBuilder UseApplied_Middleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Applied_Middleware>();
        }
    }
}
