using BootstrapTagHelpers.Extensions;
using Microsoft.AspNet.Razor.TagHelpers;

namespace BootstrapTagHelpers.Forms {
    [OutputElementHint("span")]
    public class HelpBlockTagHelper:BootstrapTagHelper {
        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "span";
            output.AddCssClass("help-block");
        }

        public static string GenerateHelpBlock(string helpContent) {
            return "<span class=\"help-block\">" + helpContent + "</span>";
        }
    }
}