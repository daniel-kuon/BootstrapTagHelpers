namespace BootstrapTagHelpers {
    using Microsoft.AspNet.Razor.TagHelpers;

    [RestrictChildren(ProgressBarTagHelper.ProgressBarTagName)]
    public class ProgressTagHelper : BootstrapTagHelper {
        public const string DisplayValueAttributeName = AttributePrefix + "display-value";
        public const string StripedAttributeName = AttributePrefix + "striped";
        public const string AnimatedAttributeName = AttributePrefix + "animated";
        public const string SrTextAttributeName = AttributePrefix + "sr-text";

        [HtmlAttributeName(DisplayValueAttributeName)]
        [HtmlAttributeNotBound]
        [HtmlAttributeMinimizable]
        public bool? DisplayValue { get; set; }

        [HtmlAttributeName(StripedAttributeName)]
        [HtmlAttributeNotBound]
        [HtmlAttributeMinimizable]
        public bool? Striped { get; set; }

        [HtmlAttributeName(AnimatedAttributeName)]
        [HtmlAttributeNotBound]
        [HtmlAttributeMinimizable]
        public bool? Animated { get; set; }

        [HtmlAttributeName(SrTextAttributeName)]
        public string SrText { get; set; }


        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            DisplayValue = DisplayValue;
            Striped = Striped;
            Animated = Animated;

            context.Items.Add("ProgressContext", this);
            output.TagName = "div";
            output.Attributes.RemoveAll(DisplayValueAttributeName, SrTextAttributeName, AnimatedAttributeName,
                                        StripedAttributeName);
            output.AddCssClass("progress");
        }
    }
}