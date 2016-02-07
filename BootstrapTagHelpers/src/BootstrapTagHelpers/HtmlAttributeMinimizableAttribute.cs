namespace BootstrapTagHelpers {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using BootstrapTagHelpers.Extensions;

    using Microsoft.AspNet.Razor.TagHelpers;

    [AttributeUsage(AttributeTargets.Property)]
    public class HtmlAttributeMinimizableAttribute : Attribute {

        public static void FillMinimizableAttributes(object target, TagHelperContext context)
        {
            if (target == null)
                throw new ArgumentNullException(nameof(target));
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            IEnumerable<PropertyInfo> minimizableProperties =
                target.GetType()
                    .GetProperties()
                    .Where(pI => pI.GetCustomAttribute<HtmlAttributeMinimizableAttribute>() != null);
            foreach (PropertyInfo property in minimizableProperties)
            {
                string attributeName = property.GetHtmlAttributeName();
                if (!context.AllAttributes.ContainsName(attributeName))
                    continue;
                IReadOnlyTagHelperAttribute attribute = context.AllAttributes[attributeName];
                if (attribute.Value is bool)
                    property.SetValue(target, attribute.Value);
                else if (attribute.Minimized)
                    property.SetValue(target, true);
                else
                    property.SetValue(target, !(attribute.Value ?? "").ToString().Equals("false"));
            }
        }

    }
}