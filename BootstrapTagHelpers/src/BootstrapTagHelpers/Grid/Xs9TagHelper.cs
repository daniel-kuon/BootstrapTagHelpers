namespace BootstrapTagHelpers.Grid {
    using Microsoft.AspNet.Razor.TagHelpers;

    [OutputElementHint("div")]
    public class Xs9TagHelper : SizedColTagHelper {
        protected override int Size => 9;
        protected override string Type => "xs";
    }
}