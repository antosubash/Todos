using System;
using System.Collections.Generic;
using System.Text;
using Todos.Localization;
using Volo.Abp.Application.Services;

namespace Todos
{
    /* Inherit your application services from this class.
     */
    public abstract class TodosAppService : ApplicationService
    {
        protected TodosAppService()
        {
            LocalizationResource = typeof(TodosResource);
        }
    }
}
