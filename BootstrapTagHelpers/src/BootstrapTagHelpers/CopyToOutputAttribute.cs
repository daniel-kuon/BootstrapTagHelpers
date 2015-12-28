using System;

namespace BootstrapTagHelpers {
    /// <summary>
    /// Properties marked with this Attribute will be automatically copied to the output of the TagHelper
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class CopyToOutputAttribute : Attribute {
    }
}