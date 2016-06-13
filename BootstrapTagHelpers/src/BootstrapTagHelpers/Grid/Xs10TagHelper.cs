namespace BootstrapTagHelpers.Grid {
    using Microsoft.AspNetCore.Razor.TagHelpers;

    [OutputElementHint("div")]
    public class Xs10TagHelper : SizedColTagHelper {
        protected override int Size => 10;
        protected override string Type => "xs";
    }
}