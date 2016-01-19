using BootstrapTagHelpers.Extensions;
using Microsoft.AspNet.Razor.TagHelpers;

namespace BootstrapTagHelpers.Forms {
    /// <summary>
    ///     HelperClass which moves the PreElement and PostElementContents to the InputGroupTagHelper
    /// </summary>
    [HtmlTargetElement("input", ParentTag = "input-group")]
    public class InputGroupControlHelper : BootstrapTagHelper {
        public override int Order => 100000;
        [HtmlAttributeNotBound]
        public InputGroupTagHelper InputGroupContext { get; set; }

        public override void Init(TagHelperContext context) {
            base.Init(context);
            InputGroupContext = context.GetInputGroupContext();
        }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            if (!output.PostElement.IsEmpty)
                InputGroupContext.Output.PostElement.AppendHtml(output.PostElement.GetContent());
            if (!output.PreElement.IsEmpty)
                InputGroupContext.Output.PreElement.PrependHtml(output.PreElement.GetContent());
            base.BootstrapProcess(context, output);
        }
    }
}