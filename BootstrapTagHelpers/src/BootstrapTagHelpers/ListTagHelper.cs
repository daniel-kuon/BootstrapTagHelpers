namespace BootstrapTagHelpers {
    using Microsoft.AspNet.Razor.TagHelpers;

    [HtmlTargetElement("ul", Attributes = UnstyledAttributeName)]
    [HtmlTargetElement("ul", Attributes = InlineAttributeName)]
    [HtmlTargetElement("ol", Attributes = UnstyledAttributeName)]
    [HtmlTargetElement("ol", Attributes = InlineAttributeName)]
    public class ListTagHelper : BootstrapTagHelper {
        public const string InlineAttributeName = AttributePrefix + "inline";
        public const string UnstyledAttributeName = AttributePrefix + "unstyled";

        [HtmlAttributeName(UnstyledAttributeName)]
        [HtmlAttributeNotBound]
        [HtmlAttributeMinimizable]
        public bool Unstyled { get; set; }

        [HtmlAttributeName(InlineAttributeName)]
        [HtmlAttributeNotBound]
        [HtmlAttributeMinimizable]
        public bool Inline { get; set; }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            if (Unstyled)
                output.AddCssClass("list-unstyled");
            if (Inline)
                output.AddCssClass("list-inline");
        }
    }
}