using System.Threading.Tasks;
using BootstrapTagHelpers.Attributes;
using BootstrapTagHelpers.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BootstrapTagHelpers.Modal
{
    [HtmlTargetElement("header", ParentTag = "modal")]
    [OutputElementHint("div")]
    public class ModalHeaderTagHelper : BootstrapTagHelper {

        [HtmlAttributeMinimizable]
        [HtmlAttributeNotBound]
        public bool DisableCloseIcon { get; set; }

        [HtmlAttributeNotBound]
        [Context]
        public ModalTagHelper ModalContext { get; set; }

        protected override async Task BootstrapProcessAsync(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "div";
            output.AddCssClass("modal-header");
            if (!DisableCloseIcon)
                output.PreContent.AppendHtml(await new ITagHelper[] {new CloseIconTagHelper(), new DismissModalTagHelper()}.ToTagHelperContentAsync());
            await output.LoadChildContentAsync();
            ModalContext.HeaderHtml = output.ToTagHelperContent().GetContent();
            output.SuppressOutput();
        }
    }
}