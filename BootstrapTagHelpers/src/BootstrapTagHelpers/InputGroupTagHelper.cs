namespace BootstrapTagHelpers {
    using System;
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

    [HtmlTargetElement("addon", ParentTag = "input-group")]
    [OutputElementHint("span")]
    public class AddonTagHelper : BootstrapTagHelper {
        public static string GenerateAddon(string text) {
            return $"<span class=\"input-group-addon\">{text}</span>";
        }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "span";
            output.AddCssClass("input-group-addon");
        }
    }
}