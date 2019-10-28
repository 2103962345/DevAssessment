using DevAssessment.Attributes;
using DevAssessment.Models;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DevAssessment.Services
{
    public class MenuService : IMenuService
    {
        public MenuService()
        {
            IEnumerable<MenuItemAttribute> menuItemAttributes = GetType().Assembly.GetCustomAttributes<MenuItemAttribute>();
            var categoryList = new List<Item>();

            categoryList = menuItemAttributes.Select(x => new Item()
              {
                  Name = x.DisplayName,
                  Uri = x.NavigationName
              }).OrderBy(x => x.Name).ToList();


            Items = categoryList;
        }

        public List<Item> Items { get; set; }
    }
}

