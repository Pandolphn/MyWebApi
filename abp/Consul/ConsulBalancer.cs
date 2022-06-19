using Consul;
using Microsoft.Extensions.Options;

namespace Abp.Web.Consul
{/// <summary>
/// 实现consul注册的同一个微服务实例负载均衡
/// </summary>
    public class ConsulBalancer
    {
        private ConsulOptions consulOptions;
        public ConsulBalancer(IOptionsMonitor<ConsulOptions> optionsMonitor)
        {
            this.consulOptions = optionsMonitor.CurrentValue;
        }
        public AgentService ChooseService(string serviceName)
        {
            var consulClient = new ConsulClient(c => c.Address = new Uri(consulOptions.ConsulHost!));
            var service = consulClient.Agent.Services().Result.Response;
            var targetServices=service.Where(c=>c.Value.Service.Equals(serviceName)).Select(c=>c.Value);
            var targetService=targetServices!.ElementAt(new Random().Next(1,1000)%targetServices.Count());
            return targetService;
        }
    }
}
