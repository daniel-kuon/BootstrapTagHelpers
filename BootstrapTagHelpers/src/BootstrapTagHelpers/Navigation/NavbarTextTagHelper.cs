namespace BootstrapTagHelpers.Navigation {

    using BootstrapTagHelpers.Attributes;
    using BootstrapTagHelpers.Extensions;

    using Microsoft.AspNet.Razor.TagHelpers;

    [HtmlTargetElement("p", ParentTag = "navbar")]
    [HtmlTargetElement("*", ParentTag = "navbar", Attributes = NavbarTextAttributeName)]
    public class NavbarTextTagHelper : BootstrapTagHelper {
        private const string NavbarTextAttributeName = AttributePrefix + "navbar-text";

        [HtmlAttributeMinimizable]
        [HtmlAttributeNotBound]
        [HtmlAttributeName(NavbarTextAttributeName)]
        public bool NavbarText { get; set; }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.AddCssClass("navbar-text");
        }
    }

}