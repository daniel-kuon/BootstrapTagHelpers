using BootstrapTagHelpers.Extensions;
using Microsoft.AspNet.Razor.TagHelpers;

namespace BootstrapTagHelpers.Forms {
    using BootstrapTagHelpers.Attributes;

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
            output.Attributes.Add("role", "group");
            if (context.HasInputGroupContext())
            {
                Size = BootstrapTagHelpers.Size.Default;
                if (!context.HasInputGroupAddonContext())
                {
                    output.TagName = "span";
                    output.AddCssClass("input-group-btn");
                }
                context.RemoveInputGroupContext();
            }
            else {
                output.TagName = "div";
                if (Vertical)
                    output.AddCssClass("btn-group-vertical");
                else
                    output.AddCssClass("btn-group");
                if (Size.HasValue)
                    output.AddCssClass("btn-group-" + Size.Value.GetDescription());
                if (Justified)
                    output.AddCssClass("btn-group-justified");
            }
        }
    }
}