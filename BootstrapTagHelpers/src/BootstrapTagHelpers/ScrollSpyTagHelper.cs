namespace BootstrapTagHelpers {
    using BootstrapTagHelpers.Extensions;

    using Microsoft.AspNet.Razor.TagHelpers;

    [HtmlTargetElement("*", Attributes = ScrollSpayTargetAttributeName)]
    public class ScrollSpyTagHelper : BootstrapTagHelper {
        private const string ScrollSpyPrefix = AttributePrefix + "scroll-spy-";
        public const string ScrollSpayTargetAttributeName = ScrollSpyPrefix + "target";

        [HtmlAttributeName(ScrollSpayTargetAttributeName)]
        [CopyToOutput("data-target")]
        public string ScrollSpyTarget { get; set; }

        [HtmlAttributeName(ScrollSpyPrefix + "offset")]
        [CopyToOutput("data-offset")]
        public string Offset { get; set; }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.Attributes.AddDataAttribute("spy", "scroll");
        }
    }
}