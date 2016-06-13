using System.Threading.Tasks;

using BootstrapTagHelpers.Attributes;
using BootstrapTagHelpers.Extensions;

using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BootstrapTagHelpers.Tabs {

    [HtmlTargetElement("pane", ParentTag = "tabs")]
    [HtmlTargetElement("pane", ParentTag = "pane-group")]
    [ContextClass]
    public class TabsPaneTagHelper : BootstrapTagHelper {

        [HtmlAttributeNotBound]
        public string HeaderHtml { get; set; }

        public string Header { get; set; }

        [HtmlAttributeNotBound]
        [HtmlAttributeMinimizable]
        public bool Active { get; set; }

        [AutoGenerateId]
        [CopyToOutput]
        public string Id { get; set; }

        protected override bool CopyAttributesIfBootstrapIsDisabled => true;

        [Context]
        protected TabsTagHelper TabsContext { get; set; }

        [HtmlAttributeNotBound]
        protected string DataToggleTarget { get; set; }

        public override void Init(TagHelperContext context) {
            base.Init(context);
            if (this.TabsContext.ActiveIndex == this.TabsContext.CurrentIndex)
                this.Active = true;
            if (context.HasContextItem<TabsPaneGroupTagHelper>()) {
                var paneGroupContext = context.GetContextItem<TabsPaneGroupTagHelper>();
                paneGroupContext.Panes.Add(this);
                if (this.Active)
                    paneGroupContext.Active = true;
            } else
                this.TabsContext.Panes.Add(this);
            this.DataToggleTarget = this.TabsContext.Pills ? "pill" : "tab";
        }

        protected override async Task BootstrapProcessAsync(TagHelperContext context, TagHelperOutput output) {
            await output.GetChildContentAsync();
            if (string.IsNullOrEmpty(this.HeaderHtml))
                this.HeaderHtml = this.Header;
            this.WrapHeaderHtml();
            output.TagName = "div";
            output.Attributes.Add("role", "tabpanel");
            output.AddCssClass("tab-pane");
            if (this.Active)
                output.AddCssClass("active");
            if (this.TabsContext.Fade) {
                output.AddCssClass("fade");
                if (this.Active)
                    output.AddCssClass("in");
            }
        }

        public virtual void WrapHeaderHtml() {
            this.HeaderHtml = this.Active
                                  ? $"<li role=\"presentation\" class=\"active\"><a href=\"#{this.Id}\" aria-controls=\"{this.Id}\" role=\"tab\" data-toggle=\"{(this.TabsContext.Pills ? "pill" : "tab")}\">{this.HeaderHtml}</a></li>"
                                  : $"<li role=\"presentation\"><a href=\"#{this.Id}\" aria-controls=\"{this.Id}\" role=\"tab\" data-toggle=\"{(this.TabsContext.Pills ? "pill" : "tab")}\">{this.HeaderHtml}</a></li>";
        }
    }
}