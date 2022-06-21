
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
            //services.AddAuthentication("Bearer")//Scheme：指定读信息方式Bearer-
            //     .AddIdentityServerAuthentication(options => {
            //         options.Authority = "http://loaclhost:5092";//ids4的地址-专门获取公钥
            //         options.ApiName = "UserApi";
            //         options.RequireHttpsMetadata = false;
            //     });
            base.ConfigureServices(context);
        }
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();
           //   app.UseAuthorization();//执行授权
             //app.UseAuthentication();//支持鉴权
            app.UseRouting();
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseHttpsRedirection();

           
            app.UseConfiguredEndpoints();
            
            base.OnApplicationInitialization(context);
        }
    }
}
