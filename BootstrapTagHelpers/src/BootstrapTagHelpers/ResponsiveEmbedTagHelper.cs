using BootstrapTagHelpers.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BootstrapTagHelpers {
    [OutputElementHint("div")]
    public class ResponsiveEmbedTagHelper:BootstrapTagHelper {

        public ResponsiveEmbedFormat? Format { get; set; }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            if (Format == null)
                Format = Configuration.ResponsiveEmbedFormat;
            output.TagName = "div";
            output.AddCssClass("embed-responsive");
            output.AddCssClass("embed-responsive-" + Format.Value.GetDescription());
        }
    }
}