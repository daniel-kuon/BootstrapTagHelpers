namespace BootstrapTagHelpers {
    using System.ComponentModel;

    public enum InputGroupSize {
        Default,
        [Description("lg")]
        Large,
        [Description("sm")]
        Small
    }
}