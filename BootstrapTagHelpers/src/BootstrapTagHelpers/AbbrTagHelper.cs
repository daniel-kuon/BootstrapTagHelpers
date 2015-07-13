namespace BootstrapTagHelpers {
    using Microsoft.AspNet.Razor.Runtime.TagHelpers;

    [TargetElement("abbr",Attributes = AttributePrefix + "initialism")]
    public class AbbrTagHelper:BootstrapTagHelper {

        [HtmlAttributeName(AttributePrefix + "initialism")]
        public bool Initialism { get; set; }


        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            if (context.IsSet(()=>Initialism))
                output.AddCssClass("initialism");
        }
    }

}