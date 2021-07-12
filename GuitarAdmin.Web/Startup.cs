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
            // ���������Ҫ��������ע�빤���ĵط�

            // ASP.NET Core 3.0�汾�Ժ�����MVC�����api����ǰ����AddMvc()
            // ���Լ�����������ASP.NET Core��������������Ӧ�ã����Կ���webӦ��ʱ�����������mvc���ܣ�����������ͼ����������Razor Pages�Ķ���
            // ������Ŀ����������ҪRazorʱ�����룬��������������Ŀ��
            services.AddControllersWithViews();

            // Ҫ�ǿ���WebapiӦ��ֻ��������������ˣ���Ϊ����Ҫ��ͼ
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

            // ·���м��
            // ����ASP.NET Core 3.0����·�ɹ��ܵĿ������ࣺMVC��Razor Pages��SignalR�ȣ�����3.0�汾��͵��������
            // ��3.0�汾֮ǰ·���Ƿ���MVC�м�������
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });

                // MVC��·��ע�᷽ʽ
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }

        // �����ǰ�ڿ��������������ִ�����ConfigureDevelopment��������������ֵ��Configure������ĺ�׺������ƥ�䣩
        // Ҫ��û�����ConfigureDevelopment�����ͻ�ȥ��Configure����
        // ������Զ���Startup�ࡢConfigureServices������Configure����������
        //public void ConfigureDevelopment(IApplicationBuilder app, IWebHostEnvironment env)
        //{

        //}
    }
}
