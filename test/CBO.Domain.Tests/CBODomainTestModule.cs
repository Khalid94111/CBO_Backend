using Volo.Abp.Modularity;

namespace CBO;

[DependsOn(
    typeof(CBODomainModule),
    typeof(CBOTestBaseModule)
)]
public class CBODomainTestModule : AbpModule
{

}
