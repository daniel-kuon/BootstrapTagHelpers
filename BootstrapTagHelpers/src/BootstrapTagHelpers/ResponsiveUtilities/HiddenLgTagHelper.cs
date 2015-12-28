using BootstrapTagHelpers.Extensions;

namespace BootstrapTagHelpers.ResponsiveUtilities {
    using Microsoft.AspNet.Razor.TagHelpers;

    [OutputElementHint("div")]
    public class HiddenLgTagHelper : BootstrapTagHelper {
        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "div";
            output.AddCssClass("hidden-lg");
        }
    }
}