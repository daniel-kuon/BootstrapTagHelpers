namespace BootstrapTagHelpers {
    using Microsoft.AspNet.Razor.TagHelpers;

    [OutputElementHint("nav")]
    public class PagerTagHelper : BootstrapTagHelper {
        public string PrevHref { get; set; }
        public string PrevText { get; set; }
        public string NextHref { get; set; }
        public string NextText { get; set; }

        [HtmlAttributeMinimizable]
        [HtmlAttributeNotBound]
        public bool Stretch { get; set; }

        [HtmlAttributeMinimizable]
        [HtmlAttributeNotBound]
        public bool PrevDisabled { get; set; }

        [HtmlAttributeMinimizable]
        [HtmlAttributeNotBound]
        public bool NextDisabled { get; set; }

        [HtmlAttributeMinimizable]
        [HtmlAttributeNotBound]
        public bool HideArrows { get; set; }


        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            if (PrevText == null)
                PrevText = Ressources.Previous;
            if (NextText == null)
                NextText = Ressources.Next;
            output.TagName = "nav";
            var content = "<ul class=\"pager\"><li";
            if (PrevDisabled && Stretch)
                content += " class=\"previous disabled\"><a>";
            else if (PrevDisabled)
                content += " class=\"disabled\"><a>";
            else if (Stretch)
                content += $" class=\"previous\"><a href=\"{PrevHref}\">";
            else
                content += $"><a href=\"{PrevHref}\">";
            if (!HideArrows)
                content += "<span aria-hidden=\"true\">&larr;</span> ";
            content += PrevText + "</a></li><li";
            if (NextDisabled && Stretch)
                content += " class=\"next disabled\"><a>";
            else if (NextDisabled)
                content += " class=\"disabled\"><a>";
            else if (Stretch)
                content += $" class=\"next\"><a href=\"{NextHref}\">";
            else
                content += $"><a href=\"{NextHref}\">";
            content += NextText;
            if (!HideArrows)
                content += " <span aria-hidden=\"true\">&rarr;</span>";
            content += "</a></li></ul>";
            output.Content.SetHtmlContent(content);
        }
    }
}