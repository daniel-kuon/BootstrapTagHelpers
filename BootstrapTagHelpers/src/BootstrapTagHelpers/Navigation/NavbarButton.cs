namespace BootstrapTagHelpers.Navigation {
    using BootstrapTagHelpers.Extensions;

    using Microsoft.AspNet.Razor.TagHelpers;

    [HtmlTargetElement("button", ParentTag = "navbar")]
    [HtmlTargetElement("input", Attributes = TypeAttributeName, ParentTag = "navbar")]
    [HtmlTargetElement("a", Attributes = ButtonAttributeName, ParentTag = "navbar")]
    public class NavbarButton : BootstrapTagHelper {

        public const string TypeAttributeName = "type";
        public const string ButtonAttributeName = AttributePrefix + "button";

        [HtmlAttributeMinimizable]
        [HtmlAttributeNotBound]
        [HtmlAttributeName(ButtonAttributeName)]
        public bool Button { get; set; }

        [CopyToOutput]
        public string Type { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output) {
            this.Type = this.Type?.ToLower() ?? "";
            output.TagName = output.TagName.ToLower();
            if (this.Button || output.TagName == "button" ||
                output.TagName == "input" && (this.Type == "button" || this.Type == "submit" || this.Type == "reset"))
                base.Process(context, output);
        }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.AddCssClass("navbar-btn");
        }
    }
}