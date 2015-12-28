using BootstrapTagHelpers.Extensions;

namespace BootstrapTagHelpers.ResponsiveUtilities {
    using Microsoft.AspNet.Razor.TagHelpers;

    [OutputElementHint("div")]
    public class VisibleLgTagHelper : BootstrapTagHelper {
        public const string DisplayModeAttributeName = "display-mode";

        [HtmlAttributeName(DisplayModeAttributeName)]
        public BootstrapResponsiveUtilitiesDisplayMode DisplayMode { get; set; } =
            BootstrapResponsiveUtilitiesDisplayMode.Block;

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = DisplayMode == BootstrapResponsiveUtilitiesDisplayMode.Inline ? "span" : "div";
            output.AddCssClass("visible-lg-" + DisplayMode.GetDescription());
        }
    }
}