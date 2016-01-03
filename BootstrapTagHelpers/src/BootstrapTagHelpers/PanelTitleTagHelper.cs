using BootstrapTagHelpers.Extensions;
using Microsoft.AspNet.Razor.TagHelpers;

namespace BootstrapTagHelpers {
    [HtmlTargetElement("h1", ParentTag = "footer")]
    [HtmlTargetElement("h2", ParentTag = "footer")]
    [HtmlTargetElement("h3", ParentTag = "footer")]
    [HtmlTargetElement("h4", ParentTag = "footer")]
    [HtmlTargetElement("h5", ParentTag = "footer")]
    [HtmlTargetElement("h6", ParentTag = "footer")]
    [HtmlTargetElement("h1", ParentTag = "heading")]
    [HtmlTargetElement("h2", ParentTag = "heading")]
    [HtmlTargetElement("h3", ParentTag = "heading")]
    [HtmlTargetElement("h4", ParentTag = "heading")]
    [HtmlTargetElement("h5", ParentTag = "heading")]
    [HtmlTargetElement("h6", ParentTag = "heading")]
    public class PanelTitleTagHelper:BootstrapTagHelper {

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.AddCssClass("panel-title");
        }
    }
}