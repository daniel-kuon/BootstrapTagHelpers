using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BootstrapTagHelpers.Attributes;
using BootstrapTagHelpers.Extensions;

using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BootstrapTagHelpers {

    [OutputElementHint("nav")]
    [RestrictChildren("item")]
    [ContextClass]
    public class PaginationTagHelper : BootstrapTagHelper {
        public PaginationTagHelper(IActionContextAccessor actionContextAccessor) {
            CurrentUrl = actionContextAccessor.ActionContext.HttpContext.Request.GetDisplayUrl();
        }

        public string NextHref { get; set; }
        public string PrevHref { get; set; }

        [HtmlAttributeNotBound]
        public string CurrentUrl { get; set; }

        [HtmlAttributeMinimizable]
        [HtmlAttributeNotBound]
        public bool? DisablePrev { get; set; }

        public string PrevText { get; set; }

        [HtmlAttributeMinimizable]
        [HtmlAttributeNotBound]
        public bool? DisableNext { get; set; }

        public string NextText { get; set; }

        [HtmlAttributeMinimizable]
        [HtmlAttributeNotBound]
        public bool DisableAutoActive { get; set; }

        public SimpleSize Size { get; set; }

        public int MaxDisplayedItems { get; set; }

        [HtmlAttributeNotBound]
        public List<PaginationItemTagHelper> Items { get; set; } = new List<PaginationItemTagHelper>();

        [HtmlAttributeNotBound]
        public bool ChildDetectionMode { get; set; }

        protected override async Task BootstrapProcessAsync(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "nav";
            output.PreContent.AppendHtml(
                                         Size == SimpleSize.Default
                                             ? "<ul class=\"pagination\">"
                                             : $"<ul class=\"pagination pagination-{Size.GetDescription()}\">");
            ChildDetectionMode = true;
            await output.GetChildContentAsync(true);
            ChildDetectionMode = false;
            if (!DisableAutoActive && Items.TrueForAll(pI => !pI.Active)) {
                var activeItem = Items.FirstOrDefault(ItemHasCurrentUrl);
                if (activeItem != null)
                    activeItem.Active = true;
            }
            for (var i = 0; i < Items.Count; i++)
                if (string.IsNullOrEmpty(Items[i].Content))
                    Items[i].Content = (i + 1).ToString();
            if (Items.Any(pI => pI.Active)) {
                if (PrevHref == null)
                    PrevHref = Items.TakeWhile(pI => !pI.Active).LastOrDefault(pI => !pI.Disabled)?.Href;
                if (NextHref == null)
                    NextHref = Items.SkipWhile(pI => !pI.Active).Skip(1).FirstOrDefault(pI => !pI.Disabled)?.Href;
            }
            DisableNext = NextHref == null || DisableNext.HasValue && DisableNext.Value == false;
            DisablePrev = PrevHref == null || DisablePrev.HasValue && DisablePrev.Value == false;
            output.PreContent.AppendHtml(
                                         PaginationItemTagHelper.RenderItemTag(
                                                                               "<span aria-hidden=\"true\">&laquo;</span>",
                                                                               PrevHref, DisablePrev.Value, false,
                                                                               PrevText ?? Ressources.Previous));
            output.PostContent.AppendHtml(
                                          PaginationItemTagHelper.RenderItemTag(
                                                                                "<span aria-hidden=\"true\">&raquo;</span>",
                                                                                NextHref, DisableNext.Value, false,
                                                                                NextText ?? Ressources.Next));
            if (MaxDisplayedItems > 0 && Items.Count > MaxDisplayedItems)
                if (Items.Any(pI => pI.Active)) {
                    MaxDisplayedItems--;
                    var itemsBeforeActive =
                        Items.TakeWhile(pI => !pI.Active).Reverse().ToList();
                    var itemsAfterActive = Items.SkipWhile(pI => !pI.Active).Skip(1).ToList();
                    var itemsCountBeforeActive = (int) Math.Floor((decimal) MaxDisplayedItems / 2);
                    var itemsCountAfterActive = (int) Math.Ceiling((decimal) MaxDisplayedItems / 2);
                    if (itemsCountAfterActive > itemsAfterActive.Count)
                        itemsCountBeforeActive += itemsCountAfterActive - itemsAfterActive.Count;
                    else if (itemsCountBeforeActive > itemsBeforeActive.Count)
                        itemsCountAfterActive += itemsCountBeforeActive - itemsBeforeActive.Count;
                    foreach (var item in itemsBeforeActive.Skip(itemsCountBeforeActive))
                        item.RenderOutput = false;
                    foreach (var item in itemsAfterActive.Skip(itemsCountAfterActive))
                        item.RenderOutput = false;
                } else
                    foreach (var item in Items.Skip(MaxDisplayedItems))
                        item.RenderOutput = false;
            foreach (var item in Items.Where(pI => pI.RenderOutput))
                output.Content.AppendHtml(PaginationItemTagHelper.RenderItemTag(item));
        }

        private bool ItemHasCurrentUrl(PaginationItemTagHelper item) {
            ;
            return CurrentUrl.EndsWith("/" + item.Href.Trim('/'), StringComparison.CurrentCultureIgnoreCase) ||
                   CurrentUrl.Equals(item.Href, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}