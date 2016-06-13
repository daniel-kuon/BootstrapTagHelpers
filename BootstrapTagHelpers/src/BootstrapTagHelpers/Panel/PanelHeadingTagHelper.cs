using BootstrapTagHelpers.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BootstrapTagHelpers.Panel {
    [OutputElementHint("div")]
    [HtmlTargetElement("heading", ParentTag = "panel")]
    public class PanelHeadingTagHelper : BootstrapTagHelper {
        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "div";
            output.AddCssClass("panel-heading");
        }
    }
}