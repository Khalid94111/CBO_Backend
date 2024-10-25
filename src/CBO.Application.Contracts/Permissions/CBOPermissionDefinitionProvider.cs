using CBO.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace CBO.Permissions;

public class CBOPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(CBOPermissions.GroupName);

        myGroup.AddPermission(CBOPermissions.Dashboard.Host, L("Permission:Dashboard"), MultiTenancySides.Host);
        myGroup.AddPermission(CBOPermissions.Dashboard.Tenant, L("Permission:Dashboard"), MultiTenancySides.Tenant);

        //Define your own permissions here. Example:
        //myGroup.AddPermission(CBOPermissions.MyPermission1, L("Permission:MyPermission1"));

        var interestBankLendingRatePermission = myGroup.AddPermission(CBOPermissions.InterestBankLendingRates.Default, L("Permission:InterestBankLendingRates"));
        interestBankLendingRatePermission.AddChild(CBOPermissions.InterestBankLendingRates.Create, L("Permission:Create"));
        interestBankLendingRatePermission.AddChild(CBOPermissions.InterestBankLendingRates.Edit, L("Permission:Edit"));
        interestBankLendingRatePermission.AddChild(CBOPermissions.InterestBankLendingRates.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<CBOResource>(name);
    }
}