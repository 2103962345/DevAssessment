using Common.Resx;
using System;

namespace HelpersLibrary
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public sealed class MenuItemAttribute : Attribute
    {
        public MenuItemAttribute(string displayName, string navigationName)
        {
            DisplayName = AppResources.ResourceManager.GetString(displayName, AppResources.Culture);
            NavigationName = navigationName;

        }

        public string DisplayName { get; }

        public string NavigationName { get; }
    }
}
