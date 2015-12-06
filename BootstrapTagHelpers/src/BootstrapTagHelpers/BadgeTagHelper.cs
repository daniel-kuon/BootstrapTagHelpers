namespace BootstrapTagHelpers {
    using Microsoft.AspNet.Razor.TagHelpers;

    [OutputElementHint("span")]
    public class BadgeTagHelper : BootstrapTagHelper {
        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "span";
            output.AddCssClass("badge");
        }
    }
}