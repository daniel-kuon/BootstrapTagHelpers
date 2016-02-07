using BootstrapTagHelpers.Extensions;
using Microsoft.AspNet.Razor.TagHelpers;

namespace BootstrapTagHelpers
{
    [HtmlTargetElement("*", Attributes = AffixAttributeName)]
    public class AffixExtenderTagHelper : BootstrapTagHelper
    {
        public const string AffixAttributeName = AttributePrefix + "affix";

        [HtmlAttributeName(AffixAttributeName)]
        [HtmlAttributeMinimizable]
        [HtmlAttributeNotBound]
        public bool IsAffix { get; set; }

        [HtmlAttributeName(AttributePrefix + "affix-offset-bottom")]
        [CopyToOutput("data-offset-bottom")]
        public int? OffsetBottom { get; set; }

        [HtmlAttributeName(AttributePrefix + "affix-offset-top")]
        [CopyToOutput("data-offset-bottom")]
        public int? OffsetTop { get; set; }

        [HtmlAttributeName(AttributePrefix + "affix-offset")]
        [CopyToOutput("data-offset-bottom")]
        [CopyToOutput("data-offset-top")]
        public int? Offset { get; set; }

        [HtmlAttributeName(AttributePrefix + "affix-target")]
        [CopyToOutput("data-target")]
        public string Target { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (IsAffix)
                base.Process(context, output);
        }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.AddDataAttribute("spy", "affix");
        }
    }
}