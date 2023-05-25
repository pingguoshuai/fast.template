using System.Threading.Tasks;

namespace Fast.Template.Start.Data;

public interface IStartDbSchemaMigrator
{
    Task MigrateAsync();
}
