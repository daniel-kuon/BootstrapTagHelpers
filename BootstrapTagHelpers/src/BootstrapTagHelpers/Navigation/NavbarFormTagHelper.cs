namespace BootstrapTagHelpers.Navigation {
    using BootstrapTagHelpers.Extensions;

    using Microsoft.AspNet.Razor.TagHelpers;

    [HtmlTargetElement("form",ParentTag = "navbar")]
    public class NavbarFormTagHelper:BootstrapTagHelper {

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.AddCssClass("navbar-form");
        }

    }
}