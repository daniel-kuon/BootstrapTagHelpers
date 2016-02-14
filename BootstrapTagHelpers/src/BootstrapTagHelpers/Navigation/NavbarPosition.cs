namespace BootstrapTagHelpers.Navigation {
    using System.ComponentModel;

    public enum NavbarPosition {
        [Description("navbar-fixed-top")]
        FixedTop,

        [Description("navbar-fixed-bottom")]
        FixedBottom,

        [Description("navbar-static-top")]
        StaticTop,

        [Description("navbar-static-bottom")]
        StaticBottom
    }
}