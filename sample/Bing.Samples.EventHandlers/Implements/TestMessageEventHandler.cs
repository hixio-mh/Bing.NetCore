using System;
using System.Threading.Tasks;
using Bing.Dependency;
using Bing.Events;
using Bing.Exceptions;
using Bing.Logs.Aspects;
using Bing.Logs.Extensions;
using Bing.Samples.Data;
using Bing.Samples.Domain.Events;
using Bing.Samples.Domain.Models;
using Bing.Samples.Domain.Services.Abstractions;
using Bing.Samples.EventHandlers.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Bing.Samples.EventHandlers.Implements
{
    /// <summary>
    /// 测试 消息事件处理器
    /// </summary>
    public class TestMessageEventHandler : MessageEventHandlerBase, ITestMessageEventHandler
    {
        /// <summary>
        /// 初始化一个<see cref="TestMessageEventHandler"/>类型的实例
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="roleManager">角色管理</param>
        /// <param name="serviceProvider">服务提供程序</param>
        public TestMessageEventHandler(ISampleUnitOfWork unitOfWork, IRoleManager roleManager, IServiceProvider serviceProvider)
        {
            UnitOfWork = unitOfWork;
            RoleManager = roleManager;
            ServiceProvider = serviceProvider;
        }

        /// <summary>
        /// 工作单元
        /// </summary>
        protected ISampleUnitOfWork UnitOfWork { get; set; }

        /// <summary>
        /// 角色管理
        /// </summary>
        protected IRoleManager RoleManager { get; set; }

        /// <summary>
        /// 服务提供程序
        /// </summary>
        protected IServiceProvider ServiceProvider { get; set; }

        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="message">消息</param>
        [EventHandler("CreateRole")]
        public async Task CreateRoleAsync(CreateRoleMessage message)
        {
            var role = new Role();
            role.Code = message.Code;
            role.Name = message.Name;
            role.Type = message.Type;
            role.Enabled = true;
            role.IsDeleted = false;
            //var begin = DateTime.Now;
            //Log.Caption("测试时间开始");
            //await Task.Delay(10000);
            //var end = DateTime.Now;
            //Log.Content($"{begin.ToDateTimeString()},{end.ToDateTimeString()}").Info();
            //throw new Warning("测试异常");
            await RoleManager.CreateAsync(role);
            await UnitOfWork.CommitAsync();
        }

        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="message">消息</param>
        [ErrorLog]
        [EventHandler("WriteLog")]
        public virtual Task WriteLogAsync(LogMessage message)
        {
            Log.Caption($"写入日志消息{nameof(WriteLogAsync)}")
                .Content(message.Content)
                .AddExtraProperty("Test", message.Content)
                .Info();
            throw new Warning("ttt");
            return Task.CompletedTask;
        }

        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="message">消息</param>
        [EventHandler("WriteLog")]
        public Task WriteLogWith2Async(LogMessage message)
        {
            Log.Caption($"写入日志消息 {nameof(WriteLogWith2Async)}")
                .Content(message.Content)
                .AddExtraProperty("Test", message.Content)
                .Info();
            return Task.CompletedTask;
        }

        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="message">消息</param>
        [EventHandler("WriteLog", Group = "group1.log")]
        public Task WriteLogByGroup1Async(LogMessage message)
        {
            Log.Caption($"写入日志消息 {nameof(WriteLogByGroup1Async)}")
                .Content(message.Content)
                .Info();
            return Task.CompletedTask;
        }

        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="message">消息</param>
        [EventHandler("WriteLog", Group = "group2.log")]
        public Task WriteLogByGroup2Async(LogMessage message)
        {
            Log.Caption("写入日志消息 group2.log")
                .Content(message.Content)
                .Fatal();
            return Task.CompletedTask;
        }
    }
}
