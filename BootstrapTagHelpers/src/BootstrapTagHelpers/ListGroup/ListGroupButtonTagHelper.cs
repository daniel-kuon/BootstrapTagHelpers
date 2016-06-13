using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BootstrapTagHelpers.ListGroup {
    [HtmlTargetElement("list-group-button", ParentTag = "list-group")]
    [OutputElementHint("button")]
    public class ListGroupButtonTagHelper : ListGroupItemTagHelper {
        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            if (ListGroupContext.ChildDetectionMode) {
                ListGroupContext.RenderAsDiv = true;
                output.SuppressOutput();
            }
            else
                RenderOutput(output);
        }

        protected override string GetTagName() {
            return "button";
        }
    }
}