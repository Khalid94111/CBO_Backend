using Volo.Abp.Modularity;

namespace CBO;

/* Inherit from this class for your domain layer tests. */
public abstract class CBODomainTestBase<TStartupModule> : CBOTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
