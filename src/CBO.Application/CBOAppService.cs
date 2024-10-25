using CBO.Localization;
using Volo.Abp.Application.Services;

namespace CBO;

/* Inherit your application services from this class.
 */
public abstract class CBOAppService : ApplicationService
{
    protected CBOAppService()
    {
        LocalizationResource = typeof(CBOResource);
    }
}
