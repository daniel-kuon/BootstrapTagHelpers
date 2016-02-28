using BootstrapTagHelpers.Extensions;
using Microsoft.AspNet.Razor.TagHelpers;

namespace BootstrapTagHelpers.ListGroup {
    [HtmlTargetElement("p", ParentTag = "a")]
    [HtmlTargetElement("span", ParentTag = "a")]
    [HtmlTargetElement("p", ParentTag = "list-group-button")]
    [HtmlTargetElement("span", ParentTag = "list-group-button")]
    [HtmlTargetElement("p", ParentTag = "list-group-item")]
    [HtmlTargetElement("span", ParentTag = "list-group-item")]
    public class ListGroupTextTagHelper : BootstrapTagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context.HasContextItem<ListGroupTagHelper>())
                base.Process(context, output);
        }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.AddCssClass("list-group-item-text");
        }
    }
}