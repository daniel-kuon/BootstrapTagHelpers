using BootstrapTagHelpers.Extensions;

namespace BootstrapTagHelpers {
    using Microsoft.AspNet.Razor.TagHelpers;

    [OutputElementHint("span")]
    [HtmlTargetElement("glyphicon", Attributes = "icon")]
    public class GlyphiconTagHelper : BootstrapTagHelper {
        public Glyphicons Icon { get; set; }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "span";
            output.AddCssClass("glyphicon");
            output.AddCssClass(Icon.GetDescription());
        }
    }
}