namespace BootstrapTagHelpers.Navigation {
    using BootstrapTagHelpers.Extensions;

    using Microsoft.AspNet.Razor.TagHelpers;

    [HtmlTargetElement("a", Attributes = NavbarLinkAttributeName)]
    public class NavbarLinkTagHelper : BootstrapTagHelper {
        public const string NavbarLinkAttributeName = AttributePrefix + "navbar-link";

        [HtmlAttributeName(NavbarLinkAttributeName)]
        [HtmlAttributeNotBound]
        [HtmlAttributeMinimizable]
        public bool NavbarLink { get; set; }


        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.AddCssClass("navbar-link");
        }
    }
}