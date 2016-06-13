using BootstrapTagHelpers.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BootstrapTagHelpers.Text {
    using BootstrapTagHelpers.Attributes;

    [HtmlTargetElement("blockquote", Attributes = ReverseAttributeName)]
    public class BlockquoteTagHelper : BootstrapTagHelper {
        public const string ReverseAttributeName = AttributePrefix + "reverse";

        [HtmlAttributeName(ReverseAttributeName)]
        [HtmlAttributeNotBound]
        [HtmlAttributeMinimizable]
        public bool Reverse { get; set; }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            if (Reverse)
                output.AddCssClass("blockquote-reverse");
        }
    }
}