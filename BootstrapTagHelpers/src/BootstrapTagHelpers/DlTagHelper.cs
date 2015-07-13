namespace BootstrapTagHelpers {
    using Microsoft.AspNet.Razor.Runtime.TagHelpers;

    [TargetElement("dl",Attributes = AttributePrefix +"horizontal")]
    public class DlTagHelper:BootstrapTagHelper {
        [HtmlAttributeName(AttributePrefix+"horizontal")]
        public bool Horizontal { get; set; }

        
        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            if (context.IsSet(() => Horizontal))
                output.AddCssClass("dl-horizontal");
        }
    }

}