namespace BootstrapTagHelpers {
    using Microsoft.AspNet.Razor.TagHelpers;

    [RestrictChildren("button", "a", "dropdown")]
    [OutputElementHint("div")]
    public class ButtonGroupTagHelper : BootstrapTagHelper {
        public Size? Size { get; set; }
        public ButtonContext? Context { get; set; }
        [HtmlAttributeMinimizable]
        [HtmlAttributeNotBound]
        public bool Vertical { get; set; }

        [HtmlAttributeMinimizable]
        [HtmlAttributeNotBound]
        public bool Justified { get; set; }

        public override void Init(TagHelperContext context) {
            base.Init(context);
            if (context.HasButtonToolbarContext()) {
                ButtonToolbarTagHelper buttonToolbarContext = context.GetButtonToolbarContext();
                Vertical = false;
                Justified = false;
                if (!Size.HasValue)
                    Size = buttonToolbarContext.Size;
                if (!Context.HasValue)
                    Context = buttonToolbarContext.Context;
            }
        }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            context.SetButtonGroupContext(this);
            output.TagName = "div";
            if (Vertical)
                output.AddCssClass("btn-group-vertical");
            else
                output.AddCssClass("btn-group");
            output.Attributes.Add("role", "group");
            if (Size.HasValue)
                output.AddCssClass("btn-group-" + Size.Value.GetDescription());
            if (Justified)
                output.AddCssClass("btn-group-justified");
        }
    }
}