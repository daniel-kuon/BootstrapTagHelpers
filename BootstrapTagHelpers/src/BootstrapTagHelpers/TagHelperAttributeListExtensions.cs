namespace BootstrapTagHelpers {
    using System.Linq;
    using Microsoft.AspNet.Razor.TagHelpers;

    public static class TagHelperAttributeListExtensions {
        public static bool RemoveAll(this TagHelperAttributeList attributeList, params string[] attributeNames) {
            return attributeNames.Aggregate(false, (current, name) => attributeList.RemoveAll(name) || current);
        }

        public static void AddAriaAttribute(this TagHelperAttributeList attributeList, string attributeName,
                                            object value) {
            attributeList.Add("aria-" + attributeName, value);
        }

        public static void AddDataAttribute(this TagHelperAttributeList attributeList, string attributeName,
                                            object value) {
            attributeList.Add("data-" + attributeName, value);
        }
    }
}