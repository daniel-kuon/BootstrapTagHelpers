namespace BootstrapTagHelpers {
    using Microsoft.AspNet.Razor.TagHelpers;

    [HtmlTargetElement("a", Attributes = ButtonAttributeName)]
    [HtmlTargetElement("input", Attributes = TypeAttributeName)]
    [HtmlTargetElement("button")]
    public class ButtonTagHelper : BootstrapTagHelper {
        public const string TypeAttributeName = "type";
        public const string ButtonAttributeName = AttributePrefix + "button";
        public const string ContextAttributeName = AttributePrefix + "context";
        public const string SizeAttributeName = AttributePrefix + "size";
        public const string BlockStyleAttrbibuteName = AttributePrefix + "block-style";
        public const string PressesAttributeName = AttributePrefix + "pressed";
        public const string DisabledAttributeName = "disabled";

        [HtmlAttributeName(TypeAttributeName)]
        public string Type { get; set; }

        [HtmlAttributeName(ButtonAttributeName)]
        [HtmlAttributeNotBound]
        [HtmlAttributeMinimizable]
        public bool Button { get; set; }

        [HtmlAttributeName(ContextAttributeName)]
        public ButtonContext Context { get; set; }

        [HtmlAttributeName(SizeAttributeName)]
        public Size Size { get; set; }

        [HtmlAttributeName(BlockStyleAttrbibuteName)]
        [HtmlAttributeNotBound]
        [HtmlAttributeMinimizable]
        public bool BlockStyle { get; set; }

        [HtmlAttributeName(PressesAttributeName)]
        [HtmlAttributeNotBound]
        [HtmlAttributeMinimizable]
        public bool Pressed { get; set; }

        [HtmlAttributeName(DisabledAttributeName)]
        [HtmlAttributeNotBound]
        [HtmlAttributeMinimizable]
        public bool Disabled { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output) {
            Type = Type?.ToLower() ?? "";
            output.TagName = output.TagName.ToLower();
            if (Button || output.TagName == "button" ||
                output.TagName == "input" && (Type == "button" || Type == "submit" || Type == "reset"))
                base.Process(context, output);
        }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.AddCssClass("btn");
            output.AddCssClass("btn-" + Context.ToString().ToLower());
            if (Size != Size.Default)
                output.AddCssClass("btn-" + Size.ToString().ToLower());
            if (BlockStyle)
                output.AddCssClass("btn-block");
            if (Pressed) {
                output.AddAriaAttribute("pressed", "true");
                output.AddCssClass("active");
            }
            if (Disabled) {
                if (output.TagName == "a")
                    output.AddCssClass("disabled");
                output.MergeAttribute("role", "button");
            }
        }
    }
}