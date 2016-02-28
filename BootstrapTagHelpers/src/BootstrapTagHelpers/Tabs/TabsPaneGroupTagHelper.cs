using BootstrapTagHelpers.Attributes;

namespace BootstrapTagHelpers.Tabs {
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BootstrapTagHelpers.Extensions;

    using Microsoft.AspNet.Razor.TagHelpers;

    [RestrictChildren("pane", "header")]
    [HtmlTargetElement("pane-group", ParentTag = "tabs")]
    [ContextClass]
    public class TabsPaneGroupTagHelper : TabsPaneTagHelper {
        public List<TabsPaneTagHelper> Panes { get; set; }=new List<TabsPaneTagHelper>();

        public override void Init(TagHelperContext context) {
            base.Init(context);
            this.TabsContext.ActiveIndex++;
        }

        protected override async Task BootstrapProcessAsync(TagHelperContext context, TagHelperOutput output) {
            await base.BootstrapProcessAsync(context, output);
            output.TagName = null;
        }

        public override void WrapHeaderHtml() {
            this.HeaderHtml = this.Active
                             ? $"<li role=\"presentation\" class=\"dropdown active\"><a href=\"#\" id=\"{this.Id}\" class=\"dropdown-toggle\" data-toggle=\"dropdown\" aria-controls=\"{this.Id}-contents\" aria-expanded=\"false\">{this.HeaderHtml} <span class=\"caret\"></span></a>"
                             : $"<li role=\"presentation\" class=\"dropdown\"><a href=\"#\" id=\"{this.Id}\" class=\"dropdown-toggle\" data-toggle=\"dropdown\" aria-controls=\"{this.Id}-contents\" aria-expanded=\"false\">{this.HeaderHtml} <span class=\"caret\"></span></a>";
            this.HeaderHtml += $"<ul class=\"dropdown-menu\" aria-labelledby=\"{this.Id}\" id=\"{this.Id}-contents\">";
            foreach (var pane in this.Panes) {
                this.HeaderHtml += pane.HeaderHtml;
            }
            this.HeaderHtml += "</ul></li>";
        }
    }
}