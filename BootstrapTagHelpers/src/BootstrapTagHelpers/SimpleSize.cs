using System.ComponentModel;

namespace BootstrapTagHelpers {
    public enum SimpleSize {
        Default,
        [Description("lg")]
        Large,
        [Description("sm")]
        Small
    }
}