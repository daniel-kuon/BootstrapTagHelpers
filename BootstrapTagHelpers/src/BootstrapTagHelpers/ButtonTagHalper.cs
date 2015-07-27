namespace BootstrapTagHelpers {
    using Microsoft.AspNet.Razor.Runtime.TagHelpers;

    [TargetElement("a", Attributes = ButtonAttributeName)]
    [TargetElement("input", Attributes = TypeAttributeName)]
    [TargetElement("button")]
    public class ButtonTagHalper : BootstrapTagHelper {
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
        public bool Button { get; set; }

        [HtmlAttributeName(ContextAttributeName)]
        public ButtonContext Context { get; set; }

        [HtmlAttributeName(SizeAttributeName)]
        public Size Size { get; set; }

        [HtmlAttributeName(BlockStyleAttrbibuteName)]
        public bool BlockStyle { get; set; }

        [HtmlAttributeName(PressesAttributeName)]
        public bool Pressed { get; set; }

        [HtmlAttributeName(DisabledAttributeName)]
        public bool Disabled { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output) {
            this.Type = this.Type?.ToLower() ?? "";
            output.TagName = output.TagName.ToLower();
            if (context.IsSet(() => this.Button) || output.TagName == "button" || output.TagName == "input" && (this.Type == "button" || this.Type == "submit" || this.Type == "reset"))
                base.Process(context, output);
        }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.AddCssClass("btn");
            output.AddCssClass("btn-" + this.Context.ToString().ToLower());
            if (this.Size!=Size.Default)
                output.AddCssClass("btn-" + this.Size.ToString().ToLower());
            if (context.IsSet(()=>this.BlockStyle))
                output.AddCssClass("btn-block");
            if (context.IsSet(() => this.Pressed)) {
                output.AddAriaAttribute("pressed", "true");
                output.AddCssClass("active");
            }
            if (context.IsSet(()=>this.Disabled)) {
                if (output.TagName=="a")
                    output.AddCssClass("disabled");
                output.MergeAttribute("role","button");
            }
        }
    }
}