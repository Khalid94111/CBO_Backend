using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace CBO.Web.Public;

[Dependency(ReplaceServices = true)]
public class CBOBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "CBO";
}
