using Microsoft.AspNet.Razor.TagHelpers;

namespace BootstrapTagHelpers.ListGroup {
    [HtmlTargetElement("a", ParentTag = "list-group")]
    public class ListGroupLinkTagHelper : ListGroupItemTagHelper {

        public string Href { get; set; }


        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            if (ListGroupContext.ChildDetectionMode) {
                ListGroupContext.RenderAsDiv = true;
                output.SuppressOutput();
            }
            else
                RenderOutput(output);
        }

        protected override void RenderOutput(TagHelperOutput output) {
            base.RenderOutput(output);
            output.Attributes.Add(Disabled? "data-href":"href",Href);
        }

        protected override string GetTagName() {
            return "a";
        }
    }
}