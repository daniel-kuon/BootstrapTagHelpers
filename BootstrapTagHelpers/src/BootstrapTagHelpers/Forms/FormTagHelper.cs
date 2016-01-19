using BootstrapTagHelpers.Extensions;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Razor.TagHelpers;

namespace BootstrapTagHelpers.Forms {
    public class FormTagHelper : BootstrapTagHelper {
        [HtmlAttributeName(AttributePrefix + "label-width-xs")]
        public int LabelWidthXs { get; set; }

        [HtmlAttributeName(AttributePrefix + "label-width-sm")]
        public int LabelWidthSm { get; set; }

        [HtmlAttributeName(AttributePrefix + "label-width-md")]
        public int LabelWidthMd { get; set; }

        [HtmlAttributeName(AttributePrefix + "label-width-lg")]
        public int LabelWidthLg { get; set; }

        [HtmlAttributeName(AttributePrefix + "control-size")]
        public Size ControlSize { get; set; }

        [HtmlAttributeName(AttributePrefix + "form-group-size")]
        public SimpleSize FormGroupSize { get; set; }

        [HtmlAttributeNotBound]
[HtmlAttributeMinimizable]
[HtmlAttributeName(AttributePrefix+"labels-sr-only")]
        public bool LabelsSrOnly { get; set; }



        [HtmlAttributeName(AttributePrefix + "horizontal")]
        [HtmlAttributeMinimizable]
        [HtmlAttributeNotBound]
        public bool Horizontal { get; set; }

        [HtmlAttributeName(AttributePrefix + "inline")]
        [HtmlAttributeMinimizable]
        [HtmlAttributeNotBound]
        public bool Inline { get; set; }

        public override void Init(TagHelperContext context) {
            base.Init(context);
            context.SetFormContext(this);
        }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            if (Horizontal)
                output.AddCssClass("form-horizontal");
            if (Inline)
                output.AddCssClass("form-inline");
        }

        public void WrapInDivForHorizontalForm(TagHelperOutput output, bool hasLabel) {
            if (Horizontal) {
                var builder = new TagBuilder("div") {TagRenderMode = TagRenderMode.StartTag};
                if (LabelWidthXs != 0) {
                    builder.AddCssClass("col-xs-" + (12 - LabelWidthXs));
                    if (!hasLabel)
                        builder.AddCssClass("col-xs-offset-" + LabelWidthXs);
                }
                if (LabelWidthSm != 0) {
                    builder.AddCssClass("col-sm-" + (12 - LabelWidthSm));
                    if (!hasLabel)
                        builder.AddCssClass("col-sm-offset-" + LabelWidthSm);
                }
                if (LabelWidthMd != 0) {
                    builder.AddCssClass("col-md-" + (12 - LabelWidthMd));
                    if (!hasLabel)
                        builder.AddCssClass("col-md-offset-" + LabelWidthMd);
                }
                if (LabelWidthLg != 0) {
                    builder.AddCssClass("col-lg-" + (12 - LabelWidthLg));
                    if (!hasLabel)
                        builder.AddCssClass("col-lg-offset-" + LabelWidthLg);
                }
                output.PreElement.Prepend(builder);
                output.PostElement.AppendHtml("</div>");
            }
        }

        public FormTagHelper Clone() {
            return new FormTagHelper() {
                Horizontal = Horizontal,
                ControlSize = ControlSize,
                LabelWidthXs = LabelWidthXs,
                FormGroupSize = FormGroupSize,
                Inline = Inline,
                LabelWidthLg = LabelWidthLg,
                LabelWidthMd = LabelWidthMd,
                LabelWidthSm = LabelWidthSm,
                LabelsSrOnly = LabelsSrOnly
            };
        }
    }
}