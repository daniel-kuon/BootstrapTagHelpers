using Microsoft.AspNet.Razor.TagHelpers;

namespace BootstrapTagHelpers.Grid {
    using System.Collections.Generic;

    public abstract class SizedColTagHelper : BootstrapTagHelper {

        protected abstract int Size { get; }
        protected abstract string Type { get; }

        public int Offset { get; set; }

        public int Pull { get; set; }

        public int Push { get; set; }

        protected override void BootstrapProcess(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "div";
            var baseString = "col-" + this.Type + "-";
            var classes = new List<string> {baseString + this.Size };
            if (this.Offset>0 && this.Offset<=12)
                classes.Add(baseString +"offset-" + this.Offset);
            if (this.Push>0 && this.Push <= 12)
                classes.Add(baseString +"push-" + this.Push);
            if (this.Pull > 0 && this.Pull <= 12)
                classes.Add(baseString +"pull-" + this.Pull);
            output.AddCssClass(classes);
        }

    }
}