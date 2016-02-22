namespace BootstrapTagHelpers.Navigation {
    using BootstrapTagHelpers.Attributes;
    using BootstrapTagHelpers.Extensions;

    using Microsoft.AspNet.Razor.TagHelpers;

    [HtmlTargetElement("*", Attributes = NavbarRightAttributename, ParentTag = "navbar")]
    [HtmlTargetElement("*", Attributes = NavbarLeftAttributename, ParentTag = "navbar")]
    public class NavbarAlignmentTagHelper : BootstrapTagHelper {

        public const string NavbarRightAttributename = AttributePrefix + "navbar-right";
        public const string NavbarLeftAttributename = AttributePrefix + "navbar-left";

        [HtmlAttributeName(NavbarLeftAttributename)]
        [HtmlAttributeMinimizable]
        [HtmlAttributeNotBound]
        public bool Left { get; set; }

        [HtmlAttributeName(NavbarRightAttributename)]
        [HtmlAttributeMinimizable]
        [HtmlAttributeNotBound]
        public bool Right { get; set; }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            if (Right)
                output.AddCssClass("navbar-right");
            if (Left)
                output.AddCssClass("navbar-left");
        }
    }
}