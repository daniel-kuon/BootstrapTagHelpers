using Microsoft.AspNet.Razor.TagHelpers;

namespace BootstrapTagHelpers {
    using System;
    using System.Linq.Expressions;
    using System.Reflection;

    public static class TagHelperContextExtensions {

        /// <summary>
        /// Checks if a bool attribute is true or is in the TagHelperContext with value different from false. This will also return true if the attribute is empty.
        /// </summary>
        /// <param name="expression">Attribute to check. Must be a bool</param>
        /// <param name="context">curent TagHelperContext</param>
        /// <returns></returns>
        public static bool IsSet(this TagHelperContext context, Expression<Func<bool>> expression) {
            var memberExpression = expression.GetMemberName();
            var attrName = memberExpression?.Member.GetCustomAttribute<HtmlAttributeNameAttribute>()?.Name;
            if (string.IsNullOrEmpty(attrName))
                attrName = memberExpression?.Member.Name;
            return expression.Compile()() || context.AllAttributes.ContainsName(attrName) && (string)context.AllAttributes[attrName].Value != "false";
        }
    }
}