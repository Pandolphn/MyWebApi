using Confluent.Kafka;
//using Entity.Models;
using Microsoft.AspNetCore.Mvc;
using Utility.AOP;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [TypeFilter(typeof(APIExceptionFilterAttribute))]
    public class OrderController
    {
        //[HttpPost]
        //public async Task<TOrder> CreateOrder()
        //{
        //    new Task(() =>
        //    {
        //        var consumerConfig = new ConsumerConfig
        //        {
        //            BootstrapServers = "127.0.0.1:9092",
        //            AutoOffsetReset = AutoOffsetReset.Latest,
        //            GroupId = Guid.NewGuid().ToString(),
        //            EnableAutoCommit = true,
        //        };
        //        var builder = new ConsumerBuilder<string, string>(consumerConfig);
        //        var consumer = builder.Build();
        //        //1订阅
        //        consumer.Subscribe("order-create");
        //        while (true)
        //        {
        //            //2消费
        //            var result=consumer.Consume();
        //            string key=result.Key;
        //            string value=result.Value;
        //        }

        //    }).Start();
        //    TOrder order = new TOrder();
        //    return order;
        //}
    }
}
