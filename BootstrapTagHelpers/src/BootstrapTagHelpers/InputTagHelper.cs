namespace BootstrapTagHelpers {
    using System;
    using Microsoft.AspNet.Razor.TagHelpers;

    public class InputTagHelper : BootstrapTagHelper {
        public const string PreAddonTextAttributeName = AttributePrefix + "pre-addon-text";
        public const string PostAddonTextAttributeName = AttributePrefix + "post-addon-text";

        [HtmlAttributeName(PreAddonTextAttributeName)]
        public string PreAddonText { get; set; }

        [HtmlAttributeName(PostAddonTextAttributeName)]
        public string PostAddonText { get; set; }

        public string Type { get; set; }


        public override void Init(TagHelperContext context) {
            if (context.HasInputGroupContext()) {
                InputGroupTagHelper inputGroupContext = context.GetInputGroupContext();
            }
        }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.AddCssClass("form-control");
            output.Attributes.Add("type", Type.ToLower());
            if (!string.IsNullOrEmpty(PostAddonText) || !string.IsNullOrEmpty(PreAddonText)) {
                output.PreElement.SetHtmlContent("<div class=\"input-group\">");
                if (!string.IsNullOrEmpty(PreAddonText))
                    output.PreElement.AppendHtml(AddonTagHelper.GenerateAddon(PreAddonText));
                if (!string.IsNullOrEmpty(PostAddonText))
                    output.PostElement.AppendHtml(AddonTagHelper.GenerateAddon(PostAddonText));
                output.PostElement.AppendHtml("</div>");
            }
            if (Type.Equals("checkbox", StringComparison.CurrentCultureIgnoreCase) ||
                Type.Equals("radio", StringComparison.CurrentCultureIgnoreCase))
                if (context.HasInputGroupContext() && !context.HasInputGroupAddonContext()) {
                    output.PreElement.PrependHtml("<span class=\"input-group-addon\">");
                    output.PostElement.AppendHtml("</span>");
                    output.RemoveCssClass("form-control");
                }

        }
    }
}