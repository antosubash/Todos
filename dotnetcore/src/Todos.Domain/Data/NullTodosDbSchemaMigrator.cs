using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Todos.Data
{
    /* This is used if database provider does't define
     * ITodosDbSchemaMigrator implementation.
     */
    public class NullTodosDbSchemaMigrator : ITodosDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}