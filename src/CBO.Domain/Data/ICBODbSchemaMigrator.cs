using System.Threading.Tasks;

namespace CBO.Data;

public interface ICBODbSchemaMigrator
{
    Task MigrateAsync();
}
