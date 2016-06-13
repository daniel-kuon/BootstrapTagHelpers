using BootstrapTagHelpers.Extensions;

namespace BootstrapTagHelpers {
    using Microsoft.AspNetCore.Razor.TagHelpers;

    [HtmlTargetElement("divider", ParentTag = "dropdown")]
    [OutputElementHint("li")]
    public class DropdownDividerTagHelper : BootstrapTagHelper {
        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "li";
            output.AddCssClass("divider");
            output.Attributes.Add("role", "seperator");
            output.TagMode = TagMode.StartTagAndEndTag;
        }
    }
}