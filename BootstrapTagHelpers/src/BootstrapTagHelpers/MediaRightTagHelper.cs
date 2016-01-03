using Microsoft.AspNet.Razor.TagHelpers;

namespace BootstrapTagHelpers {
    [OutputElementHint("img")]
    [HtmlTargetElement("media-right", TagStructure = TagStructure.WithoutEndTag)]
    public class MediaRightTagHelper : MediaLeftTagHelper {
        protected string CssClass => "media-right";
    }
}