using BootstrapTagHelpers.Extensions;
using Microsoft.AspNet.Razor.TagHelpers;

namespace BootstrapTagHelpers.Forms {
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
        [HtmlAttributeNotBound]
        [HtmlAttributeMinimizable]
        public bool PullLeft { get; set; }

        [HtmlAttributeName(PullRightAttributeName)]
        [HtmlAttributeNotBound]
        [HtmlAttributeMinimizable]
        public bool PullRight { get; set; }

        [HtmlAttributeName(CenterBlockAttributeName)]
        [HtmlAttributeNotBound]
        [HtmlAttributeMinimizable]
        public bool CenterBlock { get; set; }

        [HtmlAttributeName(ClearfixAttributeName)]
        [HtmlAttributeNotBound]
        [HtmlAttributeMinimizable]
        public bool Cleafix { get; set; }

        [HtmlAttributeName(ShowAttributeName)]
        [HtmlAttributeNotBound]
        [HtmlAttributeMinimizable]
        public bool Show { get; set; }

        [HtmlAttributeName(HiddenAttributeName)]
        [HtmlAttributeNotBound]
        [HtmlAttributeMinimizable]
        public bool Hidden { get; set; }

        [HtmlAttributeName(InvisibleAttributeName)]
        [HtmlAttributeNotBound]
        [HtmlAttributeMinimizable]
        public bool Invisible { get; set; }

        [HtmlAttributeName(TextHideAttributeName)]
        [HtmlAttributeNotBound]
        [HtmlAttributeMinimizable]
        public bool TextHide { get; set; }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            if (TextContext != null)
                output.AddCssClass("text-" + TextContext.Value.ToString().ToLower());
            if (BackgroundContext != null)
                output.AddCssClass("bg-" + BackgroundContext.Value.ToString().ToLower());
            if (PullLeft)
                output.AddCssClass("pull-left");
            if (PullRight)
                output.AddCssClass("pull-right");
            if (CenterBlock)
                output.AddCssClass("center-block");
            if (Cleafix)
                output.AddCssClass("clearfix");
            if (Show)
                output.AddCssClass("show");
            if (Hidden)
                output.AddCssClass("hidden");
            if (Invisible)
                output.AddCssClass("invisible");
            if (TextHide)
                output.AddCssClass("text-hide");
        }
    }
}