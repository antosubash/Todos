using System.Threading.Tasks;

namespace Todos.Data
{
    public interface ITodosDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
