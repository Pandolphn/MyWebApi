using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;
using Volo.Abp;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication<AbpwebModule>();

var app = builder.Build();
app.InitializeApplication();


app.Run();
[DependsOn(
     typeof(AbpAspNetCoreMvcModule))]
public class AbpwebModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var services = context.Services;
        services.AddControllers();
        services.AddEndpointsApiExplorer();

        base.ConfigureServices(context);
    }
    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();
        app.UseRouting();

        app.UseHttpsRedirection();

        app.UseAuthorization();
        app.UseConfiguredEndpoints();

        base.OnApplicationInitialization(context);
    }
}