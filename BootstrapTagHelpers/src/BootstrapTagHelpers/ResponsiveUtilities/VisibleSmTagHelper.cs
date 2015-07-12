namespace BootstrapTagHelpers.ResponsiveUtilities {
    using Microsoft.AspNet.Razor.Runtime.TagHelpers;

    [TargetElement("VisibleSm")]
    public class VisibleSmTagHelper:BootstrapTagHelper {

        [HtmlAttributeName("display-mode")]
        public BootstrapResponsiveUtilitiesDisplayMode DisplayMode { get; set; }=BootstrapResponsiveUtilitiesDisplayMode.Block;

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = this.DisplayMode==BootstrapResponsiveUtilitiesDisplayMode.Inline?"span":"div";
            output.AddCssClass("visible-sm-" + this.DisplayMode.GetDescription());
        }
    }
}