using BootstrapTagHelpers.Attributes;

namespace BootstrapTagHelpers {
    public enum SimpleSize {
        Default,
        [DisplayValue("lg")]
        Large,
        [DisplayValue("sm")]
        Small
    }
}