using Consul;
using log4net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Utility.AOP;

namespace MyWebApi.Consul
{
    //[TypeFilter(typeof(APIExceptionFilterAttribute))]
    public static class ConsulRegistryExtensions
    {
        public static WebApplication UseConsulRegistry(this WebApplication webApplication,IHostApplicationLifetime lifetime)
        {
            //获取log4net的logger对象
            var logger=LogManager.GetLogger(typeof(ConsulRegistryExtensions));
            var optionMonitor = webApplication.Services.GetService<IOptionsMonitor<ConsulOptions>>();
            var consulOptions = optionMonitor!.CurrentValue;
            //获取心跳检测ip和port
            var ip = webApplication.Configuration["ip"] ?? consulOptions.IP;
            var port=webApplication.Configuration["port"]??consulOptions.Port;

            //生成serviceId
            var serviceId=Guid.NewGuid().ToString();
            logger!.InfoFormat("ip={0},port={1}", ip, port);
            //创建连接Consul客户端对象
            var consulClient = new ConsulClient(c =>
              {
                  c.Address = new Uri(consulOptions!.ConsulHost!);
                  c.Datacenter = consulOptions.ConsulDataCenter;
              });
           
            //把服务注册到Consul上
            consulClient.Agent.ServiceRegister(new AgentServiceRegistration()
            {
                ID = serviceId,
                Name = consulOptions.ServiceName,
                Address = ip,
                Port = Convert.ToInt32(port),
                Check = new AgentServiceCheck()
                {
                    Interval = TimeSpan.FromSeconds(10), 
                    HTTP = $"http://{ip}:{port}/api/Health", 
                    Timeout = TimeSpan.FromSeconds(5),  
                    DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(10) 
                }
            });/*.Wait() */

            //注销实例
            lifetime.ApplicationStopped.Register(async() =>
            {
                  await consulClient.Agent.ServiceDeregister(serviceId) ;
            });
            return webApplication;
        }
    }
}
