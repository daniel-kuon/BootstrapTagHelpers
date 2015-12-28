using BootstrapTagHelpers.Extensions;

namespace BootstrapTagHelpers.ResponsiveUtilities {
    using Microsoft.AspNet.Razor.TagHelpers;

    [OutputElementHint("div")]
    public class HiddenPrintTagHelper : BootstrapTagHelper {
        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "div";
            output.AddCssClass("hidden-print");
        }
    }
}