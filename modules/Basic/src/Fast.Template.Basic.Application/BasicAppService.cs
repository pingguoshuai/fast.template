using Fast.Template.Basic.Localization;
using Volo.Abp.Application.Services;

namespace Fast.Template.Basic;

public abstract class BasicAppService : ApplicationService
{
    protected BasicAppService()
    {
        LocalizationResource = typeof(BasicResource);
        ObjectMapperContext = typeof(BasicApplicationModule);
    }
}
