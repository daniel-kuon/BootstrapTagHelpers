using BootstrapTagHelpers.Extensions;
using Microsoft.AspNet.Razor.TagHelpers;

namespace BootstrapTagHelpers.Forms {
    using BootstrapTagHelpers.Attributes;

    [RestrictChildren("button", "a", "dropdown","button-group")]
    [OutputElementHint("div")]
    [ContextClass]
    public class ButtonToolbarTagHelper : BootstrapTagHelper {

        public Size? Size { get; set; }
        public ButtonContext? Context { get; set; }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "div";
            output.Attributes.Add("role","toolbar");
            output.AddCssClass("btn-toolbar");
        }
    }
}