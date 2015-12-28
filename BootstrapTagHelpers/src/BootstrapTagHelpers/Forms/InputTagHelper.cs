using System;
using BootstrapTagHelpers.Extensions;
using BootstrapTagHelpers.Navigation;
using Microsoft.AspNet.Razor.TagHelpers;

namespace BootstrapTagHelpers.Forms {
    public class InputTagHelper : BootstrapTagHelper {
        public const string PreAddonTextAttributeName = AttributePrefix + "pre-addon-text";
        public const string PostAddonTextAttributeName = AttributePrefix + "post-addon-text";
        public const string HelpContentAttributeName = AttributePrefix + "help-content";

        [HtmlAttributeName(PreAddonTextAttributeName)]
        public string PreAddonText { get; set; }

        [HtmlAttributeName(PostAddonTextAttributeName)]
        public string PostAddonText { get; set; }

        public string Type { get; set; }

        [HtmlAttributeName(HelpContentAttributeName)]
        public string HelpContent { get; set; }


        public override void Init(TagHelperContext context) {
            if (context.HasInputGroupContext()) {
                InputGroupTagHelper inputGroupContext = context.GetInputGroupContext();
            }
        }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.AddCssClass("form-control");
            Type = Type ?? "";
            if (!string.IsNullOrEmpty(Type))
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
            if (!string.IsNullOrEmpty(HelpContent))
                if (context.HasInputGroupContext())
                    context.GetInputGroupContext().HelpContent = HelpContent;
                else
                    output.PostElement.AppendHtml(HelpBlockTagHelper.GenerateHelpBlock(HelpContent));
        }
    }
}