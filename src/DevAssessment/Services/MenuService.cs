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
        private readonly IModuleManager _moduleManager;


        public MenuService(IModuleManager moduleManager, IModuleCatalog moduleCatalog)
        {
            _moduleManager = moduleManager;

            IEnumerable<Attributes.MenuItemAttribute> menuItemAttributes = GetType().Assembly.GetCustomAttributes<Attributes.MenuItemAttribute>();

            var categoryList = new List<Item>();

            categoryList = menuItemAttributes.Select(x => new Item()
            {
                Name = x.DisplayName,
                Uri = x.NavigationName
            }).OrderBy(x => x.Name).ToList();


            if (Application.Current.Properties.ContainsKey(Constants.IsAdmin) && (bool)Application.Current.Properties[Constants.IsAdmin])
            {
                //loading admin module here,,

                _moduleManager.LoadModule("AdminModule");

                categoryList.Insert(0, new Item() { Name = "Admin", Uri = "AdminPage" });
            }

            Items = categoryList;
        }


        public List<Item> Items { get; set; }

      
    }
}

