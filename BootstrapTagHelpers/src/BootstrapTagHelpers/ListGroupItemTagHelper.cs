using BootstrapTagHelpers.Extensions;
using Microsoft.AspNet.Razor.TagHelpers;

namespace BootstrapTagHelpers {
    [HtmlTargetElement("list-group-item", ParentTag = "list-group")]
    [OutputElementHint("li")]
    public class ListGroupItemTagHelper : BootstrapTagHelper {
        public ListGroupContext? Context { get; set; }

        [HtmlAttributeNotBound]
        public ListGroupTagHelper ListGroupContext { get; set; }

        public string BadgeText { get; set; }

        [HtmlAttributeNotBound]
        [HtmlAttributeMinimizable]
        public bool Active { get; set; }

        [HtmlAttributeNotBound]
        [HtmlAttributeMinimizable]
        public bool Disabled { get; set; }

        public override void Init(TagHelperContext context) {
            base.Init(context);
            ListGroupContext = context.GetListGroupContext();
            if (Context == null)
                Context = ListGroupContext.Context;
        }


        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            if (ListGroupContext.ChildDetectionMode)
                output.SuppressOutput();
            else
                RenderOutput(output);
        }

        protected virtual void RenderOutput(TagHelperOutput output) {
            output.TagName = GetTagName();
            output.AddCssClass("list-group-item");
            if (!string.IsNullOrEmpty(BadgeText))
                output.PostContent.PrependHtml($"<span class=\"badge\">{BadgeText}</span>");
            if (Context != null)
                output.AddCssClass("list-group-item-" + Context.ToString().ToLower());
            if (Active)
                output.AddCssClass("active");
            if (Disabled)
                output.AddCssClass("disabled");
        }

        protected virtual string GetTagName() {
            return ListGroupContext.RenderAsDiv ? "div" : "li";
        }
    }
}