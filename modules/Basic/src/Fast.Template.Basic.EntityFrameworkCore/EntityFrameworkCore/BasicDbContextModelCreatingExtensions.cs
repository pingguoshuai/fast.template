using Fast.Template.Basic.Dics;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Fast.Template.Basic.EntityFrameworkCore;

public static class BasicDbContextModelCreatingExtensions
{
    public static void ConfigureBasic(
        this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        /* Configure all entities here. Example:

        builder.Entity<Question>(b =>
        {
            //Configure table & schema name
            b.ToTable(BasicDbProperties.DbTablePrefix + "Questions", BasicDbProperties.DbSchema);

            b.ConfigureByConvention();

            //Properties
            b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);

            //Relations
            b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

            //Indexes
            b.HasIndex(q => q.CreationTime);
        });
        */


        builder.Entity<DicType>(b =>
        {
            b.ToTable(BasicDbProperties.DbTablePrefix + "DicType", BasicDbProperties.DbSchema, table => table.HasComment("字典类型"));
            b.ConfigureByConvention(); 
            

            /* Configure more properties here */
        });
    }
}
