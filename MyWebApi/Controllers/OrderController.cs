using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;
using MyWebApi.Dtos;
using Newtonsoft.Json;
using Utility.AOP;

namespace MyWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [TypeFilter(typeof(APIExceptionFilterAttribute))]
    public class OrderController
    {
        [HttpPost]
        public void CreateOrder(OrderCreateDto dto)
        {
            #region 异步创建订单
            {
                var producerConfig = new ProducerConfig
                {
                    BootstrapServers = "127.0.0.1:9092",
                    MessageTimeoutMs = 50000
                };
                var builder=new ProducerBuilder<string,string>(producerConfig); 
                using(var producer = builder.Build())
                {
                    
                        var OrderJson = JsonConvert.SerializeObject(dto);
                        var dr = producer.ProduceAsync("order-create", new Message<string, string>
                        { Key = "order", Value = OrderJson }).GetAwaiter().GetResult();
                  
                }
            }
            #endregion
        }
    }
}
