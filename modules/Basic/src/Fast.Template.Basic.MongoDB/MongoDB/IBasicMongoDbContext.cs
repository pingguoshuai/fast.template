﻿using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Fast.Template.Basic.MongoDB;

[ConnectionStringName(BasicDbProperties.ConnectionStringName)]
public interface IBasicMongoDbContext : IAbpMongoDbContext
{
    /* Define mongo collections here. Example:
     * IMongoCollection<Question> Questions { get; }
     */
}
