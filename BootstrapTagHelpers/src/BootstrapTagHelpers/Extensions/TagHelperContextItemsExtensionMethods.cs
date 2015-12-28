using BootstrapTagHelpers.Forms;
using BootstrapTagHelpers.Navigation;
using Microsoft.AspNet.Razor.TagHelpers;

namespace BootstrapTagHelpers.Extensions {
    public static class TagHelperContextItemsExtensionMethods {
        private const string ProgressContext = "ProgressContext";

        public static bool HasProgressContext(this TagHelperContext context) {
            return context.Items.ContainsKey(ProgressContext) && context.Items[ProgressContext] is ProgressTagHelper;
        }

        public static void SetProgressContext(this TagHelperContext context, ProgressTagHelper tagHelper) {
            if (context.Items.ContainsKey(ProgressContext))
                context.Items[ProgressContext] = tagHelper;
            else
                context.Items.Add(ProgressContext, tagHelper);
        }

        public static void RemoveProgressContext(this TagHelperContext context) {
            if (context.Items.ContainsKey(ProgressContext))
                context.SetProgressContext(null);
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

        public static void RemoveButtonToolbarContext(this TagHelperContext context) {
            if (context.Items.ContainsKey(ButtonToolbarContext))
                context.SetButtonToolbarContext(null);
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

        public static void RemoveButtonGroupContext(this TagHelperContext context) {
            if (context.Items.ContainsKey(ButtonGroupContext))
                context.SetButtonGroupContext(null);
        }

        public static ButtonGroupTagHelper GetButtonGroupContext(this TagHelperContext context) {
            if (!context.Items.ContainsKey(ButtonGroupContext))
                return null;
            return context.Items[ButtonGroupContext] as ButtonGroupTagHelper;
        }

        private const string InputGroupContext = "InputGroupContext";

        public static bool HasInputGroupContext(this TagHelperContext context) {
            return context.Items.ContainsKey(InputGroupContext) && context.Items[InputGroupContext] is InputGroupTagHelper;
        }

        public static void SetInputGroupContext(this TagHelperContext context, InputGroupTagHelper tagHelper) {
            if (context.Items.ContainsKey(InputGroupContext))
                context.Items[InputGroupContext] = tagHelper;
            else
                context.Items.Add(InputGroupContext, tagHelper);
        }

        public static void RemoveInputGroupContext(this TagHelperContext context) {
            if (context.Items.ContainsKey(InputGroupContext))
                context.SetInputGroupContext(null);
        }

        public static InputGroupTagHelper GetInputGroupContext(this TagHelperContext context) {
            if (!context.Items.ContainsKey(InputGroupContext))
                return null;
            return context.Items[InputGroupContext] as InputGroupTagHelper;
        }

        private const string InputGroupAddonContext = "InputGroupAddonContext";

        public static bool HasInputGroupAddonContext(this TagHelperContext context) {
            return context.Items.ContainsKey(InputGroupAddonContext) && context.Items[InputGroupAddonContext] is AddonTagHelper;
        }

        public static void SetInputGroupAddonContext(this TagHelperContext context, AddonTagHelper tagHelper) {
            if (context.Items.ContainsKey(InputGroupAddonContext))
                context.Items[InputGroupAddonContext] = tagHelper;
            else
                context.Items.Add(InputGroupAddonContext, tagHelper);
        }

        public static void RemoveInputGroupAddonContext(this TagHelperContext context) {
            if (context.Items.ContainsKey(InputGroupAddonContext))
                context.SetInputGroupAddonContext(null);
        }

        public static AddonTagHelper GetInputGroupAddonContext(this TagHelperContext context) {
            if (!context.Items.ContainsKey(InputGroupAddonContext))
                return null;
            return context.Items[InputGroupAddonContext] as AddonTagHelper;
        }




    }
}