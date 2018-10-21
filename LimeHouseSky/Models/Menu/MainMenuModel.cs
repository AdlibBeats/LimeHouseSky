using LimeHouseSky.Extensions;
using LimeHouseSky.Models.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimeHouseSky.Models.Menu
{
    public class MainMenuModel : BaseModel
    {
        public MainMenuModel()
        {
            SomeText = "Hello world".GetLocalizedString();
        }

        private ObservableCollection<MainMenuItemModel> _menuItems;
        public ObservableCollection<MainMenuItemModel> MenuItems
        {
            get => _menuItems;
            set => Set(ref _menuItems, value);
        }

        private string _someText;
        public string SomeText
        {
            get => _someText;
            set => Set(ref _someText, value);
        }
    }
}
