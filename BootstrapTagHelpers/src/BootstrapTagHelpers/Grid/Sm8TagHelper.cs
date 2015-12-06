namespace BootstrapTagHelpers.Grid {
    using Microsoft.AspNet.Razor.TagHelpers;

    [OutputElementHint("div")]
    public class Sm8TagHelper : SizedColTagHelper {
        protected override int Size => 8;
        protected override string Type => "sm";
    }
}