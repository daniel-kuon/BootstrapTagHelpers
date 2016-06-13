using BootstrapTagHelpers.Attributes;

namespace BootstrapTagHelpers.ResponsiveUtilities {

    public enum BootstrapResponsiveUtilitiesDisplayMode
    {
        [DisplayValue("block")]
        Block,
        [DisplayValue("inline-block")]
        InlineBlock,
        [DisplayValue("inline")]
        Inline
    }
}