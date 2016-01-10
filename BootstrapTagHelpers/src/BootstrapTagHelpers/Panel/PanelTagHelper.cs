using BootstrapTagHelpers.Extensions;
using Microsoft.AspNet.Razor.TagHelpers;

namespace BootstrapTagHelpers.Panel {
    [OutputElementHint("div")]
    [RestrictChildren("panel-body","heading","footer","list-group","table")]
    public class PanelTagHelper:BootstrapTagHelper {
        public string Heading { get; set; }
        public string Footer { get; set; }

        public PanelContext Context { get; set; }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "div";
            output.AddCssClass("panel");
            output.AddCssClass("panel-" + Context.ToString().ToLower());
            if (!string.IsNullOrEmpty(Heading))
                output.PreContent.PrependHtml($"<div class=\"panel-heading\">{Heading}</div>");
            if (!string.IsNullOrEmpty(Footer))
                output.PostContent.AppendHtml($"<div class=\"panel-footer\">{Footer}</div>");
        }

    }
}