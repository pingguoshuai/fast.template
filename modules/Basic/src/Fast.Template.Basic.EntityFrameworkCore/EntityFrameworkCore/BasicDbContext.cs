using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Fast.Template.Basic.Dics;

namespace Fast.Template.Basic.EntityFrameworkCore;

[ConnectionStringName(BasicDbProperties.ConnectionStringName)]
public class BasicDbContext : AbpDbContext<BasicDbContext>, IBasicDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */
    /// <summary>
    /// 字典类型
    /// </summary>
    public DbSet<DicType> DicTypes { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public DbSet<Dicinfo> Dicinfos { get; set; }

    public BasicDbContext(DbContextOptions<BasicDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureBasic();
    }
}
