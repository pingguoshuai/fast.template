using Fast.Template.Start.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Fast.Template.Start.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(StartEntityFrameworkCoreModule),
    typeof(StartApplicationContractsModule)
    )]
public class StartDbMigratorModule : AbpModule
{

}
