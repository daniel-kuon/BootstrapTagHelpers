using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BootstrapTagHelpers.Extensions {

    public static class TagHelperExtensions {

        public static async Task<TagHelperContent> ToTagHelperContentAsync(this ITagHelper tagHelper) {
            return await ToTagHelperContentAsync(tagHelper, (TagHelperContent) null);
        }

        public static async Task<TagHelperContent> ToTagHelperContentAsync(this ITagHelper tagHelper, Options options) {
            if (options.Context == null)
                options.Context = new TagHelperContext(new TagHelperAttributeList(), new Dictionary<object, object>(), Guid.NewGuid().ToString("N"));
            if (options.Attributes == null)
                options.Attributes = new List<TagHelperAttribute>();
            if (options.TagName == null)
                options.TagName = tagHelper.GetTagName();
            var output = new TagHelperOutput(options.TagName, new TagHelperAttributeList(options.Attributes), (b,e) => Task<TagHelperContent>.Factory.StartNew(() => options.Content)) {TagMode = options.TagMode};
            if (options.InitTagHelper)
                tagHelper.Init(options.Context);
            await tagHelper.ProcessAsync(options.Context, output);
            if (options.Content != null && !output.IsContentModified)
                output.Content.SetHtmlContent(options.Content);
            return output.ToTagHelperContent();
        }

        public static async Task<TagHelperContent> ToTagHelperContentAsync(this ITagHelper tagHelper, bool initTagHelper) {
            return await ToTagHelperContentAsync(tagHelper, new Options {InitTagHelper = initTagHelper});
        }

        public static async Task<TagHelperContent> ToTagHelperContentAsync(this ITagHelper tagHelper, TagHelperContent content) {
            return await ToTagHelperContentAsync(tagHelper, new Options {Content = content});
        }

        public static async Task<TagHelperContent> ToTagHelperContentAsync(this ITagHelper tagHelper, string tagName) {
            return await ToTagHelperContentAsync(tagHelper, new Options {TagName = tagName});
        }

        public static async Task<TagHelperContent> ToTagHelperContentAsync(this ITagHelper tagHelper, TagHelperContext context) {
            return await ToTagHelperContentAsync(tagHelper, new Options {Context = context});
        }

        public static async Task<TagHelperContent> ToTagHelperContentAsync(this ITagHelper tagHelper, IEnumerable<TagHelperAttribute> attributes) {
            return await ToTagHelperContentAsync(tagHelper, new Options {Attributes = attributes});
        }

        public static async Task RunTagHelperAsync(this ITagHelper tagHelper) {
             await RunTagHelperAsync(tagHelper, (TagHelperContent) null);
        }

        public static async Task RunTagHelperAsync(this ITagHelper tagHelper, Options options) {
            if (options.Context == null)
                options.Context = new TagHelperContext(new TagHelperAttributeList(), new Dictionary<object, object>(), Guid.NewGuid().ToString("N"));
            if (options.Attributes == null)
                options.Attributes = new List<TagHelperAttribute>();
            if (options.TagName == null)
                options.TagName = tagHelper.GetTagName();
            var output = new TagHelperOutput(options.TagName, new TagHelperAttributeList(options.Attributes), (b,e) => Task.Factory.StartNew(() => options.Content)) {TagMode = options.TagMode};
            if (options.InitTagHelper)
                tagHelper.Init(options.Context);
            await tagHelper.ProcessAsync(options.Context, output);
        }

        public static async Task RunTagHelperAsync(this ITagHelper tagHelper, bool initTagHelper) {
             await RunTagHelperAsync(tagHelper, new Options {InitTagHelper = initTagHelper});
        }

        public static async Task RunTagHelperAsync(this ITagHelper tagHelper, TagHelperContent content) {
             await RunTagHelperAsync(tagHelper, new Options {Content = content});
        }

        public static async Task RunTagHelperAsync(this ITagHelper tagHelper, string tagName) {
             await RunTagHelperAsync(tagHelper, new Options {TagName = tagName});
        }

        public static async Task RunTagHelperAsync(this ITagHelper tagHelper, TagHelperContext context) {
             await RunTagHelperAsync(tagHelper, new Options {Context = context});
        }

        public static async Task RunTagHelperAsync(this ITagHelper tagHelper, IEnumerable<TagHelperAttribute> attributes) {
             await RunTagHelperAsync(tagHelper, new Options {Attributes = attributes});
        }

        public static string GetTagName(this ITagHelper tagHelper) {
            return tagHelper.GetType().GetTypeInfo().GetCustomAttributes<HtmlTargetElementAttribute>().FirstOrDefault(a => a.Tag != "*")?.Tag
                   ?? Regex.Replace(tagHelper.GetType().Name.Replace("TagHelper", ""), "([A-Z])", "-$1").Trim('-').ToLower();
        }

        public static string GetTagName(this IEnumerable<ITagHelper> tagHelpers) {
            var tagHelperList = tagHelpers as IList<ITagHelper> ?? tagHelpers.ToList();
            return
                tagHelperList.OrderBy(tH => tH.Order)
                             .FirstOrDefault(tH => tH.GetType().GetTypeInfo().HasCustomAttribute<HtmlTargetElementAttribute>())?
                             .GetType().GetTypeInfo()
                             .GetCustomAttributes<HtmlTargetElementAttribute>()
                             .FirstOrDefault(a => a.Tag != "*")?.Tag
                ?? Regex.Replace(tagHelperList.Min(tH => tH.Order).GetType().Name.Replace("TagHelper", ""), "([A-Z])", "-$1").Trim('-').ToLower();
        }

        public static async Task<TagHelperContent> ToTagHelperContentAsync(this IEnumerable<ITagHelper> tagHelpers)
        {
            return await ToTagHelperContentAsync(tagHelpers, new Options());
        }

        public static async Task<TagHelperContent> ToTagHelperContentAsync(this IEnumerable<ITagHelper> tagHelpers, TagHelperContent content)
        {
            return await ToTagHelperContentAsync(tagHelpers, new Options { Content = content });
        }

        public static async Task<TagHelperContent> ToTagHelperContentAsync(this IEnumerable<ITagHelper> tagHelpers, string tagName)
        {
            return await ToTagHelperContentAsync(tagHelpers, new Options { TagName = tagName });
        }

        public static async Task<TagHelperContent> ToTagHelperContentAsync(this IEnumerable<ITagHelper> tagHelpers, TagHelperContext context)
        {
            return await ToTagHelperContentAsync(tagHelpers, new Options { Context = context });
        }

        public static async Task<TagHelperContent> ToTagHelperContentAsync(this IEnumerable<ITagHelper> tagHelpers, IEnumerable<TagHelperAttribute> attributes)
        {
            return await ToTagHelperContentAsync(tagHelpers, new Options { Attributes = attributes });
        }

        public static async Task<TagHelperContent> ToTagHelperContentAsync(this IEnumerable<ITagHelper> tagHelpers, bool initTagHelper)
        {
            return await ToTagHelperContentAsync(tagHelpers, new Options { InitTagHelper = initTagHelper });
        }

        public static async Task<TagHelperContent> ToTagHelperContentAsync(this IEnumerable<ITagHelper> tagHelpers, Options options)
        {
            var tagHelperList = tagHelpers as List<ITagHelper> ?? tagHelpers.ToList();
            if (options.Context == null)
                options.Context = new TagHelperContext(new TagHelperAttributeList(), new Dictionary<object, object>(), Guid.NewGuid().ToString("N"));
            if (options.Attributes == null)
                options.Attributes = new List<TagHelperAttribute>();
            if (options.TagName == null)
                options.TagName = tagHelpers.GetTagName();
            var output = new TagHelperOutput(options.TagName, new TagHelperAttributeList(options.Attributes), (b,e) => Task.Factory.StartNew(() => options.Content)) { TagMode = options.TagMode };
            if (options.InitTagHelper)
                tagHelperList.ForEach(tH => tH.Init(options.Context));
            foreach (var tagHelper in tagHelperList)
            {
                await tagHelper.ProcessAsync(options.Context, output);
            }
            if (options.Content != null && !output.IsContentModified)
                output.Content.SetHtmlContent(options.Content);
            return output.ToTagHelperContent();
        }

        public static async Task RunTagHelperAsync(this IEnumerable<ITagHelper> tagHelpers)
        {
             await RunTagHelperAsync(tagHelpers, new Options());
        }

        public static async Task RunTagHelperAsync(this IEnumerable<ITagHelper> tagHelpers, TagHelperContent content)
        {
             await RunTagHelperAsync(tagHelpers, new Options { Content = content });
        }

        public static async Task RunTagHelperAsync(this IEnumerable<ITagHelper> tagHelpers, string tagName)
        {
             await RunTagHelperAsync(tagHelpers, new Options { TagName = tagName });
        }

        public static async Task RunTagHelperAsync(this IEnumerable<ITagHelper> tagHelpers, TagHelperContext context)
        {
             await RunTagHelperAsync(tagHelpers, new Options { Context = context });
        }

        public static async Task RunTagHelperAsync(this IEnumerable<ITagHelper> tagHelpers, IEnumerable<TagHelperAttribute> attributes)
        {
             await RunTagHelperAsync(tagHelpers, new Options { Attributes = attributes });
        }

        public static async Task RunTagHelperAsync(this IEnumerable<ITagHelper> tagHelpers, bool initTagHelper)
        {
             await RunTagHelperAsync(tagHelpers, new Options { InitTagHelper = initTagHelper });
        }

        public static async Task RunTagHelperAsync(this IEnumerable<ITagHelper> tagHelpers, Options options)
        {
            var tagHelperList = tagHelpers as List<ITagHelper> ?? tagHelpers.ToList();
            if (options.Context == null)
                options.Context = new TagHelperContext(new TagHelperAttributeList(), new Dictionary<object, object>(), Guid.NewGuid().ToString("N"));
            if (options.Attributes == null)
                options.Attributes = new List<TagHelperAttribute>();
            if (options.TagName == null)
                options.TagName = tagHelpers.GetTagName();
            var output = new TagHelperOutput(options.TagName, new TagHelperAttributeList(options.Attributes), (b,e) => Task.Factory.StartNew(() => options.Content)) { TagMode = options.TagMode };
            if (options.InitTagHelper)
                tagHelperList.ForEach(tH => tH.Init(options.Context));
            foreach (var tagHelper in tagHelperList)
            {
                await tagHelper.ProcessAsync(options.Context, output);
            }
        }

        public class Options {
            public string TagName { get; set; }

            public TagMode TagMode { get; set; }

            public TagHelperContent Content { get; set; }

            public TagHelperContext Context { get; set; }

            public IEnumerable<TagHelperAttribute> Attributes { get; set; }
            public bool InitTagHelper { get; set; } = true;
        }
    }
}