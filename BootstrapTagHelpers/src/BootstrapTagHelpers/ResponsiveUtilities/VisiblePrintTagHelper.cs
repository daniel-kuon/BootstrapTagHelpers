namespace BootstrapTagHelpers.ResponsiveUtilities {
    using Microsoft.AspNet.Razor.Runtime.TagHelpers;

    [TargetElement("VisiblePrint")]
    public class VisiblePrintTagHelper:BootstrapTagHelper {

        [HtmlAttributeName("display-mode")]
        public BootstrapResponsiveUtilitiesDisplayMode DisplayMode { get; set; }=BootstrapResponsiveUtilitiesDisplayMode.Block;

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = this.DisplayMode==BootstrapResponsiveUtilitiesDisplayMode.Inline?"span":"div";
            output.AddCssClass("visible-print-" + this.DisplayMode.GetDescription());
        }
    }
}