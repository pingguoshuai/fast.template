﻿using Fast.Template.IdsAdmin.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Fast.Template.IdsAdmin;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(IdsAdminEntityFrameworkCoreTestModule)
    )]
public class IdsAdminDomainTestModule : AbpModule
{

}
