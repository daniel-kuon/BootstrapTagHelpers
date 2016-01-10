using BootstrapTagHelpers.Extensions;
using Microsoft.AspNet.Razor.TagHelpers;

namespace BootstrapTagHelpers.Panel {
    [OutputElementHint("div")]
    [HtmlTargetElement("footer", ParentTag = "panel")]
    public class PanelFooterTagHelper:BootstrapTagHelper {
        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.AddCssClass("panel-footer");
        }
    }
}