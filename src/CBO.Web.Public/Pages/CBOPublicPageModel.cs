using CBO.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace CBO.Web.Public.Pages;

/* Inherit your Page Model classes from this class.
 */
public abstract class CBOPublicPageModel : AbpPageModel
{
    protected CBOPublicPageModel()
    {
        LocalizationResourceType = typeof(CBOResource);
    }
}
