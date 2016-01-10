using BootstrapTagHelpers.Forms;
using BootstrapTagHelpers.ListGroup;
using BootstrapTagHelpers.Media;
using BootstrapTagHelpers.Navigation;
using Microsoft.AspNet.Razor.TagHelpers;

namespace BootstrapTagHelpers.Extensions {
    public static class TagHelperContextItemsExtensionMethods {
        private const string ProgressContext = "ProgressContext";

        private const string ButtonToolbarContext = "ButtonToolbarContext";

        private const string ButtonGroupContext = "ButtonGroupContext";

        private const string InputGroupContext = "InputGroupContext";

        private const string InputGroupAddonContext = "InputGroupAddonContext";

        private const string NavContext = "NavContext";

        private const string ListGroupContext = "ListGroupContext";

        private const string MediaListContext = "MediaListContext";

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

        public static bool HasButtonToolbarContext(this TagHelperContext context) {
            return context.Items.ContainsKey(ButtonToolbarContext) &&
                   context.Items[ButtonToolbarContext] is ButtonToolbarTagHelper;
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

        public static bool HasButtonGroupContext(this TagHelperContext context) {
            return context.Items.ContainsKey(ButtonGroupContext) &&
                   context.Items[ButtonGroupContext] is ButtonGroupTagHelper;
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

        public static bool HasInputGroupContext(this TagHelperContext context) {
            return context.Items.ContainsKey(InputGroupContext) &&
                   context.Items[InputGroupContext] is InputGroupTagHelper;
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

        public static bool HasInputGroupAddonContext(this TagHelperContext context) {
            return context.Items.ContainsKey(InputGroupAddonContext) &&
                   context.Items[InputGroupAddonContext] is AddonTagHelper;
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

        public static bool HasNavContext(this TagHelperContext context) {
            return context.Items.ContainsKey(NavContext) &&
                   (context.Items[NavContext] is NavPillsTagHelper || context.Items[NavContext] is NavTabsTagHelper);
        }

        public static void SetNavContext(this TagHelperContext context, NavPillsTagHelper tagHelper) {
            if (context.Items.ContainsKey(NavContext))
                context.Items[NavContext] = tagHelper;
            else
                context.Items.Add(NavContext, tagHelper);
        }

        public static void SetNavContext(this TagHelperContext context, NavTabsTagHelper tagHelper) {
            if (context.Items.ContainsKey(NavContext))
                context.Items[NavContext] = tagHelper;
            else
                context.Items.Add(NavContext, tagHelper);
        }

        public static void RemoveNavContext(this TagHelperContext context) {
            if (context.Items.ContainsKey(NavContext))
                context.SetNavContext((NavPillsTagHelper) null);
        }

        public static bool HasListGroupContext(this TagHelperContext context) {
            return context.Items.ContainsKey(ListGroupContext) && context.Items[ListGroupContext] is ListGroupTagHelper;
        }

        public static void SetListGroupContext(this TagHelperContext context, ListGroupTagHelper tagHelper) {
            if (context.Items.ContainsKey(ListGroupContext))
                context.Items[ListGroupContext] = tagHelper;
            else
                context.Items.Add(ListGroupContext, tagHelper);
        }

        public static void RemoveListGroupContext(this TagHelperContext context) {
            if (context.Items.ContainsKey(ListGroupContext))
                context.SetListGroupContext(null);
        }

        public static ListGroupTagHelper GetListGroupContext(this TagHelperContext context) {
            if (!context.Items.ContainsKey(ListGroupContext))
                return null;
            return context.Items[ListGroupContext] as ListGroupTagHelper;
        }

        public static bool HasMediaListContext(this TagHelperContext context) {
            return context.Items.ContainsKey(MediaListContext) && context.Items[MediaListContext] is MediaListTagHelper;
        }

        public static void SetMediaListContext(this TagHelperContext context, MediaListTagHelper tagHelper) {
            if (context.Items.ContainsKey(MediaListContext))
                context.Items[MediaListContext] = tagHelper;
            else
                context.Items.Add(MediaListContext, tagHelper);
        }

        public static void RemoveMediaListContext(this TagHelperContext context) {
            if (context.Items.ContainsKey(MediaListContext))
                context.SetMediaListContext(null);
        }

        private const string PaginationContext = "PaginationContext";

        public static bool HasPaginationContext(this TagHelperContext context) {
            return context.Items.ContainsKey(PaginationContext) && context.Items[PaginationContext] is PaginationTagHelper;
        }

        public static void SetPaginationContext(this TagHelperContext context, PaginationTagHelper tagHelper) {
            if (context.Items.ContainsKey(PaginationContext))
                context.Items[PaginationContext] = tagHelper;
            else
                context.Items.Add(PaginationContext, tagHelper);
        }

        public static void RemovePaginationContext(this TagHelperContext context) {
            if (context.Items.ContainsKey(PaginationContext))
                context.SetPaginationContext(null);
        }

        public static PaginationTagHelper GetPaginationContext(this TagHelperContext context) {
            if (!context.Items.ContainsKey(PaginationContext))
                return null;
            return context.Items[PaginationContext] as PaginationTagHelper;
        }


    }
}