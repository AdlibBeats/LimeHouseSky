using LimeHouseSky.Extensions;
using LimeHouseSky.Models.Menu;
using LimeHouseSky.Strings;
using LimeHouseSky.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Windows.ApplicationModel.Resources;

namespace LimeHouseSky.ViewModels
{
    public class MainMenuViewModel : BaseViewModel
    {
        public MainMenuViewModel()
        {
            var mainMenuResources = PathResources.MainMenuResources;
            MainMenuModel = new MainMenuModel
            {
                MenuItems = new ObservableCollection<MainMenuItemModel>
                {
                    new MainMenuItemModel { Text = "Acquaintances".GetLocalizedString(mainMenuResources) },
                    new MainMenuItemModel { Text = "Sympathies".GetLocalizedString(mainMenuResources) },
                    new MainMenuItemModel { Text = "Account".GetLocalizedString(mainMenuResources) },
                    new MainMenuItemModel { Text = "Settings".GetLocalizedString(mainMenuResources) },
                }
            };
        }

        private MainMenuModel _mainMenuModel;
        public MainMenuModel MainMenuModel
        {
            get => _mainMenuModel;
            set => Set(ref _mainMenuModel, value);
        }
    }
}
