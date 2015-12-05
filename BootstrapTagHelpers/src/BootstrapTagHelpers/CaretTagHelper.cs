using Microsoft.AspNet.Razor.TagHelpers;

namespace BootstrapTagHelpers {
    public class CaretTagHelper : BootstrapTagHelper {
        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "span";
            output.AddCssClass("caret");
            output.TagMode=TagMode.StartTagAndEndTag;
        }
    }

}