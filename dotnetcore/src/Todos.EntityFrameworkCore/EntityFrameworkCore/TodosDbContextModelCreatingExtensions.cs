using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Todos.EntityFrameworkCore
{
    public static class TodosDbContextModelCreatingExtensions
    {
        public static void ConfigureTodos(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            builder.Entity<Todo>(b =>
            {
                b.ToTable(TodosConsts.DbTablePrefix + "Todos", TodosConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
            });
        }
    }
}