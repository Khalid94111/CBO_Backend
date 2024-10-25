using Volo.Abp.Modularity;

namespace CBO;

public abstract class CBOApplicationTestBase<TStartupModule> : CBOTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
