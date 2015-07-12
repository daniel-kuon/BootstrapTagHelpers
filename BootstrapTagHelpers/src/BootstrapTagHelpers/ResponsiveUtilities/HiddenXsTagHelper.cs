namespace BootstrapTagHelpers.ResponsiveUtilities {
    using Microsoft.AspNet.Razor.Runtime.TagHelpers;

    [TargetElement("HiddenXs")]
    public class HiddenXsTagHelper:BootstrapTagHelper {

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "div";
            output.AddCssClass("hidden-xs");
        }
    }
}