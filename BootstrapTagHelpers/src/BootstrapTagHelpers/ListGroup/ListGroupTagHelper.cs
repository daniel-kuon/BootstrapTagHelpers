using System.Threading.Tasks;

using BootstrapTagHelpers.Attributes;
using BootstrapTagHelpers.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BootstrapTagHelpers.ListGroup {
    [OutputElementHint("ul")]
    [RestrictChildren("a", "list-group-item", "list-group-button")]
    [ContextClass]
    public class ListGroupTagHelper : BootstrapTagHelper {
        public ListGroupContext? Context { get; set; }

        [HtmlAttributeNotBound]
        public bool RenderAsDiv { get; set; }

        [HtmlAttributeNotBound]
        public bool ChildDetectionMode { get; set; }

        protected override async Task BootstrapProcessAsync(TagHelperContext context, TagHelperOutput output) {
            ChildDetectionMode = true;
            await output.GetChildContentAsync();
            ChildDetectionMode = false;
            output.TagName = RenderAsDiv ? "div" : "ul";
            output.AddCssClass("list-group");
            await output.GetChildContentAsync(false);
        }
    }
}