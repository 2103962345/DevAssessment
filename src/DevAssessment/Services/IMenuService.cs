using DevAssessment.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DevAssessment.Services
{
    public interface IMenuService
    {
        List<Item> Items { get; set; }
    }
}
