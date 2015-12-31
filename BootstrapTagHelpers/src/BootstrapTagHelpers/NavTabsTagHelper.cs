using BootstrapTagHelpers.Extensions;
using Microsoft.AspNet.Razor.TagHelpers;

namespace BootstrapTagHelpers {
    [OutputElementHint("ul")]
    [RestrictChildren("nav-item", "dropdown")]
    public class NavTabsTagHelper : BootstrapTagHelper {
        [HtmlAttributeMinimizable]
        [HtmlAttributeNotBound]
        public bool Justified { get; set; }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "ul";
            output.AddCssClass("nav");
            output.AddCssClass("nav-tabs");
            if (Justified)
                output.AddCssClass("nav-justified");
            context.SetNavContext(this);
        }
    }
}