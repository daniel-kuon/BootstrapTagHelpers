using BootstrapTagHelpers.Extensions;
using Microsoft.AspNet.Razor.TagHelpers;

namespace BootstrapTagHelpers
{
    using BootstrapTagHelpers.Attributes;

    [OutputElementHint("div")]
    public class AffixTagHelper : BootstrapTagHelper
    {
        [CopyToOutput(Prefix = "data-")]
        public int? OffsetBottom { get; set; }


        [CopyToOutput(Prefix = "data-")]
        public int? OffsetTop { get; set; }

        [CopyToOutput("data-offset-bottom")]
        [CopyToOutput("data-offset-top")]
        public int? Offset { get; set; }

        [CopyToOutput(Prefix = "data-")]
        public string Target { get; set; }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.AddDataAttribute("spy", "affix");
        }
    }
}