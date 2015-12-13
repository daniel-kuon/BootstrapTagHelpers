namespace BootstrapTagHelpers {
    using Microsoft.AspNet.Razor.TagHelpers;

    public static class TagHelperContextItemsExtensionMethods {
        private const string ProgressContext = "ProgressContext";

        public static bool HasProgressContext(this TagHelperContext context) {
            return context.Items.ContainsKey(ProgressContext) && context.Items[ProgressContext] is ProgressTagHelper;
        }

        public static void SetProgressContext(this TagHelperContext context, ProgressTagHelper progressTagHelper) {
            if (context.Items.ContainsKey(ProgressContext))
                context.Items[ProgressContext] = progressTagHelper;
            else
                context.Items.Add(ProgressContext, progressTagHelper);
        }

        public static ProgressTagHelper GetProgressContext(this TagHelperContext context) {
            if (!context.Items.ContainsKey(ProgressContext))
                return null;
            return context.Items[ProgressContext] as ProgressTagHelper;
        }

        private const string ButtonToolbarContext = "ButtonToolbarContext";

        public static bool HasButtonToolbarContext(this TagHelperContext context) {
            return context.Items.ContainsKey(ButtonToolbarContext) && context.Items[ButtonToolbarContext] is ButtonToolbarTagHelper;
        }

        public static void SetButtonToolbarContext(this TagHelperContext context, ButtonToolbarTagHelper tagHelper) {
            if (context.Items.ContainsKey(ButtonToolbarContext))
                context.Items[ButtonToolbarContext] = tagHelper;
            else
                context.Items.Add(ButtonToolbarContext, tagHelper);
        }

        public static ButtonToolbarTagHelper GetButtonToolbarContext(this TagHelperContext context) {
            if (!context.Items.ContainsKey(ButtonToolbarContext))
                return null;
            return context.Items[ButtonToolbarContext] as ButtonToolbarTagHelper;
        }

        private const string ButtonGroupContext = "ButtonGroupContext";

        public static bool HasButtonGroupContext(this TagHelperContext context) {
            return context.Items.ContainsKey(ButtonGroupContext) && context.Items[ButtonGroupContext] is ButtonGroupTagHelper;
        }

        public static void SetButtonGroupContext(this TagHelperContext context, ButtonGroupTagHelper tagHelper) {
            if (context.Items.ContainsKey(ButtonGroupContext))
                context.Items[ButtonGroupContext] = tagHelper;
            else
                context.Items.Add(ButtonGroupContext, tagHelper);
        }

        public static ButtonGroupTagHelper GetButtonGroupContext(this TagHelperContext context) {
            if (!context.Items.ContainsKey(ButtonGroupContext))
                return null;
            return context.Items[ButtonGroupContext] as ButtonGroupTagHelper;
        }


    }
}