using DevAssessment.Attributes;
using DevAssessment.Models;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using DevAssessment.Auth;
using Prism.Modularity;

namespace DevAssessment.Services
{
    public class MenuService : IMenuService
    {
        public MenuService()
        {

            IEnumerable<HelpersLibrary.MenuItemAttribute> menuItemAttributes = GetType().Assembly.GetCustomAttributes<HelpersLibrary.MenuItemAttribute>();

            var itemList = new List<Item>();

            itemList = menuItemAttributes.Select(x => new Item()
            {
                Name = x.DisplayName,
                Uri = x.NavigationName
            }).ToList();

            if(itemList.Count > 0)
                Items = new List<Item>(itemList);
        }


        public List<Item> Items { get; set; }


    }
}

