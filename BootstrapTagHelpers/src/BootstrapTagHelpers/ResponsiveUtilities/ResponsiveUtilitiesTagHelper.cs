namespace BootstrapTagHelpers.ResponsiveUtilities {

    using Microsoft.AspNet.Razor.Runtime.TagHelpers;

    [TargetElement("*",Attributes = AttributePrefix + "hidden-xs")]
    [TargetElement("*",Attributes = AttributePrefix + "hidden-sm")]
    [TargetElement("*",Attributes = AttributePrefix + "hidden-md")]
    [TargetElement("*",Attributes = AttributePrefix + "hidden-lg")]
    [TargetElement("*",Attributes = AttributePrefix + "hidden-print")]
    [TargetElement("*", Attributes = AttributePrefix + "visible-xs")]
    [TargetElement("*",Attributes = AttributePrefix + "visible-sm")]
    [TargetElement("*",Attributes = AttributePrefix + "visible-md")]
    [TargetElement("*",Attributes = AttributePrefix + "visible-lg")]
    [TargetElement("*",Attributes = AttributePrefix + "visible-print")]
    [TargetElement("*",Attributes = AttributePrefix + "sr-only")]
    public class ResponsiveUtilitiesTagHelper : BootstrapTagHelper
    {
        [HtmlAttributeName(AttributePrefix + "hidden-xs")]
        public bool HiddenXs { get; set; }

        [HtmlAttributeName(AttributePrefix + "hidden-sm")]
        public bool HiddenSm { get; set; }

        [HtmlAttributeName(AttributePrefix + "hidden-md")]
        public bool HiddenMd { get; set; }

        [HtmlAttributeName(AttributePrefix + "hidden-lg")]
        public bool HiddenLg { get; set; }

        [HtmlAttributeName(AttributePrefix + "hidden-print")]
        public bool HiddenPrint { get; set; }

        [HtmlAttributeName(AttributePrefix + "sr-only")]
        public bool SrOnly { get; set; }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            if (this.IsSet(()=> this.HiddenXs, context))
                output.AddCssClass("hidden-xs");
            if (this.IsSet(()=> this.HiddenSm, context))
                output.AddCssClass("hidden-sm");
            if (this.IsSet(()=> this.HiddenMd, context))
                output.AddCssClass("hidden-md");
            if (this.IsSet(()=> this.HiddenLg, context))
                output.AddCssClass("hidden-lg");
            if (this.IsSet(()=> this.HiddenPrint, context))
                output.AddCssClass("hidden-print");
            if (this.IsSet(()=> this.SrOnly, context))
                output.AddCssClass("sr-only");
            if (this.VisibleXs != null)
                output.AddCssClass("visible-xs-" + this.VisibleXs.Value.GetDescription());
            if (this.VisibleSm != null)
                output.AddCssClass("visible-sm-" + this.VisibleSm.Value.GetDescription());
            if (this.VisibleMd != null)
                output.AddCssClass("visible-md-" + this.VisibleMd.Value.GetDescription());
            if (this.VisibleLg != null)
                output.AddCssClass("visible-lg-" + this.VisibleLg.Value.GetDescription());
            if (this.VisiblePrint != null)
                output.AddCssClass("visible-print-" + this.VisiblePrint.Value.GetDescription());
        }

        [HtmlAttributeName(AttributePrefix + "visible-xs")]
        public BootstrapResponsiveUtilitiesDisplayMode? VisibleXs { get; set; }
        [HtmlAttributeName(AttributePrefix + "visible-sm")]
        public BootstrapResponsiveUtilitiesDisplayMode? VisibleSm { get; set; }
        [HtmlAttributeName(AttributePrefix + "visible-md")]
        public BootstrapResponsiveUtilitiesDisplayMode? VisibleMd { get; set; }
        [HtmlAttributeName(AttributePrefix + "visible-lg")]
        public BootstrapResponsiveUtilitiesDisplayMode? VisibleLg { get; set; }
        [HtmlAttributeName(AttributePrefix + "visible-print")]
        public BootstrapResponsiveUtilitiesDisplayMode? VisiblePrint { get; set; }
    }

}