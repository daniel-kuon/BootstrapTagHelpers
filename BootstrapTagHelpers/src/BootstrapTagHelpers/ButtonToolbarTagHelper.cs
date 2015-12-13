namespace BootstrapTagHelpers {
    using Microsoft.AspNet.Razor.TagHelpers;

    [RestrictChildren("button", "a", "dropdown","button-group")]
    [OutputElementHint("div")]
    public class ButtonToolbarTagHelper : BootstrapTagHelper {

        public Size? Size { get; set; }
        public ButtonContext? Context { get; set; }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            context.SetButtonToolbarContext(this);
            output.TagName = "div";
            output.Attributes.Add("role","toolbar");
            output.AddCssClass("btn-toolbar");
        }
    }
}