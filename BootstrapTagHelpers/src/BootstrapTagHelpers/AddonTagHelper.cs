namespace BootstrapTagHelpers {
    using Microsoft.AspNet.Razor.TagHelpers;

    [HtmlTargetElement("addon", ParentTag = "input-group")]
    [OutputElementHint("span")]
    public class AddonTagHelper : BootstrapTagHelper {
        public static string GenerateAddon(string text) {
            return $"<span class=\"input-group-addon\">{text}</span>";
        }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "span";
            output.AddCssClass("input-group-addon");
        }
    }
}