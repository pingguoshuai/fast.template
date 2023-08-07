using Fast.Template.Basic.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Fast.Template.Basic;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(BasicEntityFrameworkCoreTestModule)
    )]
public class BasicDomainTestModule : AbpModule
{

}
