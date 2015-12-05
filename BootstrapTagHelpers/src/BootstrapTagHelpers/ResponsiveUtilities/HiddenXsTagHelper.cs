using Microsoft.AspNet.Razor.TagHelpers;

namespace BootstrapTagHelpers.ResponsiveUtilities {
    [HtmlTargetElement("HiddenXs")]
    public class HiddenXsTagHelper:BootstrapTagHelper {

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "div";
            output.AddCssClass("hidden-xs");
        }
    }
}