using Volo.Abp.Settings;

namespace Todos.Settings
{
    public class TodosSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(TodosSettings.MySetting1));
        }
    }
}
