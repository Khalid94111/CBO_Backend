using CBO.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace CBO.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class CBOController : AbpControllerBase
{
    protected CBOController()
    {
        LocalizationResource = typeof(CBOResource);
    }
}
