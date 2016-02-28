namespace BootstrapTagHelpers {
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BootstrapTagHelpers.Attributes;
    using BootstrapTagHelpers.Extensions;

    using Microsoft.AspNet.Mvc.Rendering;
    using Microsoft.AspNet.Razor.TagHelpers;

    [OutputElementHint("div")]
    [RestrictChildren("carousel-item")]
    [ContextClass]
    public class CarouselTagHelper : BootstrapTagHelper {
        private int _itemIndex;

        public int? ActiveIndex { get; set; }

        protected override bool CopyAttributesIfBootstrapIsDisabled => true;

        [CopyToOutput]
        public string Id { get; set; }

        [HtmlAttributeNotBound]
        private List<CarouselItemTagHelper> Items { get; } = new List<CarouselItemTagHelper>();

        [CopyToOutput(Prefix = "data-")]
        public int? Interval { get; set; }

        [CopyToOutput(Prefix = "data-")]
        public string Pause { get; set; }

        [HtmlAttributeMinimizable]
        [HtmlAttributeNotBound]
        [CopyToOutput(Prefix = "data-")]
        public bool? Wrap { get; set; }

        [CopyToOutput(Prefix = "data-")]
        [HtmlAttributeNotBound]
        [HtmlAttributeMinimizable]
        public bool? Keyboard { get; set; }

        public void AddItem(CarouselItemTagHelper item) {
            Items.Add(item);
            if (_itemIndex++ == ActiveIndex)
                item.IsActive = true;
        }

        protected override async Task BootstrapProcessAsync(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "div";
            output.AddCssClass("carousel");
            output.AddCssClass("slide");
            output.Attributes.AddDataAttribute("ride", "carousel");
            output.PreContent.AppendHtml("<ol class=\"carousel-indicators\">");
            output.Content.SetContent(await output.GetChildContentAsync());
            if (!Items.Any(i => i.IsActive)) {
                _itemIndex = 0;
                Items.Clear();
                ActiveIndex = 0;
                output.Content.SetContent(await output.GetChildContentAsync(false));
            }
            for (var i = 0; i < Items.Count; i++) {
                var item = Items[i];
                output.PreContent.AppendHtml(
                                             item.IsActive
                                                 ? $"<li data-target=\"#{Id}\" data-slide-to=\"{i}\" class=\"active\"></li>"
                                                 : $"<li data-target=\"#{Id}\" data-slide-to=\"{i}\"></li>");
            }
            output.PreContent.AppendHtml("</ol>");
            output.Content.Wrap(new TagBuilder("div") {Attributes = { {"class","carousel-inner"}, {"role","listbox"} }});
            output.PostContent.AppendHtml(
                                          $"<a class=\"left carousel-control\" href=\"#{Id}\" role=\"button\" data-slide=\"prev\"><span class=\"glyphicon glyphicon-chevron-left\" aria-hidden=\"true\"></span><span class=\"sr-only\">{Ressources.Previous}</span></a><a class=\"right carousel-control\" href=\"#{Id}\" role=\"button\" data-slide=\"next\"><span class=\"glyphicon glyphicon-chevron-right\" aria-hidden=\"true\"></span><span class=\"sr-only\">{Ressources.Next}</span></a>");
        }
    }
}