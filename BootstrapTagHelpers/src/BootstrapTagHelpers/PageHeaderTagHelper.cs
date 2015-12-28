using BootstrapTagHelpers.Extensions;

namespace BootstrapTagHelpers {
    using Microsoft.AspNet.Razor.TagHelpers;

    [OutputElementHint("div")]
    public class PageHeaderTagHelper : BootstrapTagHelper {
        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "div";
            output.AddCssClass("page-header");
        }
    }
}