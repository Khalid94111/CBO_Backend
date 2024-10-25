using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace CBO.Data;

/* This is used if database provider does't define
 * ICBODbSchemaMigrator implementation.
 */
public class NullCBODbSchemaMigrator : ICBODbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
