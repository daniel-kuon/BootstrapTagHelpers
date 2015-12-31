using BootstrapTagHelpers.Extensions;
using Microsoft.AspNet.Razor.TagHelpers;

namespace BootstrapTagHelpers {
    [OutputElementHint("li")]
    [HtmlTargetElement("nav-item", ParentTag = "nav-tabs")]
    [HtmlTargetElement("nav-item", ParentTag = "nav-pills")]
    public class NavItemTagHelper : BootstrapTagHelper {
        public string Href { get; set; }

        [HtmlAttributeMinimizable]
        [HtmlAttributeNotBound]
        public bool Active { get; set; }

        [HtmlAttributeMinimizable]
        [HtmlAttributeNotBound]
        public bool Disabled { get; set; }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "li";
            output.Attributes.Add("role", "presentation");
            if (Disabled) {
                output.AddCssClass("disabled");
                output.PreContent.PrependHtml($"<a data-href=\"{Href}\">");
            }
            else
                output.PreContent.PrependHtml($"<a href=\"{Href}\">");
            output.PostContent.AppendHtml("</a>");
            if (Active)
                output.AddCssClass("active");
        }
    }
}