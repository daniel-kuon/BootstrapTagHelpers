namespace BootstrapTagHelpers {
    using System;
    using System.Linq;

    using BootstrapTagHelpers.Extensions;

    using Microsoft.AspNet.Razor.TagHelpers;

    /// <summary>
    ///     Properties marked with this Attribute will be automatically copied to the output of the TagHelper
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class CopyToOutputAttribute : Attribute {

        public static void CopyPropertiesToOutput(object target, TagHelperOutput output) {
            if (target == null)
                throw new ArgumentNullException(nameof(target));
            if (output == null)
                throw new ArgumentNullException(nameof(output));
            foreach (var propertyInfo in target.GetType().GetProperties().Where(pI => pI.HasCustomAttribute<CopyToOutputAttribute>())) {
                var value = propertyInfo.GetValue(target);
                if (value != null)
                    output.Attributes.Add(propertyInfo.GetHtmlAttributeName(), value);
            }
        }
    }
}