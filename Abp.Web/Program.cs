using Abp.Web;
using Abp.Web.Consul;

var builder = WebApplication.CreateBuilder(args);
 builder.Host.UseAutofac(); 
//builder.Logging.AddLog4Net("CfgFile/log4net.Config");
builder.Services.ReplaceConfiguration(builder.Configuration);
builder.Services.AddApplication<AbpwebModule>();

builder.Services.Configure<ConsulOptions>(builder.Configuration.GetSection("ConsulOptions"));


var app = builder.Build();

 app.InitializeApplication(); 
////΢�����ʵ��ע�� 
app.UseConsulRegistry(app.Lifetime);
app.Run();
