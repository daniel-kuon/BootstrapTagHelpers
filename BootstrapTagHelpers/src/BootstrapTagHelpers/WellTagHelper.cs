using BootstrapTagHelpers.Extensions;
using BootstrapTagHelpers.Forms;
using Microsoft.AspNet.Razor.TagHelpers;

namespace BootstrapTagHelpers {
    [OutputElementHint("div")]
    public class WellTagHelper:BootstrapTagHelper {
        public SimpleSize Size { get; set; }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "div";
            output.AddCssClass("well");
            if (Size!=SimpleSize.Default)
                output.AddCssClass("well-" + Size.GetDescription());
        }
    }
}