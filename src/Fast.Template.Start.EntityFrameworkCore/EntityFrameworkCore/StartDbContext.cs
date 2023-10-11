using Fast.Template.Basic.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Microsoft.EntityFrameworkCore.Storage;
using Npgsql.EntityFrameworkCore.PostgreSQL.Storage.Internal;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace Fast.Template.Start.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class StartDbContext :
    AbpDbContext<StartDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public StartDbContext(DbContextOptions<StartDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureIdentityServer();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();
        builder.ConfigureBasic();

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(StartConsts.DbTablePrefix + "YourEntities", StartConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
        TableMappingTo(builder, s => true, s => s.ToLower());
    }

    void TableMappingTo(ModelBuilder modelBuilder,
            Func<IMutableEntityType, bool> verifyingEntityType,
            Func<string, string> processString)
    {
        if (modelBuilder == null)
        {
            throw new ArgumentNullException(nameof(modelBuilder));
        }

        if (verifyingEntityType == null)
        {
            throw new ArgumentNullException(nameof(verifyingEntityType));
        }

        if (processString == null)
        {
            throw new ArgumentNullException(nameof(processString));
        }


        var model = modelBuilder.Model;
        foreach (var entityType in model.GetEntityTypes())
        {
            // 校验
            if (!verifyingEntityType(entityType))
            {
                continue;
            }

            //var entityBuilder = modelBuilder.Entity(entityType.ClrType);

            // 表名处理
            {
                //var tabaleName = entityBuilder.Metadata.GetTableName();
                var tabaleName = entityType.GetTableName();
                entityType.SetTableName(processString.Invoke(tabaleName));
                //entityBuilder.Metadata.SetTableName(processString.Invoke(tabaleName));
            }

            // 列名处理
            {
                var annotation = default(IAnnotation);
                var columnName = string.Empty;
                foreach (var property in entityType.GetProperties())
                {
#if NETSTANDARD2_1
                    columnName = property.GetColumnBaseName();
#else
                    columnName = property.GetColumnName();
#endif
                    annotation = property.FindAnnotation(RelationalAnnotationNames.ColumnName);
                    if (annotation != null && annotation.Value != null)
                    {
                        columnName = annotation.Value.ToString();
                    }
                    property.SetColumnName(
                        processString.Invoke(columnName)
                    );
                }
            }

            // 主键处理
            {
                var keyName = string.Empty;
                var keys = entityType.GetKeys();
                foreach (var key in keys)
                {
                    keyName = key.GetName();
                    if (string.IsNullOrEmpty(keyName))
                    {
                        keyName = key.GetDefaultName();
                    }
                    keyName = processString.Invoke(keyName);
                    key.SetName(keyName);
                }
            }

            // 外键处理
            {
                var keyName = string.Empty;
                var keys = entityType.GetForeignKeys();
                foreach (var key in keys)
                {
                    keyName = key.GetConstraintName();
                    if (string.IsNullOrEmpty(keyName))
                    {
                        keyName = key.GetDefaultName();
                    }
                    keyName = processString.Invoke(keyName);
                    key.SetConstraintName(keyName);
                }
            }

//            // 索引处理
//            {
//                var keyName = string.Empty;
//                var keys = entityType.GetIndexes();
//                foreach (var key in keys)
//                {
//#if NETSTANDARD2_1
//                                    keyName = key.GetDatabaseName();
//                                    if (string.IsNullOrEmpty(keyName))
//                                    {
//                                        keyName = key.GetDefaultDatabaseName();
//                                    }
//                                    keyName = processString.Invoke(keyName);
//                                    key.SetDatabaseName(keyName);       
//#else

//                    keyName = key.Name;
//                    //if (string.IsNullOrEmpty(keyName))
//                    //{
//                    //    keyName = key.Name;
//                    //}
//                    keyName = processString.Invoke(keyName);
//                    key.SetName(keyName);
//#endif
//                }
//            }
        }
    }

    public class RivenPostgreSqlGenerationHelper : NpgsqlSqlGenerationHelper
    {
        public RivenPostgreSqlGenerationHelper([NotNull] RelationalSqlGenerationHelperDependencies dependencies)
            : base(dependencies)
        {
        }

        public override string DelimitIdentifier(string identifier)
        {
            return base.DelimitIdentifier(identifier.ToLower());
        }

        public override void DelimitIdentifier(StringBuilder builder, string identifier)
        {
            base.DelimitIdentifier(builder, identifier.ToLower());
        }

        public override string EscapeIdentifier(string identifier)
        {
            return base.EscapeIdentifier(
                identifier.ToLower()
            );
        }

        public override void EscapeIdentifier(StringBuilder builder, string identifier)
        {
            base.EscapeIdentifier(
                builder,
                identifier.ToLower()
            );
        }
    }
}
