using Microsoft.AspNet.Razor.TagHelpers;

namespace BootstrapTagHelpers.ResponsiveUtilities {
    [HtmlTargetElement("VisibleSm")]
    public class VisibleSmTagHelper:BootstrapTagHelper {

        [HtmlAttributeName(VisibleLgTagHelper.DisplayModeAttributeName)]
        public BootstrapResponsiveUtilitiesDisplayMode DisplayMode { get; set; }=BootstrapResponsiveUtilitiesDisplayMode.Block;

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = this.DisplayMode==BootstrapResponsiveUtilitiesDisplayMode.Inline?"span":"div";
            output.AddCssClass("visible-sm-" + this.DisplayMode.GetDescription());
        }
    }
}