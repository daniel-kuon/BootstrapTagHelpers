namespace BootstrapTagHelpers {
    using BootstrapTagHelpers.Attributes;
    using BootstrapTagHelpers.Extensions;

    using Microsoft.AspNet.Razor.TagHelpers;

    [HtmlTargetElement("*", Attributes = TitleAttributeName)]
    [HtmlTargetElement("*", Attributes = ContentAttributeName)]
    public class PopoverTagHelper : BootstrapTagHelper {
        private const string PopoverPrefix = AttributePrefix + "popover-";
        public const string TitleAttributeName = PopoverPrefix + "title";
        public const string ContentAttributeName = PopoverPrefix + "content";

        [HtmlAttributeName(TitleAttributeName)]
        [CopyToOutput("title")]
        public string Title { get; set; }

        [HtmlAttributeName(ContentAttributeName)]
        [CopyToOutput("data-content")]
        public string Content { get; set; }

        [HtmlAttributeMinimizable]
        [HtmlAttributeNotBound]
        [HtmlAttributeName(PopoverPrefix + "dissmissable")]
        public bool Dismissable { get; set; }

        [HtmlAttributeName(PopoverPrefix + "placement")]
        public Placement? Placement { get; set; }

        [HtmlAttributeName(PopoverPrefix + "animation")]
        [CopyToOutput("data-animation")]
        public bool Animation { get; set; }

        [HtmlAttributeName(PopoverPrefix + "container")]
        [CopyToOutput("data-container")]
        public string Container { get; set; }

        [HtmlAttributeName(PopoverPrefix + "delay")]
        [CopyToOutput("data-delay")]
        public int Delay { get; set; }

        [HtmlAttributeName(PopoverPrefix + "html")]
        [CopyToOutput("data-html")]
        public bool Html { get; set; }

        [HtmlAttributeName(PopoverPrefix + "selector")]
        [CopyToOutput("data-selector")]
        public string Selector { get; set; }

        [HtmlAttributeName(PopoverPrefix + "template")]
        [CopyToOutput("data-template")]
        public string Template { get; set; }

        [HtmlAttributeName(PopoverPrefix + "trigger")]
        [CopyToOutput("data-trigger")]
        public string Trigger { get; set; }

        [HtmlAttributeName(PopoverPrefix + "viewport")]
        [CopyToOutput("data-viewport")]
        public string Viewport { get; set; }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.Attributes.AddDataAttribute("toggle", "popover");
            if (this.Dismissable)
                output.Attributes.AddDataAttribute("trigger", "focus");
            if (this.Placement != null)
                output.Attributes.AddDataAttribute("placement", this.Placement.Value.ToString().ToLower());
        }
    }
}