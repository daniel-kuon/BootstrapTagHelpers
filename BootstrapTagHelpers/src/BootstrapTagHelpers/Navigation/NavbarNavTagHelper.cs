using BootstrapTagHelpers.Attributes;

namespace BootstrapTagHelpers.Navigation {
    using BootstrapTagHelpers.Extensions;

    using Microsoft.AspNet.Razor.TagHelpers;

    [OutputElementHint("ul")]
    [RestrictChildren("nav-item","dropdown")]
    [ContextClass]
    public class NavbarNavTagHelper:BootstrapTagHelper {

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "ul";
            output.AddCssClass("nav");
            output.AddCssClass("navbar-nav");
        }
    }
}