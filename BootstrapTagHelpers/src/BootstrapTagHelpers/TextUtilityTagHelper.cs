namespace BootstrapTagHelpers {
    using System.ComponentModel;

    using Microsoft.AspNet.Razor.Runtime.TagHelpers;


    [TargetElement("*", Attributes = AttributePrefix + "text-alignment")]
    [TargetElement("*", Attributes = AttributePrefix + "text-transformation")]
    public class TextUtilityTagHelper:BootstrapTagHelper {

        [HtmlAttributeName(AttributePrefix+"text-alignment")]
        public BootstrapTextAlignmentMode? TextAlignment { get; set; }

        [HtmlAttributeName(AttributePrefix + "text-transformation")]
        public BootstrapTextTransformationMode? TextTransformation { get; set; }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            if (TextAlignment.HasValue)
                output.AddCssClass("text-" + TextAlignment.Value);
            if (TextTransformation.HasValue)
                output.AddCssClass("text-" + TextTransformation.Value);
        }
    }

}