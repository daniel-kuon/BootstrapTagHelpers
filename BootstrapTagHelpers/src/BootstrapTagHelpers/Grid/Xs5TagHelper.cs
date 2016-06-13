namespace BootstrapTagHelpers.Grid {
    using Microsoft.AspNetCore.Razor.TagHelpers;

    [OutputElementHint("div")]
    public class Xs5TagHelper : SizedColTagHelper {
        protected override int Size => 5;
        protected override string Type => "xs";
    }
}