using BootstrapTagHelpers.Extensions;
using Microsoft.AspNet.Razor.TagHelpers;

namespace BootstrapTagHelpers.ListGroup {
    [HtmlTargetElement("h1", ParentTag = "a")]
    [HtmlTargetElement("h2", ParentTag = "a")]
    [HtmlTargetElement("h3", ParentTag = "a")]
    [HtmlTargetElement("h4", ParentTag = "a")]
    [HtmlTargetElement("h5", ParentTag = "a")]
    [HtmlTargetElement("h6", ParentTag = "a")]
    [HtmlTargetElement("h1", ParentTag = "list-group-button")]
    [HtmlTargetElement("h2", ParentTag = "list-group-button")]
    [HtmlTargetElement("h3", ParentTag = "list-group-button")]
    [HtmlTargetElement("h4", ParentTag = "list-group-button")]
    [HtmlTargetElement("h5", ParentTag = "list-group-button")]
    [HtmlTargetElement("h6", ParentTag = "list-group-button")]
    [HtmlTargetElement("h1", ParentTag = "list-group-item")]
    [HtmlTargetElement("h2", ParentTag = "list-group-item")]
    [HtmlTargetElement("h3", ParentTag = "list-group-item")]
    [HtmlTargetElement("h4", ParentTag = "list-group-item")]
    [HtmlTargetElement("h5", ParentTag = "list-group-item")]
    [HtmlTargetElement("h6", ParentTag = "list-group-item")]
    public class ListGroupHeadingTagHelper : BootstrapTagHelper {
        public override void Process(TagHelperContext context, TagHelperOutput output) {
            if (context.HasContextItem<ListGroupTagHelper>())
                base.Process(context, output);
        }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.AddCssClass("list-group-item-heading");
        }
    }
}