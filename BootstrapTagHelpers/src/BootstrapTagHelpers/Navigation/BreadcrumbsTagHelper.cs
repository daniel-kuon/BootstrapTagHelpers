using BootstrapTagHelpers.Extensions;
using Microsoft.AspNet.Razor.TagHelpers;

namespace BootstrapTagHelpers.Navigation {
    [OutputElementHint("ol")]
    [RestrictChildren("breadcrumb")]
    public class BreadcrumbsTagHelper : BootstrapTagHelper {
        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "ol";
            output.AddCssClass("breadcrumb");
        }
    }
}