namespace BootstrapTagHelpers {
    using System;
    using System.Linq;
    using System.Reflection;

    using BootstrapTagHelpers.Extensions;

    using Microsoft.AspNet.Razor.TagHelpers;

    /// <summary>
    ///     Properties marked with this Attribute will be automatically copied to the output of the TagHelper
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class CopyToOutputAttribute : Attribute {

        public string Prefix { get; set; }

        public string Suffix { get; set; }

        public string OutputAttributeName { get; set; }

        public CopyToOutputAttribute() {
        }

        public CopyToOutputAttribute(string outputAttributeName) : this(outputAttributeName, null) {
        }

        public CopyToOutputAttribute(string outputAttributeName, string prefix) : this(outputAttributeName, prefix, null) {
        }

        public CopyToOutputAttribute(string outputAttributeName, string prefix, string suffix) {
            Prefix = prefix;
            Suffix = suffix;
            OutputAttributeName = outputAttributeName;
        }

        public static void CopyPropertiesToOutput(object target, TagHelperOutput output) {
            if (target == null)
                throw new ArgumentNullException(nameof(target));
            if (output == null)
                throw new ArgumentNullException(nameof(output));
            foreach (var propertyInfo in target.GetType().GetProperties().Where(pI => pI.HasCustomAttribute<CopyToOutputAttribute>())) {
                var value = propertyInfo.GetValue(target);
                var attr = propertyInfo.GetCustomAttribute<CopyToOutputAttribute>();
                if (value != null)
                    output.Attributes.Add(attr.Prefix + (attr.OutputAttributeName??propertyInfo.GetHtmlAttributeName()) + attr.Suffix, value);
            }
        }
    }
}