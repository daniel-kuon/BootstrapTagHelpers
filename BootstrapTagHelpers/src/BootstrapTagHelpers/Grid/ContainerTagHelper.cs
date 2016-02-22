using BootstrapTagHelpers.Extensions;

namespace BootstrapTagHelpers.Grid {
    using BootstrapTagHelpers.Attributes;

    using Microsoft.AspNet.Razor.TagHelpers;

    [OutputElementHint("div")]
    public class ContainerTagHelper : BootstrapTagHelper {
        [HtmlAttributeMinimizable]
        [HtmlAttributeNotBound]
        public bool Fluid { get; set; }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "div";
            output.AddCssClass(Fluid ? "container-fluid" : "container");
        }
    }
}