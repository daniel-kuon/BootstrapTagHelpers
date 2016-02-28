using BootstrapTagHelpers.Extensions;
using Microsoft.AspNet.Razor.TagHelpers;

namespace BootstrapTagHelpers.Media {
    [OutputElementHint("div")]
    [RestrictChildren("media-left", "media-right", "media-body")]
    public class MediaTagHelper : BootstrapTagHelper {
        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            if (context.HasContextItem<MediaListTagHelper>()) {
                output.TagName = "li";
                context.RemoveContextItem<MediaListTagHelper>();
            }
            else
                output.TagName = "div";
            output.AddCssClass("media");
        }
    }
}