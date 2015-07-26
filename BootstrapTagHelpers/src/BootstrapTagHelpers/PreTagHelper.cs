namespace BootstrapTagHelpers {
    using Microsoft.AspNet.Razor.Runtime.TagHelpers;

    [TargetElement("pre",Attributes = ScrollableAttributeName)]
    public class PreTagHelper :BootstrapTagHelper{
        public const string ScrollableAttributeName = AttributePrefix+"scrollable";

        [HtmlAttributeName(ScrollableAttributeName)]
        public bool Scrollable { get; set; }

        
        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            if (context.IsSet(()=>Scrollable))
                output.AddCssClass("pre-scrollable");
        }
    }
}