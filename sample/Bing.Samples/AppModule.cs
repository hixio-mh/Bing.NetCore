using System.Text;
using Bing.AspNetCore;
using Bing.AutoMapper;
using Bing.Core.Modularity;
using Bing.DependencyInjection;
using Bing.Logs.Exceptionless;
using Bing.Logs.NLog;
using Bing.Samples.EventHandlers.Abstractions;
using Bing.Samples.EventHandlers.Implements;
using Bing.Utils.Json.Converters;
using Bing.Webs.Extensions;
using Bing.Webs.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Bing.Samples
{
    /// <summary>
    /// 应用程序模块
    /// </summary>
    [DependsOnModule(typeof(AspNetCoreModule))]
    public class AppModule : AspNetCoreBingModule
    {
        /// <summary>
        /// 模块级别。级别越小越先启动
        /// </summary>
        public override ModuleLevel Level => ModuleLevel.Application;

        /// <summary>
        /// 添加服务。将模块服务添加到依赖注入服务容器中
        /// </summary>
        /// <param name="services">服务集合</param>
        public override IServiceCollection AddServices(IServiceCollection services)
        {
            // 注册Mvc
            services
                .AddMvc(options =>
                {
                    options.Filters.Add<ValidationModelAttribute>();
                    options.Filters.Add<ResultHandlerAttribute>();
                    options.Filters.Add<ExceptionHandlerAttribute>();
                })
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                    options.SerializerSettings.Converters.Insert(0, new TrimmingConverter());
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddControllersAsServices();

            // 注册日志
            services.AddNLog();
            //services.AddExceptionless(o =>
            //{
            //    o.ServerUrl = "http://47.106.107.73:65000/";
            //    o.ApiKey = "7HY6E4gRBNwC83V5kYYmkOVfz5JTF9SABfLgD6PC";
            //});

            // 注册AutoMapper
            services.AddAutoMapper();
            // 启用AOP
            services.EnableAop();
            return services;
        }

        /// <summary>
        /// 应用AspNetCore的服务业务
        /// </summary>
        /// <param name="app">应用程序构建器</param>
        public override void UseModule(IApplicationBuilder app)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            app.UseErrorLog();
            app.UseStaticHttpContext();
            app.UseMvc(routes =>
            {
                routes.MapRoute("areaRoute", "{area:exists}/{controller}/{action=Index}/{id?}");
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
            Enabled = true;
        }
    }
}
