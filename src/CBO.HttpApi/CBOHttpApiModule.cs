﻿using Localization.Resources.AbpUi;
using CBO.Localization;
using Volo.Abp.Account;
using Volo.Abp.AuditLogging;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.LanguageManagement;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.HttpApi;
using Volo.Saas.Host;
using Volo.Abp.Localization;
using Volo.Abp.SettingManagement;
using Volo.Abp.TextTemplateManagement;
using Volo.Abp.Gdpr;
using Volo.Abp.OpenIddict;
using Volo.CmsKit;
using Microsoft.Extensions.DependencyInjection;

namespace CBO;

 [DependsOn(
    typeof(CBOApplicationContractsModule),
    typeof(AbpIdentityHttpApiModule),
    typeof(AbpPermissionManagementHttpApiModule),
    typeof(AbpFeatureManagementHttpApiModule),
    typeof(AbpSettingManagementHttpApiModule),
    typeof(AbpAuditLoggingHttpApiModule),
    typeof(AbpOpenIddictProHttpApiModule),
    typeof(AbpAccountAdminHttpApiModule),
    typeof(LanguageManagementHttpApiModule),
    typeof(SaasHostHttpApiModule),
    typeof(AbpGdprHttpApiModule),
    typeof(CmsKitProHttpApiModule),
    typeof(TextTemplateManagementHttpApiModule)
    )]
public class CBOHttpApiModule : AbpModule
{
    //public override void ConfigureServices(ServiceConfigurationContext context)
    //{
    //    ConfigureLocalization();
    //}
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        ConfigureLocalization();
        context.Services.AddMvcCore()
      .AddMvcOptions(options =>
      {
          options.ModelBinderProviders.Insert(0, new DataSourceLoadOptionsBinderProvider());
      });
    }

    private void ConfigureLocalization()
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<CBOResource>()
                .AddBaseTypes(
                    typeof(AbpUiResource)
                );
        });
    }
}
