namespace BootstrapTagHelpers {
    using System.ComponentModel;

    public enum Size {
        Default,

        [Description("lg")]
        Large,

        [Description("sm")]
        Small,

        [Description("xs")]
        ExtraSmall
    }
}