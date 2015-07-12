namespace BootstrapTagHelpers
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    using Microsoft.AspNet.Razor.Runtime.TagHelpers;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    public abstract class BootstrapTagHelper : TagHelper { 

        public const string AttributePrefix="bs-";

        /// <summary>
        /// If set, bootstrap tag helpers will not be applied
        /// </summary>
        [HtmlAttributeName(AttributePrefix + "disable-bootstrap")]
        public bool DisableBootstrap { get; set; }

        /// <summary>
        /// Checks if a bool attribute is true or is in the TagHelperContext with value different from false. This will also return true if the attribute is empty.
        /// </summary>
        /// <param name="expression">Attribute to check. Must be a bool</param>
        /// <param name="context">curent TagHelperContext</param>
        /// <returns></returns>
        public bool IsSet(Expression<Func<bool>> expression, TagHelperContext context) {
            var memberExpression = expression.GetMemberName();
            var attrName = memberExpression?.Member.GetCustomAttribute<HtmlAttributeNameAttribute>()?.Name;
            if (string.IsNullOrEmpty(attrName))
                attrName = memberExpression?.Member.Name;
            return expression.Compile()() || context.AllAttributes.ContainsKey(attrName) && (string) context.AllAttributes[attrName] != "false";
        }

        public override void Process(TagHelperContext context, TagHelperOutput output) {
            if (!IsSet(() => DisableBootstrap, context))
                BootstrapProcess(context, output);
        }

        protected abstract void BootstrapProcess(TagHelperContext context, TagHelperOutput output);

    }

}