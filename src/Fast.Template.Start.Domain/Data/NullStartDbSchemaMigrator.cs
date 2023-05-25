using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Fast.Template.Start.Data;

/* This is used if database provider does't define
 * IStartDbSchemaMigrator implementation.
 */
public class NullStartDbSchemaMigrator : IStartDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
