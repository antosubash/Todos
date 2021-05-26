using System;
using System.Collections.Generic;
using System.Text;
using Todos.Localization;
using Volo.Abp.Features;
using Volo.Abp.Localization;
using Volo.Abp.Validation.StringValues;

namespace Todos.Features
{
    public class TodoFeatureDefinitionProvider : FeatureDefinitionProvider
    {
        public override void Define(IFeatureDefinitionContext context)
        {
            var myGroup = context.AddGroup("MyTodoApp");

            myGroup.AddFeature(
                TodoFeatures.Todo,
                defaultValue: "false",
                displayName: L("Todo"),
                valueType: new ToggleStringValueType()
            );

            myGroup.AddFeature(
                TodoFeatures.MaxTodoPerUser,
                defaultValue: "10",
                displayName: L("MaxTodoPerUser"),
                valueType: new FreeTextStringValueType(
                               new NumericValueValidator(0, 1000000))
            );
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<TodosResource>(name);
        }
    }
}
