namespace BootstrapTagHelpers {
    using Microsoft.AspNet.Razor.TagHelpers;

    [HtmlTargetElement(ProgressBarTagName)]
    public class ProgressBarTagHelper : ProgressTagHelper {
        public const string ProgressBarTagName = "progress-bar";

        public const string ValueAttributeName = AttributePrefix + "value";

        public const string ContextAttributeName = AttributePrefix + "context";

        [HtmlAttributeName(ValueAttributeName)]
        public int Value { get; set; }

        [HtmlAttributeName(ContextAttributeName)]
        public ProgressBarContext? Context { get; set; }


        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            if (context.Items.ContainsKey("ProgressContext") && context.Items["ProgressContext"] is ProgressTagHelper) {
                var progressContext = (ProgressTagHelper) context.Items["ProgressContext"];
                if (!context.AllAttributes.ContainsName(AnimatedAttributeName))
                    Animated = progressContext.Animated;
                if (!context.AllAttributes.ContainsName(StripedAttributeName))
                    Striped = progressContext.Striped;
                if (!context.AllAttributes.ContainsName(DisplayValueAttributeName))
                    DisplayValue = progressContext.DisplayValue;
                if (!context.AllAttributes.ContainsName(SrTextAttributeName))
                    SrText = progressContext.SrText;
            }
            else {
                output.PreElement.SetHtmlContent("<div class=\"progress\">");
                output.PostElement.SetHtmlContent("</div>");
            }
            output.TagName = "div";
            output.TagMode=TagMode.StartTagAndEndTag;
            output.Attributes.RemoveAll(DisplayValueAttributeName, SrTextAttributeName, AnimatedAttributeName,
                                        StripedAttributeName);
            output.AddCssClass("progress-bar");
            output.Attributes.AddAriaAttribute("valuemin", 0);
            output.Attributes.AddAriaAttribute("valuemax", 100);
            output.Attributes.AddAriaAttribute("valuenow", Value);
            output.Attributes.Add("role", "progressbar");
            output.AddCssStyle("width", Value + "%");
            if (SrText == null)
                SrText=Ressources.PorgressBarCompleteSrHint;
            if (DisplayValue ?? false) {
                output.Content.AppendHtml(string.IsNullOrWhiteSpace(SrText) ? Value.ToString() : Value + @" %<span class=""sr-only""> " + SrText + "</span>");
                output.AddCssStyle("min-width", "2em");
            }
            else
                output.Content.AppendHtml(@"<span class=""sr-only"">" + Value + @" % " + SrText + "</span>");
            if (Animated ?? false) {
                output.AddCssClass("active");
                output.AddCssClass("progress-bar-striped");
            }
            if (Striped ?? false)
                output.AddCssClass("progress-bar-striped");
            if (Context.HasValue)
                output.AddCssClass("progress-bar-" + Context.Value.ToString().ToLower());
        }
    }
}