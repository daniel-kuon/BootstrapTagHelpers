using BootstrapTagHelpers.Extensions;

namespace BootstrapTagHelpers {
    using Microsoft.AspNet.Razor.TagHelpers;

    [HtmlTargetElement("header", ParentTag = "dropdown")]
    [OutputElementHint("li")]
    public class DropdownHeaderTagHelper : BootstrapTagHelper {
        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "li";
            output.AddCssClass("dropdown-header");
        }
    }
}