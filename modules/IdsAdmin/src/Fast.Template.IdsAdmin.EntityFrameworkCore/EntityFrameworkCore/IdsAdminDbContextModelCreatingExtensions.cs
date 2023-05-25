using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace Fast.Template.IdsAdmin.EntityFrameworkCore;

public static class IdsAdminDbContextModelCreatingExtensions
{
    public static void ConfigureIdsAdmin(
        this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        /* Configure all entities here. Example:

        builder.Entity<Question>(b =>
        {
            //Configure table & schema name
            b.ToTable(IdsAdminDbProperties.DbTablePrefix + "Questions", IdsAdminDbProperties.DbSchema);

            b.ConfigureByConvention();

            //Properties
            b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);

            //Relations
            b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

            //Indexes
            b.HasIndex(q => q.CreationTime);
        });
        */
    }
}
