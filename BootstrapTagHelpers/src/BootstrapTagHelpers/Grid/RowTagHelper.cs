namespace BootstrapTagHelpers.Grid {
    using Microsoft.AspNet.Razor.Runtime.TagHelpers;

    public class RowTagHelper : BootstrapTagHelper
    {
        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes["class"]= "row";
        }
    }
}