using Microsoft.AspNet.Razor.TagHelpers;

namespace BootstrapTagHelpers {
    [HtmlTargetElement("dl",Attributes = HorizonzalAttributeName)]
    public class DlTagHelper:BootstrapTagHelper {
        private const string HorizonzalAttributeName = AttributePrefix + "horizontal";

        [HtmlAttributeName(HorizonzalAttributeName)]
        public bool Horizontal { get; set; }

        
        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            if (context.IsSet(() => Horizontal))
                output.AddCssClass("dl-horizontal");
        }
    }

}