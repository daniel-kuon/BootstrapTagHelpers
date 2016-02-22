using BootstrapTagHelpers.Extensions;
using Microsoft.AspNet.Razor.TagHelpers;

namespace BootstrapTagHelpers {
    using BootstrapTagHelpers.Attributes;

    [OutputElementHint("ul")]
    [RestrictChildren("nav-item","dropdown")]
    public class NavPillsTagHelper : BootstrapTagHelper {
        [HtmlAttributeMinimizable]
        [HtmlAttributeNotBound]
        public bool Justified { get; set; }

        [HtmlAttributeNotBound]
        [HtmlAttributeMinimizable]
        public bool Stacked { get; set; }


        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "ul";
            output.AddCssClass("nav");
            output.AddCssClass("nav-pills");
            if (Justified)
                output.AddCssClass("nav-justified");
            if (Stacked)
                output.AddCssClass("nav-stacked");
            context.SetNavContext(this);
        }
    }
}