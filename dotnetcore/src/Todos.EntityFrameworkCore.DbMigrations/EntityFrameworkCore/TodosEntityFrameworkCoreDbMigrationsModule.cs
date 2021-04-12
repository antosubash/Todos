using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Todos.EntityFrameworkCore
{
    [DependsOn(
        typeof(TodosEntityFrameworkCoreModule)
        )]
    public class TodosEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<TodosMigrationsDbContext>();
        }
    }
}
