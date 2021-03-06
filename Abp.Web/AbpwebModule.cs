
using Abp.Applictaion;
using Microsoft.Extensions.Options;
using Utility.RAS;
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
           
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();


            //services.AddAuthentication("Bearer")//Scheme：指定读信息方式Bearer-
            //     .AddIdentityServerAuthentication(options => {
            //         options.Authority = "http://loaclhost:5092";//ids4的地址-专门获取公钥
            //         options.ApiName = "UserApi";
            //         options.RequireHttpsMetadata = false;
            //     });

            //hashid
            //c => c.OperationFilter<HashidsOperationFilter>() 使用swagger请求时需要注入这filter把参数接受类型改成string。其他请求不影响
            services.AddHashids(options => {
                options.MinHashLength = 6;
                options.Salt = "MyAbpDemo";
            }).AddControllers();

            //ras单例
            services.AddSingleton<IRSAHelper, RSAHelper> ();
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
