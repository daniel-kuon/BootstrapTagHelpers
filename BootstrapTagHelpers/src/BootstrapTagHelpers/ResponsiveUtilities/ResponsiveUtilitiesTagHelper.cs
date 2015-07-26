namespace BootstrapTagHelpers.ResponsiveUtilities {

    using Microsoft.AspNet.Razor.Runtime.TagHelpers;

    [TargetElement("*",Attributes = HiddenXsAttributeName)]
    [TargetElement("*",Attributes = HiddenSmAttributeName)]
    [TargetElement("*",Attributes = HiddenMdAttributeName)]
    [TargetElement("*",Attributes = HiddenLgAttributeName)]
    [TargetElement("*",Attributes = HiddenPrintAttributeName)]
    [TargetElement("*", Attributes = VisibleXsAttributeName)]
    [TargetElement("*",Attributes = VisibleSmAttributeName)]
    [TargetElement("*",Attributes = VisibleMdAttributeName)]
    [TargetElement("*",Attributes = VisibleLgAttributeName)]
    [TargetElement("*",Attributes = VisiblePrintAttributeName)]
    [TargetElement("*",Attributes = SrOnlyAttributeName)]
    public class ResponsiveUtilitiesTagHelper : BootstrapTagHelper
    {
        public const string HiddenXsAttributeName = AttributePrefix + "hidden-xs";
        public const string HiddenSmAttributeName = AttributePrefix + "hidden-sm";
        public const string HiddenMdAttributeName = AttributePrefix + "hidden-md";
        public const string HiddenLgAttributeName = AttributePrefix + "hidden-lg";
        public const string HiddenPrintAttributeName = AttributePrefix + "hidden-print";
        public const string VisibleXsAttributeName = AttributePrefix + "visible-xs";
        public const string VisibleSmAttributeName = AttributePrefix + "visible-sm";
        public const string VisibleMdAttributeName = AttributePrefix + "visible-md";
        public const string VisibleLgAttributeName = AttributePrefix + "visible-lg";
        public const string VisiblePrintAttributeName = AttributePrefix + "visible-print";
        public const string SrOnlyAttributeName = AttributePrefix + "sr-only";

        [HtmlAttributeName(HiddenXsAttributeName)]
        public bool HiddenXs { get; set; }

        [HtmlAttributeName(HiddenSmAttributeName)]
        public bool HiddenSm { get; set; }

        [HtmlAttributeName(HiddenMdAttributeName)]
        public bool HiddenMd { get; set; }

        [HtmlAttributeName(HiddenLgAttributeName)]
        public bool HiddenLg { get; set; }

        [HtmlAttributeName(HiddenPrintAttributeName)]
        public bool HiddenPrint { get; set; }

        [HtmlAttributeName(SrOnlyAttributeName)]
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

        [HtmlAttributeName(VisibleXsAttributeName)]
        public BootstrapResponsiveUtilitiesDisplayMode? VisibleXs { get; set; }
        [HtmlAttributeName(VisibleSmAttributeName)]
        public BootstrapResponsiveUtilitiesDisplayMode? VisibleSm { get; set; }
        [HtmlAttributeName(VisibleMdAttributeName)]
        public BootstrapResponsiveUtilitiesDisplayMode? VisibleMd { get; set; }
        [HtmlAttributeName(VisibleLgAttributeName)]
        public BootstrapResponsiveUtilitiesDisplayMode? VisibleLg { get; set; }
        [HtmlAttributeName(VisiblePrintAttributeName)]
        public BootstrapResponsiveUtilitiesDisplayMode? VisiblePrint { get; set; }
    }

}