namespace BootstrapTagHelpers {
    using BootstrapTagHelpers.Attributes;
    using BootstrapTagHelpers.Extensions;

    using Microsoft.AspNet.Razor.TagHelpers;

    [HtmlTargetElement("*", Attributes = TooltipTextAttributeName)]
    public class ToolTipTagHelper : BootstrapTagHelper {

        public const string TooltipTextAttributeName = AttributePrefix + "tooltip";
        public const string ToolTipAttributePrefix = TooltipTextAttributeName + "-";

        [HtmlAttributeName(ToolTipAttributePrefix + "animation")]
        [CopyToOutput("data-animation")]
        public string Animation { get; set; }

        [HtmlAttributeName(ToolTipAttributePrefix + "container")]
        [CopyToOutput("data-container")]
        public string Container { get; set; }

        [HtmlAttributeName(ToolTipAttributePrefix + "delay")]
        [CopyToOutput("data-delay")]
        public string Delay { get; set; }

        [HtmlAttributeName(ToolTipAttributePrefix + "html")]
        [CopyToOutput("data-html")]
        public string Html { get; set; }

        [HtmlAttributeName(ToolTipAttributePrefix + "placement")]
        [CopyToOutput("data-placement")]
        public string placement { get; set; }

        [HtmlAttributeName(ToolTipAttributePrefix + "selector")]
        [CopyToOutput("data-selector")]
        public string Selector { get; set; }

        [HtmlAttributeName(ToolTipAttributePrefix + "template")]
        [CopyToOutput("data-template")]
        public string Template { get; set; }

        [HtmlAttributeName(TooltipTextAttributeName)]
        [CopyToOutput("title")]
        public string Tooltip { get; set; }

        [HtmlAttributeName(ToolTipAttributePrefix + "trigger")]
        [CopyToOutput("data-trigger")]
        public string Trigger { get; set; }

        [HtmlAttributeName(ToolTipAttributePrefix + "viewport")]
        [CopyToOutput("data-viewport")]
        public string Viewport { get; set; }

        [HtmlAttributeName(AttributePrefix + "tooltip-placement")]
        public Placement? Placement { get; set; }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.Attributes.AddDataAttribute("toggle", "tooltip");
            if (Placement != null)
                output.Attributes.AddDataAttribute("placement", Placement.ToString().ToLower());
        }
    }

}