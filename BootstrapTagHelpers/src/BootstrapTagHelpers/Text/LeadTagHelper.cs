using BootstrapTagHelpers.Extensions;
using Microsoft.AspNet.Razor.TagHelpers;

namespace BootstrapTagHelpers.Text {
    [OutputElementHint("p")]
    public class LeadTagHelper : BootstrapTagHelper {

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "p";
            output.AddCssClass("lead");
        }
    }
}