﻿using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Fast.Template.Basic.MongoDB;

[ConnectionStringName(BasicDbProperties.ConnectionStringName)]
public class BasicMongoDbContext : AbpMongoDbContext, IBasicMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureBasic();
    }
}
