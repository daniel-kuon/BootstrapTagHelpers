namespace BootstrapTagHelpers {

    using Microsoft.AspNet.Razor.Runtime.TagHelpers;

    [TargetElement("ul",Attributes = UnstyledAttributeName)]
    [TargetElement("ul",Attributes = InlineAttributeName)]
    [TargetElement("ol",Attributes = UnstyledAttributeName)]
    [TargetElement("ol",Attributes = InlineAttributeName)]
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