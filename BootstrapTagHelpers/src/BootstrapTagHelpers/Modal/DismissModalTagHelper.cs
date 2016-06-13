using BootstrapTagHelpers.Attributes;
using BootstrapTagHelpers.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BootstrapTagHelpers.Modal
{
    [HtmlTargetElement("*", Attributes = DismissModalAttributeName)]
    public class DismissModalTagHelper : BootstrapTagHelper {
        public const string DismissModalAttributeName = AttributePrefix + "dismiss-modal";

        [HtmlAttributeName(DismissModalAttributeName)]
        [HtmlAttributeMinimizable]
        [HtmlAttributeNotBound]
        public bool DismissModal { get; set; } = true;

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            if (DismissModal)
                output.Attributes.AddDataAttribute("dismiss", "modal");
        }
    }
}