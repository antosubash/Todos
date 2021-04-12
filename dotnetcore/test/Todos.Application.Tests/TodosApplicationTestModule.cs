using Volo.Abp.Modularity;

namespace Todos
{
    [DependsOn(
        typeof(TodosApplicationModule),
        typeof(TodosDomainTestModule)
        )]
    public class TodosApplicationTestModule : AbpModule
    {

    }
}