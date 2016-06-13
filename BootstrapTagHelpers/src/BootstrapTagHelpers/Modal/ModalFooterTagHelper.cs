using System.Threading.Tasks;
using BootstrapTagHelpers.Attributes;
using BootstrapTagHelpers.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BootstrapTagHelpers.Modal
{
    [HtmlTargetElement("footer", ParentTag = "modal")]
    [OutputElementHint("div")]
    public class ModalFooterTagHelper : BootstrapTagHelper {

        [HtmlAttributeNotBound]
        [Context]
        public ModalTagHelper ModalContext { get; set; }

        protected override async Task BootstrapProcessAsync(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "div";
            output.AddCssClass("modal-footer");
            await output.LoadChildContentAsync();
            ModalContext.FooterHtml = output.ToTagHelperContent().GetContent();
            output.SuppressOutput();
        }
    }
}