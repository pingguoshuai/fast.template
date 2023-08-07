using System;
using System.Collections.Generic;
using System.Text;
using Fast.Template.Start.Localization;
using Volo.Abp.Application.Services;

namespace Fast.Template.Start;

/* Inherit your application services from this class.
 */
public abstract class StartAppService : ApplicationService
{
    protected StartAppService()
    {
        LocalizationResource = typeof(StartResource);
    }
}
