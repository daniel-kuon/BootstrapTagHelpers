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

        public bool CopyIfValueIsNull { get; set; }

        public CopyToOutputAttribute() {
        }

        public CopyToOutputAttribute(bool copyIfValueIsNull) {
            this.CopyIfValueIsNull = copyIfValueIsNull;
        }

        public CopyToOutputAttribute(string outputAttributeName) {
            OutputAttributeName = outputAttributeName;
        }

        public CopyToOutputAttribute(bool copyIfValueIsNull, string outputAttributeName) {
            OutputAttributeName = outputAttributeName;
            this.CopyIfValueIsNull = copyIfValueIsNull;
        }

        public CopyToOutputAttribute(string prefix, string suffix) {
            Prefix = prefix;
            Suffix = suffix;
        }

        public CopyToOutputAttribute(bool copyIfValueIsNull, string prefix, string suffix) {
            Prefix = prefix;
            Suffix = suffix;
            this.CopyIfValueIsNull = copyIfValueIsNull;
        }

        public CopyToOutputAttribute(bool copyIfValueIsNull, string outputAttributeName, string prefix, string suffix) {
            Prefix = prefix;
            Suffix = suffix;
            OutputAttributeName = outputAttributeName;
            this.CopyIfValueIsNull = copyIfValueIsNull;
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
                var attr = propertyInfo.GetCustomAttribute<CopyToOutputAttribute>();
                var value = propertyInfo.GetValue(target);
                if (value != null || attr.CopyIfValueIsNull)
                    output.Attributes.Add(attr.Prefix + (attr.OutputAttributeName??propertyInfo.GetHtmlAttributeName()) + attr.Suffix, value);
            }
        }
    }
}