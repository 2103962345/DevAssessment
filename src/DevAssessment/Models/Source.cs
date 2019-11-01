using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevAssessment.Models
{
    public class Source : BindableBase
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public string category { get; set; }
        public string language { get; set; }
        public string country { get; set; }

        private bool _listToggleItem;

        public bool ListToggleItem
        {
            get { return _listToggleItem; }
            set { SetProperty(ref _listToggleItem, value); }
        }

    }
}
