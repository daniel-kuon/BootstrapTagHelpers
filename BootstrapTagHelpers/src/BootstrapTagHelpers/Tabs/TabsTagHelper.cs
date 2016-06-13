namespace BootstrapTagHelpers.Tabs {
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BootstrapTagHelpers.Attributes;
    using BootstrapTagHelpers.Extensions;

    using Microsoft.AspNetCore.Razor.TagHelpers;

    [OutputElementHint("div")]
    [RestrictChildren("pane", "pane-group")]
    [ContextClass]
    public class TabsTagHelper : BootstrapTagHelper {
        private int _currentIndex;

        [HtmlAttributeNotBound]
        [HtmlAttributeMinimizable]
        public bool Fade { get; set; }

        [HtmlAttributeMinimizable]
        [HtmlAttributeNotBound]
        public bool Pills { get; set; }

        [HtmlAttributeNotBound]
        public List<TabsPaneTagHelper> Panes { get; set; }=new List<TabsPaneTagHelper>();

        public int ActiveIndex { get; set; } = -1;

        [HtmlAttributeNotBound]
        public int CurrentIndex => this._currentIndex++;

        protected override async Task BootstrapProcessAsync(TagHelperContext context, TagHelperOutput output) {
            await output.GetChildContentAsync();
            output.TagName = "div";
            output.PreContent.AppendHtml($"<ul class=\"nav nav-{(this.Pills? "pills":"tabs")}\" role=\"tablist\">");
            foreach (var pane in this.Panes) {
                output.PreContent.AppendHtml(pane.HeaderHtml);
            }
            output.PreContent.AppendHtml("</ul><div class=\"tab-content\">");
            output.PostContent.AppendHtml("</div>");
        }
    }

}