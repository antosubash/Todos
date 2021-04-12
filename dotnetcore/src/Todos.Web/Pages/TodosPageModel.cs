using Todos.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Todos.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class TodosPageModel : AbpPageModel
    {
        protected TodosPageModel()
        {
            LocalizationResourceType = typeof(TodosResource);
        }
    }
}