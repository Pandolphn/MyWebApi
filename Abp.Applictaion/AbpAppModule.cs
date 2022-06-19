using MyAbp.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace Abp.Applictaion
{
    [DependsOn(typeof(AbpDddApplicationModule),
        typeof(AbpEntityModule),
        typeof(AbpAutoMapperModule))]
    public class AbpAppModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(opt =>
            {
                opt.AddProfile<AbpApplicationAutomapperProfile>();
            });
        }
    }
}
