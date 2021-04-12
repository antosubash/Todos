using Todos.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Todos.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class TodosController : AbpController
    {
        protected TodosController()
        {
            LocalizationResource = typeof(TodosResource);
        }
    }
}