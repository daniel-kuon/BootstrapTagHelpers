using BootstrapTagHelpers.Extensions;
using Microsoft.AspNet.Razor.TagHelpers;

namespace BootstrapTagHelpers {
    [OutputElementHint("img")]
    [HtmlTargetElement("media-left", TagStructure = TagStructure.WithoutEndTag)]
    public class MediaLeftTagHelper : BootstrapTagHelper {
        public string Href { get; set; }

        public VerticalAlignment Alignment { get; set; }

        protected string CssClass => "media-left";

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "img";
            string cssClass = CssClass;
            if (Alignment != VerticalAlignment.Top)
                cssClass += " media-" + Alignment.ToString().ToLower();
            output.PreElement.AppendHtml($"<div class=\"{cssClass}\">");
            if (!string.IsNullOrEmpty(Href)) {
                output.PreElement.AppendHtml($"<a href=\"{Href}\">");
                output.PostElement.AppendHtml("</a>");
            }
            output.PostElement.AppendHtml("</div>");
            output.AddCssClass("media-object");
        }
    }
}