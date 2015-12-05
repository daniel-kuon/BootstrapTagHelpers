using Microsoft.AspNet.Razor.TagHelpers;

namespace BootstrapTagHelpers.Grid {
    public class RowTagHelper : BootstrapTagHelper
    {
        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes["class"]= "row";
        }
    }
}