namespace BootstrapTagHelpers.Extensions {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Razor.TagHelpers;

    public static class TagHelperExtensions {

        public static TagHelperContent ToTagHelperContent(this TagHelper tagHelper) {
            return ToTagHelperContent(tagHelper, (TagHelperContent) null);
        }

        public static TagHelperContent ToTagHelperContent(this TagHelper tagHelper, TagHelperContent content) {
            return ToTagHelperContent(tagHelper, tagHelper.GetTagName(), content);
        }

        public static TagHelperContent ToTagHelperContent(this TagHelper tagHelper, IEnumerable<TagHelperContent> contents) {
            var content = new DefaultTagHelperContent();
            foreach (var tagHelperContent in contents) {
                content.Append(tagHelperContent);
            }
            return ToTagHelperContent(tagHelper, tagHelper.GetTagName(), content);
        }

        public static TagHelperContent ToTagHelperContent(this TagHelper tagHelper, string tagName, IEnumerable<TagHelperContent> contents) {
            var content = new DefaultTagHelperContent();
            foreach (var tagHelperContent in contents) {
                content.Append(tagHelperContent);
            }
            return ToTagHelperContent(tagHelper, tagName, content);
        }

        public static TagHelperContent ToTagHelperContent(this TagHelper tagHelper, TagHelper content) {
            return ToTagHelperContent(tagHelper, tagHelper.GetTagName(), content.ToTagHelperContent());
        }

        public static TagHelperContent ToTagHelperContent(this TagHelper tagHelper, IEnumerable<TagHelper> contents) {
            var content = new DefaultTagHelperContent();
            foreach (var tagHelperContent in contents) {
                content.Append(tagHelperContent.ToTagHelperContent());
            }
            return ToTagHelperContent(tagHelper, tagHelper.GetTagName(), content);
        }

        public static TagHelperContent ToTagHelperContent(this TagHelper tagHelper, string tagName, IEnumerable<TagHelper> contents) {
            var content = new DefaultTagHelperContent();
            foreach (var tagHelperContent in contents) {
                content.Append(tagHelperContent.ToTagHelperContent());
            }
            return ToTagHelperContent(tagHelper, tagName, content);
        }

        public static TagHelperContent ToTagHelperContent(this TagHelper tagHelper, string tagName, TagHelperContent content) {
            var context = new TagHelperContext(new List<IReadOnlyTagHelperAttribute>(), new Dictionary<object, object>(), Guid.NewGuid().ToString("N"));
            var output = new TagHelperOutput(tagName, new TagHelperAttributeList(), b => new Task<TagHelperContent>(() => content));
            tagHelper.Process(context, output);
            return output.ToTagHelperContent();
        }

        public static string GetTagName(this ITagHelper tagHelper) {
            return tagHelper.GetType().GetCustomAttributes<HtmlTargetElementAttribute>().FirstOrDefault(a => a.Tag != "*")?.Tag
                   ?? Regex.Replace(tagHelper.GetType().Name.Replace("TagHelper", ""), "([A-Z])", "-$1").Trim('-').ToLower();
        }
    }
}