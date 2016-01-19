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
        public SimpleSize? Size { get; set; }
        public string HelpContent { get; set; }

        public override void Init(TagHelperContext context) {
            base.Init(context);
            FormGroupContext = context.GetFormGroupContext();
            FormContext = context.GetFormContext();
            if (FormGroupContext != null) {
                var formGroupContextClone = FormGroupContext.Clone();
                context.SetFormGroupContext(formGroupContextClone);
                formGroupContextClone.ControlSize=BootstrapTagHelpers.Size.Default;
                if (FormGroupContext.FormContext != null) {
                    formGroupContextClone.FormContext.ControlSize=BootstrapTagHelpers.Size.Default;
                    context.SetFormContext(formGroupContextClone.FormContext);

                }
            }
            else if (FormContext != null) {
                FormTagHelper formTagHelperClone = FormContext.Clone();
                context.SetFormContext(formTagHelperClone);
                formTagHelperClone.ControlSize=BootstrapTagHelpers.Size.Default;
            }
            if (Size == null) {
                var size = FormGroupContext?.ControlSize ?? FormContext?.ControlSize;
                if (size != null)
                    Size = size == BootstrapTagHelpers.Size.Large ? SimpleSize.Large : SimpleSize.Small;
            }
        }
        [HtmlAttributeNotBound]
        public FormGroupTagHelper FormGroupContext { get; set; }
        [HtmlAttributeNotBound]
        public FormTagHelper FormContext { get; set; }

        protected override async Task BootstrapProcessAsync(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "div";
            output.AddCssClass("input-group");
            if ((Size??SimpleSize.Default) != SimpleSize.Default)
                output.AddCssClass("input-group-" + Size.Value.GetDescription());
            if (!string.IsNullOrEmpty(PreAddonText))
                output.PreContent.SetHtmlContent(AddonTagHelper.GenerateAddon(PreAddonText));
            if (!string.IsNullOrEmpty(PostAddonText))
                output.PostContent.SetHtmlContent(AddonTagHelper.GenerateAddon(PostAddonText));
            context.SetInputGroupContext(this);
            await output.GetChildContentAsync();
            var preElementContent = output.PreElement.GetContent();
            output.PreElement.Clear();
            if (FormGroupContext != null)
                FormGroupContext.WrapInDivForHorizontalForm(output, context.GetFormGroupContext()?.HasLabel??false);
            else if (FormContext != null)
                FormContext.WrapInDivForHorizontalForm(output, context.GetFormGroupContext()?.HasLabel ?? false);
            output.PreElement.PrependHtml(preElementContent);
            if (!string.IsNullOrEmpty(HelpContent))
                output.PostElement.PrependHtml(HelpBlockTagHelper.GenerateHelpBlock(HelpContent));
        }
    }
}