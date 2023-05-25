using Fast.Template.IdsAdmin.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Fast.Template.IdsAdmin;

public abstract class IdsAdminController : AbpControllerBase
{
    protected IdsAdminController()
    {
        LocalizationResource = typeof(IdsAdminResource);
    }
}
