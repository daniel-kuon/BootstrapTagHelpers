namespace BootstrapTagHelpers.Forms {
    using BootstrapTagHelpers.Attributes;
    using BootstrapTagHelpers.Extensions;
    using BootstrapTagHelpers.Navigation;

    using Microsoft.AspNet.Razor.TagHelpers;

    [RestrictChildren("button", "a", "dropdown")]
    [OutputElementHint("div")]
    [ContextClass]
    public class ButtonGroupTagHelper : BootstrapTagHelper {
        [Context]
        protected ButtonToolbarTagHelper ButtonToolbarContext { get; set; }

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
            if (ButtonToolbarContext!=null) {
                Vertical = false;
                Justified = false;
                if (!Size.HasValue)
                    Size = ButtonToolbarContext.Size;
                if (!Context.HasValue)
                    Context = ButtonToolbarContext.Context;
            }
        }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.Attributes.Add("role", "group");
            if (context.HasContextItem<InputGroupTagHelper>()) {
                Size = BootstrapTagHelpers.Size.Default;
                if (!context.HasContextItem<AddonTagHelper>()) {
                    output.TagName = "span";
                    output.AddCssClass("input-group-btn");
                }
                context.RemoveContextItem<InputGroupTagHelper>();
            } else {
                output.TagName = "div";
                if (this.Vertical)
                    output.AddCssClass("btn-group-vertical");
                else
                    output.AddCssClass("btn-group");
                if (this.Size.HasValue)
                    output.AddCssClass("btn-group-" + this.Size.Value.GetDescription());
                if (this.Justified)
                    output.AddCssClass("btn-group-justified");
            }
        }
    }
}