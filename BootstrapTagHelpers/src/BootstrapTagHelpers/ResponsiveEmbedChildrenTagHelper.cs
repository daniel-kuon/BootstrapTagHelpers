using BootstrapTagHelpers.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BootstrapTagHelpers {
    [HtmlTargetElement(ParentTag ="responsive-embed")]
    public class ResponsiveEmbedChildrenTagHelper:BootstrapTagHelper {
        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.AddCssClass("embed-responsive-item");
        }
    }
}