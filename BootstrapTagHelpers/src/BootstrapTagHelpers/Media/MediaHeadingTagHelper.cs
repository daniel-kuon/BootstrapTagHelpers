using BootstrapTagHelpers.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BootstrapTagHelpers.Media {
    [HtmlTargetElement("h1", ParentTag = "media")]
    [HtmlTargetElement("h2", ParentTag = "media")]
    [HtmlTargetElement("h3", ParentTag = "media")]
    [HtmlTargetElement("h4", ParentTag = "media")]
    [HtmlTargetElement("h5", ParentTag = "media")]
    [HtmlTargetElement("h6", ParentTag = "media")]
    public class MediaHeadingTagHelper : BootstrapTagHelper {
        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.AddCssClass("media-heading");
        }
    }
}