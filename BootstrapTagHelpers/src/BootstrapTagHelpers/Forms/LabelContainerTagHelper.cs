using BootstrapTagHelpers.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BootstrapTagHelpers.Forms {
    [HtmlTargetElement("label-container", ParentTag = "form")]
    [HtmlTargetElement("label-container", ParentTag = "form-group")]
    [OutputElementHint("div")]
    public class LabelContainerTagHelper : HorizontalFormContainerTagHelper {
        public override void Init(TagHelperContext context) {
            base.Init(context);
            if (FormGroupContext != null)
                FormGroupContext.HasLabel = true;
            WidthLg = WidthLg ?? FormGroupContext?.LabelWidthLg ?? FormContext?.LabelWidthLg;
            WidthMd = WidthMd ?? FormGroupContext?.LabelWidthMd ?? FormContext?.LabelWidthMd;
            WidthSm = WidthSm ?? FormGroupContext?.LabelWidthSm ?? FormContext?.LabelWidthSm;
            WidthXs = WidthXs ?? FormGroupContext?.LabelWidthXs ?? FormContext?.LabelWidthXs;
        }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            base.BootstrapProcess(context, output);

            if (FormContext?.Horizontal ?? true)
                output.AddCssClass("control-label");
        }
    }
}