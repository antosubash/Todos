using Todos.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Todos
{
    [DependsOn(
        typeof(TodosEntityFrameworkCoreTestModule)
        )]
    public class TodosDomainTestModule : AbpModule
    {

    }
}