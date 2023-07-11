using Fast.Template.Basic.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Fast.Template.Basic;

public abstract class BasicController : AbpControllerBase
{
    protected BasicController()
    {
        LocalizationResource = typeof(BasicResource);
    }
}
