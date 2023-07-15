using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Fast.Template.Basic.Dics;

namespace Fast.Template.Basic.EntityFrameworkCore;

[ConnectionStringName(BasicDbProperties.ConnectionStringName)]
public interface IBasicDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
    /// <summary>
    /// 字典类型
    /// </summary>
    DbSet<DicType> DicTypes { get; set; }
    /// <summary>
    /// 
    /// </summary>
    DbSet<Dicinfo> Dicinfos { get; set; }
}
