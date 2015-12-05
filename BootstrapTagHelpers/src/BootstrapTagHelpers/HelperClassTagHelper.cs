using Microsoft.AspNet.Razor.TagHelpers;

namespace BootstrapTagHelpers {
    [HtmlTargetElement("*", Attributes = TextContextAttributeName)]
    [HtmlTargetElement("*", Attributes = BackgroundContextAttributeName)]
    [HtmlTargetElement("*", Attributes = PullLeftAttributeName)]
    [HtmlTargetElement("*", Attributes = PullRightAttributeName)]
    [HtmlTargetElement("*", Attributes = CenterBlockAttributeName)]
    [HtmlTargetElement("*", Attributes = ClearfixAttributeName)]
    [HtmlTargetElement("*", Attributes = ShowAttributeName)]
    [HtmlTargetElement("*", Attributes = HiddenAttributeName)]
    [HtmlTargetElement("*", Attributes = InvisibleAttributeName)]
    [HtmlTargetElement("*", Attributes = TextHideAttributeName)]
    public class HelperClassTagHelper : BootstrapTagHelper {
        public enum BackgroundContexts {
            Primary,
            Success,
            Info,
            Warning,
            Danger
        }

        public enum TextContexts {
            Muted,
            Primary,
            Success,
            Info,
            Warning,
            Danger
        }

        public const string TextContextAttributeName = AttributePrefix + "text-context";
        public const string BackgroundContextAttributeName = AttributePrefix + "bg-context";
        public const string PullLeftAttributeName = AttributePrefix + "pull-left";
        public const string PullRightAttributeName = AttributePrefix + "pull-right";
        public const string CenterBlockAttributeName = AttributePrefix + "center-block";
        public const string ClearfixAttributeName = AttributePrefix + "clearfix";
        public const string ShowAttributeName = AttributePrefix + "show";
        public const string HiddenAttributeName = AttributePrefix + "hidden";
        public const string InvisibleAttributeName = AttributePrefix + "invisible";
        public const string TextHideAttributeName = AttributePrefix + "text-hide";

        [HtmlAttributeName(TextContextAttributeName)]
        public TextContexts? TextContext { get; set; }

        [HtmlAttributeName(BackgroundContextAttributeName)]
        public BackgroundContexts? BackgroundContext { get; set; }

        [HtmlAttributeName(PullLeftAttributeName)]
        public bool PullLeft { get; set; }

        [HtmlAttributeName(PullRightAttributeName)]
        public bool PullRight { get; set; }

        [HtmlAttributeName(CenterBlockAttributeName)]
        public bool CenterBlock { get; set; }

        [HtmlAttributeName(ClearfixAttributeName)]
        public bool Cleafix { get; set; }

        [HtmlAttributeName(ShowAttributeName)]
        public bool Show { get; set; }

        [HtmlAttributeName(HiddenAttributeName)]
        public bool Hidden { get; set; }

        [HtmlAttributeName(InvisibleAttributeName)]
        public bool Invisible { get; set; }

        [HtmlAttributeName(TextHideAttributeName)]
        public bool TextHide { get; set; }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            if (this.TextContext!=null)
                output.AddCssClass("text-" + this.TextContext.Value.ToString().ToLower());
            if (this.BackgroundContext!=null)
                output.AddCssClass("bg-" + this.BackgroundContext.Value.ToString().ToLower());
            if (context.IsSet(()=>this.PullLeft))
                output.AddCssClass("pull-left");
            if (context.IsSet(()=>this.PullRight))
                output.AddCssClass("pull-right");
            if (context.IsSet(()=>this.CenterBlock))
                output.AddCssClass("center-block");
            if (context.IsSet(()=>this.Cleafix))
                output.AddCssClass("clearfix");
            if (context.IsSet(()=>this.Show))
                output.AddCssClass("show");
            if (context.IsSet(()=>this.Hidden))
                output.AddCssClass("hidden");
            if (context.IsSet(()=>this.Invisible))
                output.AddCssClass("invisible");
            if (context.IsSet(()=>this.TextHide))
                output.AddCssClass("text-hide");
        }
    }
}