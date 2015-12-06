namespace BootstrapTagHelpers {
    using Microsoft.AspNet.Razor.TagHelpers;

    [OutputElementHint("span")]
    public class BLabelTagHelper : BootstrapTagHelper {
        public BLabelContext Context { get; set; }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "span";
            output.AddCssClass("label");
            output.AddCssClass("label-" + Context.ToString().ToLower());
        }
    }
}