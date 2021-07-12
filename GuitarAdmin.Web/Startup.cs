using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GuitarAdmin.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // 这个方法主要是做依赖注入工作的地方

            // ASP.NET Core 3.0版本以后引入MVC用这个api，以前是用AddMvc()
            // 我自己猜想是由于ASP.NET Core想打造成轻量级的应用，所以开发web应用时就引入基础的mvc功能（控制器和视图）而不包括Razor Pages的东西
            // 这样的目的是让有需要Razor时再引入，做到了轻量级的目的
            services.AddControllersWithViews();

            // 要是开发Webapi应用只引入控制器就行了，因为不需要视图
            // services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseHttpsRedirection();

            // 路由中间件
            // 由于ASP.NET Core 3.0中有路由功能的框架有许多：MVC、Razor Pages、SignalR等，所以3.0版本后就单拎出来了
            // 在3.0版本之前路由是放在MVC中间件里面的
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });

                // MVC的路由注册方式
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }

        // 如果当前在开发环境运行则会执行这个ConfigureDevelopment方法（环境变量值和Configure后面带的后缀名进行匹配）
        // 要是没有这个ConfigureDevelopment方法就会去找Configure方法
        // 这个特性对于Startup类、ConfigureServices方法、Configure方法均适用
        //public void ConfigureDevelopment(IApplicationBuilder app, IWebHostEnvironment env)
        //{

        //}
    }
}
