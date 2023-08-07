using Fast.Template.Start.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Fast.Template.Start.Web.Pages;

public abstract class StartPageModel : AbpPageModel
{
    protected StartPageModel()
    {
        LocalizationResourceType = typeof(StartResource);
    }
}
