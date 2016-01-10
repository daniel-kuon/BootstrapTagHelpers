using BootstrapTagHelpers.Extensions;
using Microsoft.AspNet.Razor.TagHelpers;

namespace BootstrapTagHelpers.Panel {
    [OutputElementHint("div")]
    [HtmlTargetElement("panel-body", ParentTag = "panel")]
    public class PanelBodyTagHelper:BootstrapTagHelper {
        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.AddCssClass("panel-body");
        }
    }
}