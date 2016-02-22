using BootstrapTagHelpers.Extensions;

namespace BootstrapTagHelpers.ResponsiveUtilities {
    using BootstrapTagHelpers.Attributes;

    using Microsoft.AspNet.Razor.TagHelpers;

    [HtmlTargetElement("*", Attributes = HiddenXsAttributeName)]
    [HtmlTargetElement("*", Attributes = HiddenSmAttributeName)]
    [HtmlTargetElement("*", Attributes = HiddenMdAttributeName)]
    [HtmlTargetElement("*", Attributes = HiddenLgAttributeName)]
    [HtmlTargetElement("*", Attributes = HiddenPrintAttributeName)]
    [HtmlTargetElement("*", Attributes = VisibleXsAttributeName)]
    [HtmlTargetElement("*", Attributes = VisibleSmAttributeName)]
    [HtmlTargetElement("*", Attributes = VisibleMdAttributeName)]
    [HtmlTargetElement("*", Attributes = VisibleLgAttributeName)]
    [HtmlTargetElement("*", Attributes = VisiblePrintAttributeName)]
    [HtmlTargetElement("*", Attributes = SrOnlyAttributeName)]
    [HtmlTargetElement("*", Attributes = SrOnlyFocusableAttributeName)]
    [OutputElementHint("div")]
    public class ResponsiveUtilitiesTagHelper : BootstrapTagHelper {
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
        public const string SrOnlyFocusableAttributeName = AttributePrefix + "sr-only-focusable";

        [HtmlAttributeName(HiddenXsAttributeName)]
        [HtmlAttributeNotBound]
        [HtmlAttributeMinimizable]
        public bool HiddenXs { get; set; }

        [HtmlAttributeName(HiddenSmAttributeName)]
        [HtmlAttributeNotBound]
        [HtmlAttributeMinimizable]
        public bool HiddenSm { get; set; }

        [HtmlAttributeName(HiddenMdAttributeName)]
        [HtmlAttributeNotBound]
        [HtmlAttributeMinimizable]
        public bool HiddenMd { get; set; }

        [HtmlAttributeName(HiddenLgAttributeName)]
        [HtmlAttributeNotBound]
        [HtmlAttributeMinimizable]
        public bool HiddenLg { get; set; }

        [HtmlAttributeName(HiddenPrintAttributeName)]
        [HtmlAttributeNotBound]
        [HtmlAttributeMinimizable]
        public bool HiddenPrint { get; set; }

        [HtmlAttributeName(SrOnlyAttributeName)]
        [HtmlAttributeNotBound]
        [HtmlAttributeMinimizable]
        public bool SrOnly { get; set; }

        [HtmlAttributeName(SrOnlyFocusableAttributeName)]
        [HtmlAttributeNotBound]
        [HtmlAttributeMinimizable]
        public bool SrOnlyFocusable { get; set; }

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

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            if (HiddenXs)
                output.AddCssClass("hidden-xs");
            if (HiddenSm)
                output.AddCssClass("hidden-sm");
            if (HiddenMd)
                output.AddCssClass("hidden-md");
            if (HiddenLg)
                output.AddCssClass("hidden-lg");
            if (HiddenPrint)
                output.AddCssClass("hidden-print");
            if (SrOnly || SrOnlyFocusable)
                output.AddCssClass("sr-only");
            if (SrOnlyFocusable)
                output.AddCssClass("sr-only-focusable");
            if (VisibleXs != null)
                output.AddCssClass("visible-xs-" + VisibleXs.Value.GetDescription());
            if (VisibleSm != null)
                output.AddCssClass("visible-sm-" + VisibleSm.Value.GetDescription());
            if (VisibleMd != null)
                output.AddCssClass("visible-md-" + VisibleMd.Value.GetDescription());
            if (VisibleLg != null)
                output.AddCssClass("visible-lg-" + VisibleLg.Value.GetDescription());
            if (VisiblePrint != null)
                output.AddCssClass("visible-print-" + VisiblePrint.Value.GetDescription());
        }
    }
}