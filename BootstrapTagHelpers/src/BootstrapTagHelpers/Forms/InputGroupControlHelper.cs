using BootstrapTagHelpers.Attributes;
using BootstrapTagHelpers.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BootstrapTagHelpers.Forms {
    /// <summary>
    ///     HelperClass which moves the PreElement and PostElementContents to the InputGroupTagHelper
    /// </summary>
    [HtmlTargetElement("input", ParentTag = "input-group")]
    public class InputGroupControlHelper : BootstrapTagHelper {
        public override int Order => 100000;
        [HtmlAttributeNotBound]
        [Context]
        public InputGroupTagHelper InputGroupContext { get; set; }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            if (!output.PostElement.IsEmptyOrWhiteSpace)
                InputGroupContext.Output.PostElement.AppendHtml(output.PostElement.GetContent());
            if (!output.PreElement.IsEmptyOrWhiteSpace)
                InputGroupContext.Output.PreElement.PrependHtml(output.PreElement.GetContent());
            base.BootstrapProcess(context, output);
        }
    }
}