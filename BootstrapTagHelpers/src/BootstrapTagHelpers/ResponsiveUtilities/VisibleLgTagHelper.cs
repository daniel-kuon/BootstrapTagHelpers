using Microsoft.AspNet.Razor.TagHelpers;

namespace BootstrapTagHelpers.ResponsiveUtilities {
    [HtmlTargetElement("VisibleLg")]
    public class VisibleLgTagHelper:BootstrapTagHelper {
        public const string DisplayModeAttributeName = "display-mode";

        [HtmlAttributeName(DisplayModeAttributeName)]
        public BootstrapResponsiveUtilitiesDisplayMode DisplayMode { get; set; }=BootstrapResponsiveUtilitiesDisplayMode.Block;

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = this.DisplayMode==BootstrapResponsiveUtilitiesDisplayMode.Inline?"span":"div";
            output.AddCssClass("visible-lg-" + this.DisplayMode.GetDescription());
        }
    }
}