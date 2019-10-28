using System;
using System.Collections.Generic;
using System.Text;

namespace DevAssessment.Attributes
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    internal sealed class MenuItemAttribute : Attribute
    {
        public MenuItemAttribute(string displayName, string navigationName)
        {
            DisplayName = displayName;
            NavigationName = navigationName;

        }

        public string DisplayName { get; }

        public string NavigationName { get; }
    }
}
