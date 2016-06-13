using BootstrapTagHelpers.Extensions;

namespace BootstrapTagHelpers.Grid {
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Razor.TagHelpers;

    public abstract class SizedColTagHelper : BootstrapTagHelper {
        protected abstract int Size { get; }
        protected abstract string Type { get; }

        public int Offset { get; set; }

        public int Pull { get; set; }

        public int Push { get; set; }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "div";
            string baseString = "col-" + Type + "-";
            var classes = new List<string> {baseString + Size};
            if (Offset > 0 && Offset <= 12)
                classes.Add(baseString + "offset-" + Offset);
            if (Push > 0 && Push <= 12)
                classes.Add(baseString + "push-" + Push);
            if (Pull > 0 && Pull <= 12)
                classes.Add(baseString + "pull-" + Pull);
            output.AddCssClass(classes);
        }
    }
}