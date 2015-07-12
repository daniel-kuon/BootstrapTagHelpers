namespace BootstrapTagHelpers.ResponsiveUtilities {
    using Microsoft.AspNet.Razor.Runtime.TagHelpers;

    
    [TargetElement("SrOnly")]
public class SrOnlyTagHelper:BootstrapTagHelper {

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "div";
            output.AddCssClass("sr-only");
        }
    }

    [TargetElement("HiddenXs")]
public class HiddenXsTagHelper:BootstrapTagHelper {

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "div";
            output.AddCssClass("hidden-xs");
        }
    }

    [TargetElement("HiddenSm")]
public class HiddenSmTagHelper:BootstrapTagHelper {

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "div";
            output.AddCssClass("hidden-sm");
        }
    }

    [TargetElement("HiddenMd")]
public class HiddenMdTagHelper:BootstrapTagHelper {

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "div";
            output.AddCssClass("hidden-md");
        }
    }

    [TargetElement("HiddenLg")]
public class HiddenLgTagHelper:BootstrapTagHelper {

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "div";
            output.AddCssClass("hidden-lg");
        }
    }

    [TargetElement("HiddenPrint")]
public class HiddenPrintTagHelper:BootstrapTagHelper {

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "div";
            output.AddCssClass("hidden-print");
        }
    }

    [TargetElement("VisibleXs")]
public class VisibleXsTagHelper:BootstrapTagHelper {

        [HtmlAttributeName("display-mode")]
        public BootstrapResponsiveUtilitiesDisplayMode DisplayMode { get; set; }=BootstrapResponsiveUtilitiesDisplayMode.Block;

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = DisplayMode==BootstrapResponsiveUtilitiesDisplayMode.Inline?"span":"div";
            output.AddCssClass("visible-xs-" + DisplayMode.GetDescription());
        }
    }

    [TargetElement("VisibleSm")]
public class VisibleSmTagHelper:BootstrapTagHelper {

        [HtmlAttributeName("display-mode")]
        public BootstrapResponsiveUtilitiesDisplayMode DisplayMode { get; set; }=BootstrapResponsiveUtilitiesDisplayMode.Block;

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = DisplayMode==BootstrapResponsiveUtilitiesDisplayMode.Inline?"span":"div";
            output.AddCssClass("visible-sm-" + DisplayMode.GetDescription());
        }
    }

    [TargetElement("VisibleMd")]
public class VisibleMdTagHelper:BootstrapTagHelper {

        [HtmlAttributeName("display-mode")]
        public BootstrapResponsiveUtilitiesDisplayMode DisplayMode { get; set; }=BootstrapResponsiveUtilitiesDisplayMode.Block;

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = DisplayMode==BootstrapResponsiveUtilitiesDisplayMode.Inline?"span":"div";
            output.AddCssClass("visible-md-" + DisplayMode.GetDescription());
        }
    }

    [TargetElement("VisibleLg")]
public class VisibleLgTagHelper:BootstrapTagHelper {

        [HtmlAttributeName("display-mode")]
        public BootstrapResponsiveUtilitiesDisplayMode DisplayMode { get; set; }=BootstrapResponsiveUtilitiesDisplayMode.Block;

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = DisplayMode==BootstrapResponsiveUtilitiesDisplayMode.Inline?"span":"div";
            output.AddCssClass("visible-lg-" + DisplayMode.GetDescription());
        }
    }

    [TargetElement("VisiblePrint")]
public class VisiblePrintTagHelper:BootstrapTagHelper {

        [HtmlAttributeName("display-mode")]
        public BootstrapResponsiveUtilitiesDisplayMode DisplayMode { get; set; }=BootstrapResponsiveUtilitiesDisplayMode.Block;

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = DisplayMode==BootstrapResponsiveUtilitiesDisplayMode.Inline?"span":"div";
            output.AddCssClass("visible-print-" + DisplayMode.GetDescription());
        }
    }
}