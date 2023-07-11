﻿using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Fast.Template.Basic.EntityFrameworkCore;

[ConnectionStringName(BasicDbProperties.ConnectionStringName)]
public interface IBasicDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
