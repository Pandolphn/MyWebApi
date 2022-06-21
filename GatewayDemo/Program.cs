using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;
using Ocelot.Cache.CacheManager;
var builder = WebApplication.CreateBuilder(args);
 
builder.Services.AddOcelot()
    .AddConsul()
    .AddCacheManager(x => {
        x.WithDictionaryHandle();
    });


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Configuration.AddJsonFile("configuration.json",
    optional:false,
    reloadOnChange:true);
   
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseOcelot();
//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

app.Run();
