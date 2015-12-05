using Microsoft.AspNet.Razor.TagHelpers;

namespace BootstrapTagHelpers {
    [HtmlTargetElement("*", Attributes = TextAlignmentAttributeName)]
    [HtmlTargetElement("*", Attributes = TextTransformationAttributeName)]
    public class TextUtilityTagHelper:BootstrapTagHelper {
        public const string TextAlignmentAttributeName = AttributePrefix + "text-alignment";
        public const string TextTransformationAttributeName = AttributePrefix + "text-transformation";

        [HtmlAttributeName(TextAlignmentAttributeName)]
        public BootstrapTextAlignmentMode? TextAlignment { get; set; }

        [HtmlAttributeName(TextTransformationAttributeName)]
        public BootstrapTextTransformationMode? TextTransformation { get; set; }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            if (TextAlignment.HasValue)
                output.AddCssClass("text-" + TextAlignment.Value);
            if (TextTransformation.HasValue)
                output.AddCssClass("text-" + TextTransformation.Value);
        }
    }

}