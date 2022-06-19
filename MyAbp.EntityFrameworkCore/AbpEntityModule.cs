using MyAbp.EntityFrameworkCore.AbpModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace MyAbp.EntityFrameworkCore
{
    [DependsOn(typeof(AbpEntityFrameworkCoreModule))]
    public class AbpEntityModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<AbpDbContext>(opt => {
                opt.AddDefaultRepositories(true);
            });

            Configure<AbpDbContextOptions>(x => {
                x.UseMySQL();
            });
        }
    }
}
