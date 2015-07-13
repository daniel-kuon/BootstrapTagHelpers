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
            if (context.IsSet(()=> this.HiddenXs))
                output.AddCssClass("hidden-xs");
            if (context.IsSet(()=> this.HiddenSm))
                output.AddCssClass("hidden-sm");
            if (context.IsSet(()=> this.HiddenMd))
                output.AddCssClass("hidden-md");
            if (context.IsSet(()=> this.HiddenLg))
                output.AddCssClass("hidden-lg");
            if (context.IsSet(()=> this.HiddenPrint))
                output.AddCssClass("hidden-print");
            if (context.IsSet(()=> this.SrOnly))
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