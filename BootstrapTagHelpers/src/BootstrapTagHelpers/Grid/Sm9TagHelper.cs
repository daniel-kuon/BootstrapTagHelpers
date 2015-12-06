namespace BootstrapTagHelpers.Grid {
    using Microsoft.AspNet.Razor.TagHelpers;

    [OutputElementHint("div")]
    public class Sm9TagHelper : SizedColTagHelper {
        protected override int Size => 9;
        protected override string Type => "sm";
    }
}