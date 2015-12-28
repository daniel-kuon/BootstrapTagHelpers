using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Razor.TagHelpers;

namespace BootstrapTagHelpers.Extensions {
    public static class TagHelperOutputExtensions {
        /// <summary>
        ///     Adds an attribute to the Attributes collection. Existing Attributes are overwritten.
        /// </summary>
        public static void MergeAttribute(this TagHelperOutput output, string key, object value) {
            if (output.Attributes.ContainsName(key))
                output.Attributes[key].Value = value;
            else
                output.Attributes.Add(key, value);
        }

        /// <summary>
        ///     Adds an aria attribute
        /// </summary>
        /// <param name="name">Name of the attribute. "aria-" is prepended.</param>
        /// <param name="value"></param>
        public static void AddAriaAttribute(this TagHelperOutput output, string name, object value) {
            output.MergeAttribute("aria-" + name, value);
        }

        /// <summary>
        ///     Adds an aria attribute
        /// </summary>
        /// <param name="name">Name of the attribute. "aria-" is prepended.</param>
        /// <param name="value"></param>
        public static void AddDataAttribute(this TagHelperOutput output, string name, object value) {
            output.MergeAttribute("data-" + name, value);
        }

        /// <summary>
        ///     Adds an attribute to the Attributes collection. Existing Attributes are overwritten.
        /// </summary>
        public static void MergeAttribute(this TagHelperOutput output, string key, string value) {
            MergeAttribute(output, key, value, false);
        }

        /// <summary>
        ///     Adds an attribute to the Attributes collection. Existing Attributes are overwritten.
        /// </summary>
        /// <param name="appendText">
        ///     If true value will be added to an existing attribute. If false exiting attributes are
        ///     overwrtitten
        /// </param>
        /// <param name="separator">Is inserted between the old value and the appended value</param>
        public static void MergeAttribute(this TagHelperOutput output, string key, string value, bool appendText) {
            MergeAttribute(output, key, value, appendText, null);
        }

        /// <summary>
        ///     Adds an attribute to the Attributes collection. Existing Attributes are overwritten.
        /// </summary>
        /// <param name="separator">Is inserted between the old value and the appended value</param>
        public static void MergeAttribute(this TagHelperOutput output, string key, string value, string separator) {
            MergeAttribute(output, key, value, separator != null, separator);
        }

        /// <summary>
        ///     Adds an attribute to the Attributes collection. Existing Attributes are overwritten.
        /// </summary>
        /// <param name="appendText">
        ///     If true value will be added to an existing attribute. If false exiting attributes are
        ///     overwrtitten
        /// </param>
        /// <param name="separator">Is inserted between the old value and the appended value</param>
        public static void MergeAttribute(this TagHelperOutput output, string key, string value, bool appendText,
                                          string separator) {
            if (output.Attributes.ContainsName(key))
                if (appendText)
                    output.Attributes[key] = output.Attributes[key] == null
                                                 ? value
                                                 : output.Attributes[key] + separator + value;
                else
                    output.Attributes[key] = value;
            else
                output.Attributes.Add(key, value);
        }

        /// <summary>
        ///     Adds an css class if not already added
        /// </summary>
        public static void AddCssClass(this TagHelperOutput output, string cssClass) {
            AddCssClass(output, new[] {cssClass});
        }

        /// <summary>
        ///     Adds css classes if not already existing
        /// </summary>
        public static void AddCssClass(this TagHelperOutput output, IEnumerable<string> cssClasses) {
            if (output.Attributes.ContainsName("class") && output.Attributes["class"] != null) {
                List<string> classes = output.Attributes["class"].Value.ToString().Split(' ').ToList();
                foreach (string cssClass in cssClasses.Where(cssClass => !classes.Contains(cssClass)))
                    classes.Add(cssClass);
                output.Attributes["class"].Value = classes.Aggregate((s, s1) => s + " " + s1);
            }
            else if (output.Attributes.ContainsName("class"))
                output.Attributes["class"].Value = cssClasses.Aggregate((s, s1) => s + " " + s1);
            else
                output.Attributes.Add("class", cssClasses.Aggregate((s, s1) => s + " " + s1));
        }

        public static void RemoveCssClass(this TagHelperOutput output, string cssClass) {
            if (output.Attributes.ContainsName("class")) {
                List<string> classes = output.Attributes["class"].Value.ToString().Split(' ').ToList();
                classes.Remove(cssClass);
                if (classes.Count == 0)
                    output.Attributes.RemoveAll("class");
                else
                output.Attributes["class"].Value=classes.Aggregate((s, s1) => s + " " + s1);
            }

        }

        /// <summary>
        ///     Adds an style entry
        /// </summary>
        public static void AddCssStyle(this TagHelperOutput output, string name, string value) {
            if (output.Attributes.ContainsName("style"))
                if (string.IsNullOrEmpty(output.Attributes["style"].Value.ToString()))
                    output.Attributes["style"].Value = name + ": " + value + ";";
                else
                    output.Attributes["style"].Value += (output.Attributes["style"].Value.ToString().EndsWith(";")
                                                             ? " "
                                                             : "; ") + name + ": " + value + ";";
            else
                output.Attributes.Add("style", name + ": " + value + ";");
        }
    }
}