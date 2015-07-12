namespace BootstrapTagHelpers.ResponsiveUtilities {
    using Microsoft.AspNet.Razor.Runtime.TagHelpers;

    [TargetElement("HiddenMd")]
    public class HiddenMdTagHelper:BootstrapTagHelper {

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "div";
            output.AddCssClass("hidden-md");
        }
    }
}