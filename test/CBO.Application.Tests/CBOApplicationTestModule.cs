using Volo.Abp.Modularity;

namespace CBO;

[DependsOn(
    typeof(CBOApplicationModule),
    typeof(CBODomainTestModule)
)]
public class CBOApplicationTestModule : AbpModule
{

}
