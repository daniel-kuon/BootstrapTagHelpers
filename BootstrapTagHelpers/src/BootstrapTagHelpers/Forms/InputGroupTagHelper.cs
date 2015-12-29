using System.Threading.Tasks;
using BootstrapTagHelpers.Extensions;
using BootstrapTagHelpers.Navigation;
using Microsoft.AspNet.Razor.TagHelpers;

namespace BootstrapTagHelpers.Forms {
    [RestrictChildren("button", "button-group", "input", "addon", "dropdown", "input", "a")]
    [OutputElementHint("div")]
    public class InputGroupTagHelper : BootstrapTagHelper {
        public string PreAddonText { get; set; }
        public string PostAddonText { get; set; }
        public SimpleSize Size { get; set; }
        public string HelpContent { get; set; }

        protected override async Task BootstrapProcessAsync(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "div";
            output.AddCssClass("input-group");
            if (Size != SimpleSize.Default)
                output.AddCssClass("input-group-" + Size.GetDescription());
            if (!string.IsNullOrEmpty(PreAddonText))
                output.PreContent.SetHtmlContent(AddonTagHelper.GenerateAddon(PreAddonText));
            if (!string.IsNullOrEmpty(PostAddonText))
                output.PreContent.SetHtmlContent(AddonTagHelper.GenerateAddon(PostAddonText));
            context.SetInputGroupContext(this);
            await output.GetChildContentAsync();
            if (!string.IsNullOrEmpty(HelpContent))
                output.PostElement.AppendHtml(HelpBlockTagHelper.GenerateHelpBlock(HelpContent));
        }
    }
}