var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddIdentityServer()
    .AddDeveloperSigningCredential() //临时生成证书
    .AddInMemoryClients(ClientInitConfig.GetClients())       //inmemory内存模式
    .AddInMemoryApiScopes(ClientInitConfig.GetAoiScopes())//指定作用域
    .AddInMemoryApiResources(ClientInitConfig.GetApiResources())//访问资源
    ;

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

app.UseIdentityServer();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
