using Microsoft.AspNet.Razor.TagHelpers;

namespace BootstrapTagHelpers {
    [HtmlTargetElement("blockquote",Attributes = ReverseAttributeName)]
    public class BlockquoteTagHelper:BootstrapTagHelper
    {
        public const string ReverseAttributeName = AttributePrefix + "reverse";

        [HtmlAttributeName(ReverseAttributeName)]
        public bool Reverse { get; set; }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            if (context.IsSet(()=>Reverse))
                output.AddCssClass("blockquote-reverse");
        }
    }

}