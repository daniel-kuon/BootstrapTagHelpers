namespace BootstrapTagHelpers.Grid {
    using Microsoft.AspNet.Razor.TagHelpers;

    [OutputElementHint("div")]
    public class Xs11TagHelper : SizedColTagHelper {
        protected override int Size => 11;
        protected override string Type => "xs";
    }
}