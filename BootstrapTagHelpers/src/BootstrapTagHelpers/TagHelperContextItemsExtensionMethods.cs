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
    }
}