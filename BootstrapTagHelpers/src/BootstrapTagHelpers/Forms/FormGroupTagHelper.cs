using BootstrapTagHelpers.Extensions;
using Microsoft.AspNet.Razor.TagHelpers;

namespace BootstrapTagHelpers.Forms {
    using BootstrapTagHelpers.Attributes;

    [OutputElementHint("div")]
    public class FormGroupTagHelper : BootstrapTagHelper {
        public Size? ControlSize { get; set; }

        public SimpleSize? Size { get; set; }

        public int? LabelWidthXs { get; set; }

        public int? LabelWidthSm { get; set; }

        public int? LabelWidthMd { get; set; }

        public int? LabelWidthLg { get; set; }

        [HtmlAttributeNotBound]
        public FormTagHelper FormContext { get; set; }


        public ValidationContext? ValidationContext { get; set; }

        [HtmlAttributeMinimizable]
        [HtmlAttributeNotBound]
        public bool HasFeedback { get; set; }

        [HtmlAttributeNotBound]
        public bool HasLabel { get; set; }

        public override void Init(TagHelperContext context) {
            base.Init(context);
            FormContext = context.HasFormContext() ? context.GetFormContext() : new FormTagHelper();
            context.SetFormContext(new FormTagHelper {
                ControlSize = ControlSize ?? FormContext.ControlSize,
                Output = FormContext.Output,
                Inline = FormContext.Inline,
                Horizontal = FormContext.Horizontal,
                LabelWidthXs = FormContext.LabelWidthXs,
                LabelWidthLg = LabelWidthLg ?? FormContext.LabelWidthLg,
                LabelWidthMd = LabelWidthMd ?? FormContext.LabelWidthMd,
                LabelWidthSm = LabelWidthSm ?? FormContext.LabelWidthSm,
                LabelsSrOnly = FormContext.LabelsSrOnly
            });
            context.SetFormGroupContext(this);
            Size = Size ?? FormContext.FormGroupSize;
        }


        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "div";
            output.AddCssClass("form-group");
            if (ValidationContext.HasValue)
                output.AddCssClass("has-" + ValidationContext.Value.ToString().ToLower());
            if (HasFeedback)
                output.AddCssClass("has-feedback");
            if (Size != null && Size != SimpleSize.Default)
                output.AddCssClass("form-group-" + Size.Value.GetDescription());
        }

        public void WrapInDivForHorizontalForm(TagHelperOutput output, bool hasLabel) {
            FormContext?.WrapInDivForHorizontalForm(output, hasLabel || HasLabel);
        }

        public FormGroupTagHelper Clone() {
            return Clone(FormContext?.Clone());
        }

        public FormGroupTagHelper Clone(FormTagHelper formContext) {
            return new FormGroupTagHelper {
                LabelWidthLg = LabelWidthLg,
                LabelWidthMd = LabelWidthMd,
                LabelWidthSm = LabelWidthSm,
                LabelWidthXs = LabelWidthXs,
                FormContext = formContext,
                Size = Size,
                ControlSize = ControlSize,
                HasFeedback = HasFeedback,
                HasLabel = HasLabel,
                ValidationContext = ValidationContext
            };
        }
    }
}