using System;

namespace BootstrapTagHelpers.Attributes
{
    public class DisplayValueAttribute : Attribute
    {
        public DisplayValueAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}