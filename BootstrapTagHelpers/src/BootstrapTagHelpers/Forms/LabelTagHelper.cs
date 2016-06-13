using BootstrapTagHelpers.Attributes;
using BootstrapTagHelpers.Extensions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BootstrapTagHelpers.Forms {

    [ContextClass]
    public class LabelTagHelper : BootstrapTagHelper {

        [HtmlAttributeMinimizable]
        [HtmlAttributeName(AttributePrefix + "sr-only")]
        [HtmlAttributeNotBound]
        public bool? SrOnly { get; set; }

        [HtmlAttributeNotBound]
        [Context]
        public FormTagHelper FormContext { get; set; }

        [HtmlAttributeNotBound]
        [Context]
        public FormGroupTagHelper FormGroupContext { get; set; }

        public override void Init(TagHelperContext context) {
            base.Init(context);
            if (FormGroupContext != null)
                FormGroupContext.HasLabel = true;
            SrOnly = SrOnly ?? FormContext?.LabelsSrOnly;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output) {
            if (FormContext != null && FormContext.Horizontal)
                base.Process(context, output);
        }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            if (FormContext?.Horizontal ?? false) {
                output.AddCssClass("control-label");
                if (FormContext.LabelWidthXs != 0)
                    output.AddCssClass("col-xs-" + FormContext.LabelWidthXs);
                if (FormContext.LabelWidthSm != 0)
                    output.AddCssClass("col-sm-" + FormContext.LabelWidthSm);
                if (FormContext.LabelWidthMd != 0)
                    output.AddCssClass("col-md-" + FormContext.LabelWidthMd);
                if (FormContext.LabelWidthLg != 0)
                    output.AddCssClass("col-lg-" + FormContext.LabelWidthLg);
            }
            if (SrOnly ?? false)
                output.AddCssClass("sr-only");
        }

        public static IHtmlContent GenerateLabel(string content, string controlId) {
            return GenerateLabel(content, controlId, null);
        }

        public static IHtmlContent GenerateLabel(string content, string controlId, FormTagHelper formContext) {
            var builder = new TagBuilder("label") {TagRenderMode = TagRenderMode.Normal};
            if (!string.IsNullOrEmpty(controlId))
                builder.Attributes.Add("for", controlId);
            if (formContext != null && formContext.Horizontal) {
                builder.AddCssClass("control-label");
                if (formContext.LabelWidthXs != 0)
                    builder.AddCssClass("col-xs-" + formContext.LabelWidthXs);
                if (formContext.LabelWidthSm != 0)
                    builder.AddCssClass("col-sm-" + formContext.LabelWidthSm);
                if (formContext.LabelWidthMd != 0)
                    builder.AddCssClass("col-md-" + formContext.LabelWidthMd);
                if (formContext.LabelWidthLg != 0)
                    builder.AddCssClass("col-lg-" + formContext.LabelWidthLg);
            }
            if (formContext?.LabelsSrOnly ?? false)
                builder.AddCssClass("sr-only");
            builder.InnerHtml.SetHtmlContent(content);
            return builder;
        }

        public static void WrapInLabel(TagHelperOutput output, string content, string controlId) {
            WrapInLabel(output, content, controlId, null);
        }

        public static void WrapInLabel(
            TagHelperOutput output, string content, string controlId,
            FormTagHelper formContext) {
            var builder = new TagBuilder("label") {TagRenderMode = TagRenderMode.StartTag};
            if (!string.IsNullOrEmpty(controlId))
                builder.Attributes.Add("for", controlId);
            output.PreElement.Prepend(builder);
            output.PostElement.AppendHtml($"{content}</label>");
        }

        public static IHtmlContent GenerateLabel(string content) {
            return GenerateLabel(content, (FormTagHelper) null);
        }

        public static IHtmlContent GenerateLabel(string content, FormTagHelper formContext) {
            return GenerateLabel(content, null, formContext);
        }

        public static void WrapInLabel(TagHelperOutput output, string content) {
            WrapInLabel(output, content, (FormTagHelper) null);
        }

        public static void WrapInLabel(TagHelperOutput output, string content, FormTagHelper fromContext) {
            WrapInLabel(output, content, null, null);
        }
    }
}