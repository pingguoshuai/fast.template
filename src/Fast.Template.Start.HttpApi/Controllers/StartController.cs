using Fast.Template.Start.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Fast.Template.Start.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class StartController : AbpControllerBase
{
    protected StartController()
    {
        LocalizationResource = typeof(StartResource);
    }
}
