using Microsoft.AspNet.Razor.TagHelpers;

namespace BootstrapTagHelpers {
    [HtmlTargetElement("ul",Attributes = UnstyledAttributeName)]
    [HtmlTargetElement("ul",Attributes = InlineAttributeName)]
    [HtmlTargetElement("ol",Attributes = UnstyledAttributeName)]
    [HtmlTargetElement("ol",Attributes = InlineAttributeName)]
    public class ListTagHelper:BootstrapTagHelper {
        public const string InlineAttributeName = AttributePrefix + "inline";
        public const string UnstyledAttributeName = AttributePrefix + "unstyled";

        [HtmlAttributeName(UnstyledAttributeName)]
        public bool Unstyled { get; set; }

        [HtmlAttributeName(InlineAttributeName)]
        public bool Inline { get; set; }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            if (context.IsSet(()=>Unstyled))
                output.AddCssClass("list-unstyled");
            if (context.IsSet(()=>Inline))
                output.AddCssClass("list-inline");
        }
    }

}