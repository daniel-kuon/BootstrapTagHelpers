using System;
using BootstrapTagHelpers.Extensions;
using BootstrapTagHelpers.Navigation;
using Microsoft.AspNet.Razor.TagHelpers;

namespace BootstrapTagHelpers.Forms {
    using BootstrapTagHelpers.Attributes;

    public class InputTagHelper : BootstrapTagHelper {
        protected override bool CopyAttributesIfBootstrapIsDisabled => true;

        public override int Order => 100001;

        [HtmlAttributeName(AttributePrefix + "pre-addon-text")]
        public string PreAddonText { get; set; }

        [HtmlAttributeName(AttributePrefix + "post-addon-text")]
        public string PostAddonText { get; set; }

        [CopyToOutput]
        public string Type { get; set; }

        [HtmlAttributeName(AttributePrefix + "help-text")]
        public string HelpText { get; set; }

        [HtmlAttributeName(AttributePrefix + "label")]
        public string Label { get; set; }

        [HtmlAttributeNotBound]
        public InputGroupTagHelper InputGroupContext { get; set; }

        [CopyToOutput]
        public string Id { get; set; }

        [HtmlAttributeNotBound]
        public FormTagHelper FormContext { get; set; }

        [HtmlAttributeNotBound]
        public FormGroupTagHelper FormGroupContext { get; set; }

        protected bool IsInLabel { get; set; }

        [HtmlAttributeName(AttributePrefix + "size")]
        public Size? Size { get; set; }

        public override void Init(TagHelperContext context) {
            base.Init(context);
            FormContext = context.GetFormContext();
            FormGroupContext = context.GetFormGroupContext();
            InputGroupContext = context.GetInputGroupContext();
            IsInLabel = context.HasLabelContext();
            Size = Size ?? FormContext?.ControlSize;
            if (FormGroupContext != null)
                FormGroupContext.HasLabel = FormGroupContext.HasLabel || !string.IsNullOrEmpty(Label);
        }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            if (string.Equals(output.TagName, "input", StringComparison.OrdinalIgnoreCase))
                Type = Type ??
                       (output.Attributes.ContainsName("type")
                            ? output.Attributes["name"].Value.ToString()
                            : "text");
            bool isCheckControl = Type.Equals("checkbox", StringComparison.CurrentCultureIgnoreCase) ||
                                  Type.Equals("radio", StringComparison.CurrentCultureIgnoreCase);
            if (isCheckControl)
                ProcessCheckControl(context, output);
            else
                ProcessNonCheckControl(output);
        }

        private void ProcessNonCheckControl(TagHelperOutput output) {
            output.AddCssClass("form-control");
            if (!string.IsNullOrEmpty(PostAddonText) || !string.IsNullOrEmpty(PreAddonText)) {
                if ((Size ?? BootstrapTagHelpers.Size.Default) != BootstrapTagHelpers.Size.Default) {
                    Size size = Size == BootstrapTagHelpers.Size.Large
                                    ? BootstrapTagHelpers.Size.Large
                                    : BootstrapTagHelpers.Size.Small;
                    output.PreElement.PrependHtml($"<div class=\"input-group input-group-{size.GetDescription()}\">");
                }
                else
                    output.PreElement.PrependHtml("<div class=\"input-group\">");
                if (!string.IsNullOrEmpty(PreAddonText))
                    output.PreElement.AppendHtml(AddonTagHelper.GenerateAddon(PreAddonText));
                if (!string.IsNullOrEmpty(PostAddonText))
                    output.PostElement.AppendHtml(AddonTagHelper.GenerateAddon(PostAddonText));
                output.PostElement.AppendHtml("</div>");
            }
            else if (Size != null && Size != BootstrapTagHelpers.Size.Default)
                output.AddCssClass("input-" + Size.Value.GetDescription());
            if (!string.IsNullOrEmpty(HelpText))
                if (InputGroupContext != null)
                    InputGroupContext.Output.PostElement.PrependHtml(HelpBlockTagHelper.GenerateHelpBlock(HelpText));
                else
                    output.PostElement.AppendHtml(HelpBlockTagHelper.GenerateHelpBlock(HelpText));
            if (InputGroupContext==null)
            if (FormGroupContext != null)
                FormGroupContext.WrapInDivForHorizontalForm(output, !string.IsNullOrEmpty(Label));
            else if (FormContext != null)
                FormContext.WrapInDivForHorizontalForm(output, !string.IsNullOrEmpty(Label));
            if (!string.IsNullOrEmpty(Label))
                if (InputGroupContext == null)
                    output.PreElement.Prepend(LabelTagHelper.GenerateLabel(Label, Id, FormContext));
                else
                    InputGroupContext.Output.PreElement.Prepend(LabelTagHelper.GenerateLabel(Label, Id,
                                                                                             FormContext));
            if (FormGroupContext != null && FormGroupContext.HasFeedback &&
                FormGroupContext.ValidationContext != null) {
                string cssClass;
                string srText;
                switch (FormGroupContext.ValidationContext.Value) {
                    case ValidationContext.Success:
                        cssClass = "ok";
                        srText = Ressources.ValidationSuccess;
                        break;
                    case ValidationContext.Warning:
                        cssClass = "warning-sign";
                        srText = Ressources.ValidationWarning;
                        break;
                    case ValidationContext.Error:
                        cssClass = "remove";
                        srText = Ressources.ValidationError;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                output.PostElement.PrependHtml(
                                               $"<span class=\"glyphicon glyphicon-{cssClass} form-control-feedback\" aria-hidden=\"true\"></span>");
                output.PostElement.PrependHtml($"<span class=\"sr-only\">({srText})</span>");
            }
        }

        private void ProcessCheckControl(TagHelperContext context, TagHelperOutput output) {
            if (InputGroupContext != null) {
                output.PreElement.Append(Label);
                if (!context.HasInputGroupAddonContext()) {
                    output.PreElement.AppendHtml("<span class=\"input-group-addon\">");
                    output.PostElement.PrependHtml("</span>");
                }
            }
            else if (IsInLabel)
                output.PostElement.Append(Label);
            else
                LabelTagHelper.WrapInLabel(output, Label, null, FormContext);
            if (!string.IsNullOrEmpty(HelpText))
                if (InputGroupContext != null)
                    InputGroupContext.Output.PostElement.AppendHtml(HelpBlockTagHelper.GenerateHelpBlock(HelpText));
                else
                    output.PostElement.AppendHtml(HelpBlockTagHelper.GenerateHelpBlock(HelpText));
            if (!IsInLabel) {
                output.PreElement.PrependHtml(FormContext?.Inline ?? false
                                                  ? $"<div class=\"{Type.ToLower()}-inline\">"
                                                  : $"<div class=\"{Type.ToLower()}\">");
                output.PostElement.AppendHtml("</div>");
                if (FormGroupContext != null)
                    FormGroupContext.WrapInDivForHorizontalForm(output, false);
                else if (FormContext != null)
                    FormContext.WrapInDivForHorizontalForm(output, false);
            }
        }
    }
}