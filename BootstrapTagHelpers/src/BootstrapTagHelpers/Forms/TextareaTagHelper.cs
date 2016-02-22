namespace BootstrapTagHelpers.Forms {
    using BootstrapTagHelpers.Attributes;
    using BootstrapTagHelpers.Extensions;

    using Microsoft.AspNet.Razor.TagHelpers;

    public class TextareaTagHelper : BootstrapTagHelper {
        protected override bool CopyAttributesIfBootstrapIsDisabled => true;

        [CopyToOutput]
        public string Id { get; set; }

        [HtmlAttributeName(AttributePrefix + "label")]
        public string Label { get; set; }

        [HtmlAttributeName(AttributePrefix + "help-text")]
        public string HelpText { get; set; }

        [HtmlAttributeNotBound]
        public FormTagHelper FormContext { get; set; }

        [HtmlAttributeNotBound]
        public FormGroupTagHelper FormGroupContext { get; set; }

        [HtmlAttributeName(AttributePrefix + "size")]
        public Size? Size { get; set; }

        public override void Init(TagHelperContext context) {
            base.Init(context);
            this.FormGroupContext = context.GetFormGroupContext();
            this.FormContext = context.GetFormContext();
            this.Size = this.Size ?? this.FormContext?.ControlSize;
        }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.AddCssClass("form-control");
            if (this.FormGroupContext != null)
                this.FormGroupContext.WrapInDivForHorizontalForm(output, !string.IsNullOrEmpty(this.Label));
            else if (this.FormContext != null)
                this.FormContext.WrapInDivForHorizontalForm(output, !string.IsNullOrEmpty(this.Label));
            if (!string.IsNullOrEmpty(this.Label))
                output.PreElement.Prepend(LabelTagHelper.GenerateLabel(this.Label, this.FormContext));
            if (!string.IsNullOrEmpty(this.HelpText))
                output.PostElement.PrependHtml(HelpBlockTagHelper.GenerateHelpBlock(this.HelpText));
            if (this.Size != null && this.Size != BootstrapTagHelpers.Size.Default)
                output.AddCssClass("input-" + this.Size.Value.GetDescription());
        }
    }
}