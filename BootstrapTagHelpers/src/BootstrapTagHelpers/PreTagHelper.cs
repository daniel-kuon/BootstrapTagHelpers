namespace BootstrapTagHelpers {
    using Microsoft.AspNet.Razor.Runtime.TagHelpers;

    [TargetElement("pre",Attributes = AttributePrefix+"scrollable")]
    public class PreTagHelper :BootstrapTagHelper{

        [HtmlAttributeName(AttributePrefix+"scrollable")]
        public bool Scrollable { get; set; }

        
        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            if (context.IsSet(()=>Scrollable))
                output.AddCssClass("pre-scrollable");
        }
    }
}