namespace Abp.Web.Consul
{
    public class ConsulOptions
    {
        public string? IP { get;set; }
        public string? Port { get;set; } 
        /// <summary>
        /// 微服务名称
        /// </summary>
        public string? ServiceName { get;set; }
        /// <summary>
        /// Consul对应请求地址
        /// </summary>
        public string? ConsulHost { get; set; }
        /// <summary>
        /// Consul数据中心默认dc1
        /// </summary>
        public string? ConsulDataCenter { get; set; }
    }
}
