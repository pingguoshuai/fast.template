using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Fast.Template.Start.Web;

[Dependency(ReplaceServices = true)]
public class StartBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Start";
}
