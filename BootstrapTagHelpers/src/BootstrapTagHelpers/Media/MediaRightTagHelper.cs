using Microsoft.AspNet.Razor.TagHelpers;

namespace BootstrapTagHelpers.Media {
    [OutputElementHint("img")]
    [HtmlTargetElement("media-right", TagStructure = TagStructure.WithoutEndTag)]
    public class MediaRightTagHelper : MediaLeftTagHelper {
        protected override string CssClass => "media-right";
    }
}