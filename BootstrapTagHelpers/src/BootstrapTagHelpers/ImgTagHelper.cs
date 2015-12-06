namespace BootstrapTagHelpers {
    using Microsoft.AspNet.Razor.TagHelpers;

    [HtmlTargetElement("img", Attributes = ResponsiveAttributeName)]
    [HtmlTargetElement("img", Attributes = CircleAttributeName)]
    [HtmlTargetElement("img", Attributes = ThumbnailAttributeName)]
    [HtmlTargetElement("img", Attributes = RoundedAttributeName)]
    public class ImgTagHelper : BootstrapTagHelper {
        public const string RoundedAttributeName = AttributePrefix + "rounded";
        public const string CircleAttributeName = AttributePrefix + "circle";
        public const string ThumbnailAttributeName = AttributePrefix + "thumbnail";
        public const string ResponsiveAttributeName = AttributePrefix + "responsive";

        [HtmlAttributeName(RoundedAttributeName)]
        [HtmlAttributeNotBound]
        [HtmlAttributeMinimizable]
        public bool Rounded { get; set; }

        [HtmlAttributeName(CircleAttributeName)]
        [HtmlAttributeNotBound]
        [HtmlAttributeMinimizable]
        public bool Circle { get; set; }

        [HtmlAttributeName(ThumbnailAttributeName)]
        [HtmlAttributeNotBound]
        [HtmlAttributeMinimizable]
        public bool Thumbnail { get; set; }

        [HtmlAttributeName(ResponsiveAttributeName)]
        [HtmlAttributeNotBound]
        [HtmlAttributeMinimizable]
        public bool Responsive { get; set; }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            if (Rounded)
                output.AddCssClass("img-rounded");
            if (Circle)
                output.AddCssClass("img-circle");
            if (Thumbnail)
                output.AddCssClass("img-thumbnail");
            if (Responsive)
                output.AddCssClass("img-responsive");
        }
    }
}