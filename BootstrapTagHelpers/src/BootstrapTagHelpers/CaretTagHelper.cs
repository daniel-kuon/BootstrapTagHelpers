namespace BootstrapTagHelpers {
    using Microsoft.AspNet.Razor.Runtime.TagHelpers;

    public class CaretTagHelper : BootstrapTagHelper {
        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "span";
            output.AddCssClass("caret");
            output.SelfClosing = false;
        }
    }

}