using System.ComponentModel.DataAnnotations;
using BootstrapTagHelpers.Attributes;

namespace BootstrapTagHelpers {

    public enum Size
    {
        Default,

        [DisplayValue("lg")]

Large,

        [DisplayValue("sm")]
        Small,

        [DisplayValue("xs")]
        ExtraSmall
    }
}