namespace BootstrapTagHelpers {
    using Microsoft.AspNet.Mvc.Rendering;
    using Microsoft.AspNet.Razor.TagHelpers;

    [OutputElementHint("div")]
    [RestrictChildren("a", "header", "divider")]
    public class DropdownTagHelper : BootstrapTagHelper {
        [HtmlAttributeMinimizable]
        [HtmlAttributeNotBound]
        public bool Splitted { get; set; }

        [HtmlAttributeMinimizable]
        [HtmlAttributeNotBound]
        public bool RightAligned { get; set; }

        [HtmlAttributeMinimizable]
        [HtmlAttributeNotBound]
        public bool Dropup { get; set; }

        public Size Size { get; set; }

        public string Text { get; set; }

        public string Href { get; set; }

        public string ButtonId { get; set; }


        public ButtonContext Context { get; set; }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "div";
            output.AddCssClass("btn-group");
            if (Dropup)
                output.AddCssClass("dropup");
            if (Size != Size.Default)
                output.AddCssClass("btn-group-" + Size.GetDescription());
            var buttonBuilder = new TagBuilder(Href == null ? "button" : "a");
            buttonBuilder.InnerHtml.AppendHtml(Text);
            buttonBuilder.AddCssClass("btn");
            buttonBuilder.AddCssClass("btn-" + Context.ToString().ToLower());
            if (ButtonId != null)
                buttonBuilder.Attributes.Add("id", ButtonId);
            if (Href == null)
                buttonBuilder.Attributes.Add("type", "button");
            else {
                buttonBuilder.Attributes.Add("href", Href);
                if (!Splitted)
                    buttonBuilder.Attributes.Add("role", "button");
            }
            if (Splitted) {
                output.PreContent.Append(buttonBuilder);
                buttonBuilder = new TagBuilder("button") {
                    Attributes = {{"type", "button"}, {"class", "btn btn-" + Context.ToString().ToLower()}}
                };
            }
            else
                buttonBuilder.InnerHtml.AppendHtml(" ");
            buttonBuilder.AddCssClass("dropdown-toggle");
            buttonBuilder.Attributes.Add("data-toggle", "dropdown");
            buttonBuilder.Attributes.Add("aria-haspopup", "true");
            buttonBuilder.Attributes.Add("aria-expanded", "false");
            buttonBuilder.InnerHtml.AppendHtml("<span class=\"caret\">");
            output.PreContent.Append(buttonBuilder);
            output.PreContent.AppendHtml(RightAligned
                                             ? "<ul class=\"dropdown-menu dropdown-menu-right\">"
                                             : "<ul class=\"dropdown-menu\">");
            output.PostContent.AppendHtml("</ul>");
        }
    }
}