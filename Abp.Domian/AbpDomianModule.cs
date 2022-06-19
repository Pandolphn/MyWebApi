using Volo.Abp.Domain;
using Volo.Abp.Modularity;
namespace Abp.Domian
{
    [DependsOn(typeof(AbpDddDomainModule) )]
    public class AbpDomianModule:AbpModule
    {

    }
}