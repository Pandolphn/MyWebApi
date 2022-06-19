
using Abp.Applictaion;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Abp.Web
{
    [DependsOn(
     typeof(AbpAspNetCoreMvcModule) ,
      typeof(AbpAutofacModule),
      typeof(AbpAppModule)
        )]
    public class AbpwebModule: AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var services=context.Services;
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
           
            base.ConfigureServices(context);
        }
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();
             
            app.UseRouting();
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseConfiguredEndpoints();
            
            base.OnApplicationInitialization(context);
        }
    }
}
