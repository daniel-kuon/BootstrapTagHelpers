namespace BootstrapTagHelpers {
    using Microsoft.AspNet.Razor.TagHelpers;

    [RestrictChildren("button", "button-group", "input", "addon", "dropdown", "input", "a")]
    [OutputElementHint("div")]
    public class InputGroupTagHelper : BootstrapTagHelper {
        public string PreAddonText { get; set; }
        public string PostAddonText { get; set; }
        public InputGroupSize Size { get; set; }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "div";
            output.AddCssClass("input-group");
            if (Size != InputGroupSize.Default)
                output.AddCssClass("input-group-" + Size.GetDescription());
            if (!string.IsNullOrEmpty(PreAddonText))
                output.PreContent.SetHtmlContent(AddonTagHelper.GenerateAddon(PreAddonText));
            if (!string.IsNullOrEmpty(PostAddonText))
                output.PreContent.SetHtmlContent(AddonTagHelper.GenerateAddon(PostAddonText));
            context.SetInputGroupContext(this);
        }
    }
}