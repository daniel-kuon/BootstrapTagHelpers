namespace BootstrapTagHelpers {
    using Microsoft.AspNet.Razor.Runtime.TagHelpers;

    public class CloseIconTagHelper:BootstrapTagHelper {
        private const  string TextAttributeName=AttributePrefix+ "text";

        [HtmlAttributeName(TextAttributeName)]
        public string Text { get; set; } = Configuration.CloseIconText;

        

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "Buttton";
            output.AddCssClass("close");
            output.MergeAttribute("type", "button");
            output.AddAriaAttribute("label", this.Text);
            output.Content.SetContent("<span aria-hidden=\"true\">&times;</span>");
            output.SelfClosing = false;
        }
    }
}