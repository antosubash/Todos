using Todos.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
namespace Todos.Permissions
{
    public class TodosPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(TodosPermissions.GroupName);

            var todoPermission = myGroup.AddPermission(TodosPermissions.Todo.Default, L("Permission:Default"))
            todoPermission.AddChild(TodosPermissions.Todo.Create, L("Permission:Create"));
            todoPermission.AddChild(TodosPermissions.Todo.Update, L("Permission:Update"));
            todoPermission.AddChild(TodosPermissions.Todo.Delete, L("Permission:Delete"));
            //Define your own permissions here. Example:
            //myGroup.AddPermission(TodosPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<TodosResource>(name);
        }
    }
}
