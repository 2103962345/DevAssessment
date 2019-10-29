using Common.Resx;
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
            
            DisplayName = AppResources.ResourceManager.GetString(displayName,AppResources.Culture);
            NavigationName = navigationName;

        }

        public string DisplayName { get; }

        public string NavigationName { get; }
    }
}
