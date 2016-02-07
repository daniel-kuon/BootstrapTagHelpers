using BootstrapTagHelpers.Extensions;
using BootstrapTagHelpers.Navigation;
using Microsoft.AspNet.Mvc.Infrastructure;
using Microsoft.AspNet.Mvc.Rendering;

namespace BootstrapTagHelpers {
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Razor.TagHelpers;
    using Microsoft.AspNet.Mvc.ViewFeatures;
    public abstract class BootstrapTagHelper : TagHelper {
        public const string AttributePrefix = "b-";
        public const string DisableBootstrapAttributeName = AttributePrefix + "disable-bootstrap";

        /// <summary>
        ///     If set, bootstrap tag helpers will not be applied
        /// </summary>
        [HtmlAttributeName(DisableBootstrapAttributeName)]
        [HtmlAttributeNotBound]
        [HtmlAttributeMinimizable]
        public bool DisableBootstrap { get; set; }

        [HtmlAttributeNotBound]
        public TagHelperOutput Output { get; set; }

        [HtmlAttributeNotBound]
        [ViewContext]
        public IActionContextAccessor ActionContextAccessor { get; set; }

        public override void Init(TagHelperContext context) {
            FillMinimizableAttributes(context);
            ConvertVirtualUrlAttribute.ConvertUrls(this, ActionContextAccessor);
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            Output = output;
            CopyPropertiesToOutput();
            if (!DisableBootstrap) {
                BootstrapProcess(context, output);
                RemoveMinimizableAttributes(output);
            }
        }

        private void CopyPropertiesToOutput() {
            foreach (PropertyInfo propertyInfo in GetType().GetProperties().Where(pI=>pI.HasCustomAttribute<CopyToOutputAttribute>())) {
                object value = propertyInfo.GetValue(this);
                if (value!=null)
                    Output.Attributes.Add(GetAttributeName(propertyInfo), value);
            }
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output) {
            Output = output;
            CopyPropertiesToOutput();
            if (!DisableBootstrap) {
                await BootstrapProcessAsync(context, output);
                RemoveMinimizableAttributes(output);
            }
        }

        private void RemoveMinimizableAttributes(TagHelperOutput output) {
            output.Attributes.RemoveAll(GetType()
                                            .GetProperties()
                                            .Where(
                                                   pI =>
                                                   pI.GetCustomAttribute<HtmlAttributeMinimizableAttribute>() != null)
                                            .Select(GetAttributeName)
                                            .ToArray());
        }

        protected virtual void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
        }

        protected virtual async Task BootstrapProcessAsync(TagHelperContext context, TagHelperOutput output) {
            BootstrapProcess(context, output);
        }

        private void FillMinimizableAttributes(TagHelperContext context) {
            IEnumerable<PropertyInfo> minimizableProperties =
                GetType()
                    .GetProperties()
                    .Where(pI => pI.GetCustomAttribute<HtmlAttributeMinimizableAttribute>() != null);
            foreach (PropertyInfo property in minimizableProperties) {
                string attributeName = GetAttributeName(property);
                if (!context.AllAttributes.ContainsName(attributeName))
                    continue;
                IReadOnlyTagHelperAttribute attribute = context.AllAttributes[attributeName];
                if (attribute.Value is bool)
                    property.SetValue(this, attribute.Value);
                else if (attribute.Minimized)
                    property.SetValue(this, true);
                else
                    property.SetValue(this, !(attribute.Value ?? "").ToString().Equals("false"));
            }
        }

        private string GetAttributeName(PropertyInfo property) {
            var htmlAttributeNameAttribute = property.GetCustomAttribute<HtmlAttributeNameAttribute>();
            if (htmlAttributeNameAttribute != null)
                return htmlAttributeNameAttribute.DictionaryAttributePrefix + htmlAttributeNameAttribute.Name;
            return Regex.Replace(property.Name, "([A-Z])", "-$1").ToLower().Trim('-');
        }
    }
}