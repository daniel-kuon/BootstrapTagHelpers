namespace BootstrapTagHelpers.Navigation {
    using BootstrapTagHelpers.Extensions;

    using Microsoft.AspNet.Razor.TagHelpers;

    [OutputElementHint("ul")]
    [RestrictChildren("nav-item","dropdown")]
    public class NavbarNavTagHelper:BootstrapTagHelper {

        public override void Init(TagHelperContext context) {
            base.Init(context);
            context.SetNavContext(this);
        }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "ul";
            output.AddCssClass("nav");
            output.AddCssClass("navbar-nav");
        }
    }
}