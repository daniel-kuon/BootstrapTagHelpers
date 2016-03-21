using BootstrapTagHelpers.Extensions;
using Microsoft.AspNet.Razor.TagHelpers;

namespace BootstrapTagHelpers {

    [OutputElementHint("button")]
    public class CloseIconTagHelper:BootstrapTagHelper {
        private const  string TextAttributeName=AttributePrefix+ "text";

        [HtmlAttributeName(TextAttributeName)]
        public string Text { get; set; } = Configuration.CloseIconText;



        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "button";
            output.AddCssClass("close");
            output.MergeAttribute("type", "button");
            output.AddAriaAttribute("label", Text);
            output.Content.SetHtmlContent("<span aria-hidden=\"true\">&times;</span>");
            output.TagMode=TagMode.StartTagAndEndTag;
        }
    }
}