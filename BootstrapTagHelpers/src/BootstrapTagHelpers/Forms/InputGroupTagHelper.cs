using System.Threading.Tasks;

using BootstrapTagHelpers.Attributes;
using BootstrapTagHelpers.Extensions;
using BootstrapTagHelpers.Navigation;

using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BootstrapTagHelpers.Forms {
    [RestrictChildren("button", "button-group", "input", "addon", "dropdown", "input", "a")]
    [OutputElementHint("div")]
    [ContextClass]
    public class InputGroupTagHelper : BootstrapTagHelper {
        public string PreAddonText { get; set; }
        public string PostAddonText { get; set; }
        public SimpleSize? Size { get; set; }
        public string HelpContent { get; set; }

        [HtmlAttributeNotBound]
        [Context]
        public FormGroupTagHelper FormGroupContext { get; set; }

        [HtmlAttributeNotBound]
        [Context]
        public FormTagHelper FormContext { get; set; }

        public override void Init(TagHelperContext context) {
            base.Init(context);
            if (FormGroupContext != null) {
                var formGroupContextClone = FormGroupContext.Clone();
                context.SetContextItem(formGroupContextClone);
                formGroupContextClone.ControlSize = BootstrapTagHelpers.Size.Default;
                if (FormGroupContext.FormContext != null) {
                    formGroupContextClone.FormContext.ControlSize = BootstrapTagHelpers.Size.Default;
                    context.SetContextItem(formGroupContextClone.FormContext);
                }
            } else if (FormContext != null) {
                var formTagHelperClone = FormContext.Clone();
                context.SetContextItem(formTagHelperClone);
                formTagHelperClone.ControlSize = BootstrapTagHelpers.Size.Default;
            }
            if (Size == null) {
                var size = FormGroupContext?.ControlSize ?? FormContext?.ControlSize;
                if (size != null)
                    Size = size == BootstrapTagHelpers.Size.Large ? SimpleSize.Large : SimpleSize.Small;
            }
        }

        protected override async Task BootstrapProcessAsync(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "div";
            output.AddCssClass("input-group");
            if ((Size ?? SimpleSize.Default) != SimpleSize.Default)
                output.AddCssClass("input-group-" + Size.Value.GetDescription());
            if (!string.IsNullOrEmpty(PreAddonText))
                output.PreContent.SetHtmlContent(AddonTagHelper.GenerateAddon(PreAddonText));
            if (!string.IsNullOrEmpty(PostAddonText))
                output.PostContent.SetHtmlContent(AddonTagHelper.GenerateAddon(PostAddonText));
            await output.GetChildContentAsync();
            var preElementContent = output.PreElement.GetContent();
            output.PreElement.Clear();
            if (FormGroupContext != null)
                FormGroupContext.WrapInDivForHorizontalForm(output, context.GetContextItem<FormGroupTagHelper>()?.HasLabel ?? false);
            else if (FormContext != null)
                FormContext.WrapInDivForHorizontalForm(output, context.GetContextItem<FormGroupTagHelper>()?.HasLabel ?? false);
            output.PreElement.PrependHtml(preElementContent);
            if (!string.IsNullOrEmpty(HelpContent))
                output.PostElement.PrependHtml(HelpBlockTagHelper.GenerateHelpBlock(HelpContent));
        }
    }
}