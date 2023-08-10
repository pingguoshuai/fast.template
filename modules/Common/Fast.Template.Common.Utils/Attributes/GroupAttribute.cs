using System;

namespace Fast.Template.Common.Utils.Attributes
{
    public class GroupAttribute : Attribute
    {
        public string Name { get; set; }
        public GroupAttribute(string name)
        {
            Name = name;
        }
    }
}
