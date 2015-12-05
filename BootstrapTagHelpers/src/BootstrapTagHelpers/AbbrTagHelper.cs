using Microsoft.AspNet.Razor.TagHelpers;

namespace BootstrapTagHelpers {
    [HtmlTargetElement("abbr",Attributes = InitialismAttributeName)]
    public class AbbrTagHelper:BootstrapTagHelper {
        public const string InitialismAttributeName = AttributePrefix + "initialism";

        [HtmlAttributeName(InitialismAttributeName)]
        public bool Initialism { get; set; }


        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            if (context.IsSet(()=>Initialism))
                output.AddCssClass("initialism");
        }
    }

}