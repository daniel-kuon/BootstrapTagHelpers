namespace BootstrapTagHelpers.Grid {
    using Microsoft.AspNetCore.Razor.TagHelpers;

    [OutputElementHint("div")]
    public class Xs2TagHelper : SizedColTagHelper {
        protected override int Size => 2;
        protected override string Type => "xs";
    }
}