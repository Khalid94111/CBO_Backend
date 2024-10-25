using Volo.Abp.Settings;

namespace CBO.Settings;

public class CBOSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(CBOSettings.MySetting1));
    }
}
