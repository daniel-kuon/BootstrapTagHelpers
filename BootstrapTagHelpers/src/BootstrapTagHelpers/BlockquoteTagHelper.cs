namespace BootstrapTagHelpers {
    using Microsoft.AspNet.Razor.Runtime.TagHelpers;

    [TargetElement("blockquote",Attributes = AttributePrefix + "reverse")]
    public class BlockquoteTagHelper:BootstrapTagHelper
    {
        [HtmlAttributeName(AttributePrefix+"reverse")]
        public bool Reverse { get; set; }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            if (context.IsSet(()=>Reverse))
                output.AddCssClass("blockquote-reverse");
        }
    }

}