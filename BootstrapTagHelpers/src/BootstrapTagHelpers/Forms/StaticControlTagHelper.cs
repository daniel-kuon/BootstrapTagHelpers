using BootstrapTagHelpers.Attributes;
using BootstrapTagHelpers.Extensions;

using Microsoft.AspNet.Razor.TagHelpers;

namespace BootstrapTagHelpers.Forms {

    [OutputElementHint("p")]
    public class StaticControlTagHelper : BootstrapTagHelper {
        protected override bool CopyAttributesIfBootstrapIsDisabled => true;

        [CopyToOutput]
        public string Id { get; set; }

        public string Label { get; set; }
        public string HelpText { get; set; }

        [HtmlAttributeNotBound]
        [Context]
        public FormTagHelper FormContext { get; set; }

        [HtmlAttributeNotBound]
        [Context]
        public FormGroupTagHelper FormGroupContext { get; set; }

        public Size? Size { get; set; }

        public override void Init(TagHelperContext context) {
            base.Init(context);
            this.Size = this.Size ?? this.FormContext?.ControlSize;
        }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "p";
            output.AddCssClass("form-control-static");
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