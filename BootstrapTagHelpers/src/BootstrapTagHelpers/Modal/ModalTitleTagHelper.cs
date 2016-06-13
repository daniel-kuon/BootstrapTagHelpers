using BootstrapTagHelpers.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BootstrapTagHelpers.Modal
{
    [HtmlTargetElement("h1", ParentTag = "header")]
    [HtmlTargetElement("h2", ParentTag = "header")]
    [HtmlTargetElement("h3", ParentTag = "header")]
    [HtmlTargetElement("h4", ParentTag = "header")]
    [HtmlTargetElement("h5", ParentTag = "header")]
    [HtmlTargetElement("h6", ParentTag = "header")]
    public class ModalTitleTagHelper : BootstrapTagHelper {

        public override void Process(TagHelperContext context, TagHelperOutput output) {
            if (context.HasContextItem<ModalHeaderTagHelper>())
                base.Process(context, output);
        }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.AddCssClass("modal-title");
        }
    }
}