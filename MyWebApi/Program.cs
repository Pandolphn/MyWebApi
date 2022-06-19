using Consul;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using MyWebApi.Consul;
using static System.Net.WebRequestMethods;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Logging.AddLog4Net("CfgFile/log4net.Config");
builder.Services.Configure<ConsulOptions>(builder.Configuration.GetSection("ConsulOptions"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app.MapGet("/api/health", () => {
//    global::System.Console.WriteLine("OK");
//    return new {Message="OK"};
//});
//微服务的实例注册
app.UseConsulRegistry(app.Lifetime); 
app.Run();


 