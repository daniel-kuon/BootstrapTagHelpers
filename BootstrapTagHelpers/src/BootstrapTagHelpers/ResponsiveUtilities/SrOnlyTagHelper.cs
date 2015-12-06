namespace BootstrapTagHelpers.ResponsiveUtilities {
    using Microsoft.AspNet.Razor.TagHelpers;

    [HtmlTargetElement("SrOnly")]
    public class SrOnlyTagHelper : BootstrapTagHelper {
        private const string FocusableAttributeName = AttributePrefix + "focusable";

        [HtmlAttributeName(FocusableAttributeName)]
        [HtmlAttributeNotBound]
        [HtmlAttributeMinimizable]
        public bool Focusable { get; set; }


        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "div";
            output.AddCssClass("sr-only");
            if (Focusable)
                output.AddCssClass("sr-only-focusable");
        }
    }
}