using Fast.Template.IdsAdmin.Localization;
using Volo.Abp.Application.Services;

namespace Fast.Template.IdsAdmin;

public abstract class IdsAdminAppService : ApplicationService
{
    protected IdsAdminAppService()
    {
        LocalizationResource = typeof(IdsAdminResource);
        ObjectMapperContext = typeof(IdsAdminApplicationModule);
    }
}
