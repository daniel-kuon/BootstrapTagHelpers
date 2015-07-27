namespace BootstrapTagHelpers {
    using Microsoft.AspNet.Razor.Runtime.TagHelpers;

    [TargetElement("img", Attributes = ResponsiveAttributeName)]
    [TargetElement("img", Attributes = CircleAttributeName)]
    [TargetElement("img", Attributes = ThumbnailAttributeName)]
    [TargetElement("img", Attributes = RoundedAttributeName)]
    public class ImgTagHelper : BootstrapTagHelper {
        public const string RoundedAttributeName = AttributePrefix + "rounded";
        public const string CircleAttributeName = AttributePrefix + "circle";
        public const string ThumbnailAttributeName = AttributePrefix + "thumbnail";
        public const string ResponsiveAttributeName = AttributePrefix + "responsive";

        [HtmlAttributeName(RoundedAttributeName)]
        public bool Rounded { get; set; }

        [HtmlAttributeName(CircleAttributeName)]
        public bool Circle { get; set; }

        [HtmlAttributeName(ThumbnailAttributeName)]
        public bool Thumbnail { get; set; }

        [HtmlAttributeName(ResponsiveAttributeName)]
        public bool Responsive { get; set; }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            if (context.IsSet(() => this.Rounded))
                output.AddCssClass("img-rounded");
            if (context.IsSet(() => this.Circle))
                output.AddCssClass("img-circle");
            if (context.IsSet(() => this.Thumbnail))
                output.AddCssClass("img-thumbnail");
            if (context.IsSet(() => this.Responsive))
                output.AddCssClass("img-responsive");
        }
    }
}