namespace BootstrapTagHelpers {
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    using BootstrapTagHelpers.Extensions;

    using Microsoft.AspNet.Mvc.Infrastructure;
    using Microsoft.AspNet.Mvc.ViewFeatures;
    using Microsoft.AspNet.Razor.TagHelpers;

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
            HtmlAttributeMinimizableAttribute.FillMinimizableAttributes(this, context);
            AutoGenerateIdAttribute.GenerateIds(this);
            ConvertVirtualUrlAttribute.ConvertUrls(this, ActionContextAccessor);
        }

        public override void Process(TagHelperContext context, TagHelperOutput output) {
            Output = output;
            CopyPropertiesToOutput();
            if (!DisableBootstrap) {
                BootstrapProcess(context, output);
                RemoveMinimizableAttributes(output);
            }
        }

        private void CopyPropertiesToOutput() {
            foreach (var propertyInfo in GetType().GetProperties().Where(pI => pI.HasCustomAttribute<CopyToOutputAttribute>())) {
                var value = propertyInfo.GetValue(this);
                if (value != null)
                    Output.Attributes.Add(propertyInfo.GetHtmlAttributeName(), value);
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
            output.Attributes.RemoveAll(
                                        GetType()
                                            .GetProperties()
                                            .Where(
                                                   pI =>
                                                   pI.GetCustomAttribute<HtmlAttributeMinimizableAttribute>() != null)
                                            .Select(pI => pI.GetHtmlAttributeName())
                                            .ToArray());
        }

        protected virtual void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
        }

        protected virtual async Task BootstrapProcessAsync(TagHelperContext context, TagHelperOutput output) {
            BootstrapProcess(context, output);
        }
    }
}