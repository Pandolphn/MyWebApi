using OrderService.Consul;

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
//微服务的实例注册
app.UseConsulRegistry(app.Lifetime);
app.Run();
