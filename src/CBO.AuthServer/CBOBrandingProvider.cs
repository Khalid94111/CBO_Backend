using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace CBO;

[Dependency(ReplaceServices = true)]
public class CBOBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Central Bank Of Oman";
}
