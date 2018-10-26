using LimeHouseSky.Extensions;
using LimeHouseSky.Models.Menu;
using LimeHouseSky.Models.Message;
using LimeHouseSky.Models.Photo;
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
                },
                Messages = new ObservableCollection<MessageModel>
                {
                    new MessageModel
                    {
                        MainPhoto = new PhotoItemModel { PhotoUrl = "https://img1.badfon.ru/original/1600x1200/8/78/portret-vzglyad-makro.jpg" },
                        FirstName = "Mariana",
                        LastMessage = "Привет, что делаешь",
                        LastDateMessage = DateTime.Now,
                        MessageType = MessageType.FromRead
                    },
                    new MessageModel
                    {
                        MainPhoto = new PhotoItemModel { PhotoUrl = "https://wallbox.ru/resize/1680x1050/wallpapers/main/201546/33dd38ab305ee1e.jpg" },
                        FirstName = "Карина123 esasd 23123213 dsdasdsadd",
                        LastMessage = "Ты как всегда не успеваешь",
                        LastDateMessage = DateTime.Now,
                        MessageType = MessageType.FromUnread
                    },
                    new MessageModel
                    {
                        MainPhoto = new PhotoItemModel { PhotoUrl = "https://mota.ru/upload/wallpapers/source/2016/02/28/13/05/47636/mota.ru_20160228063.jpg" },
                        FirstName = "Валя",
                        LastMessage = "Почему ты переехала, ведь теперь тебе придётся далеко ехать на учёбу",
                        LastDateMessage = DateTime.Now,
                        MessageType = MessageType.To
                    },
                    new MessageModel
                    {
                        MainPhoto = new PhotoItemModel { PhotoUrl = "https://img1.badfon.ru/original/1600x1200/8/78/portret-vzglyad-makro.jpg" },
                        FirstName = "Елена",
                        LastMessage = "Привет, что делаешь",
                        LastDateMessage = DateTime.Now,
                        MessageType = MessageType.FromRead
                    },
                    new MessageModel
                    {
                        MainPhoto = new PhotoItemModel { PhotoUrl = "https://wallbox.ru/resize/1680x1050/wallpapers/main/201546/33dd38ab305ee1e.jpg" },
                        FirstName = "Оля",
                        LastMessage = "Ты как всегда не успеваешь",
                        LastDateMessage = DateTime.Now,
                        MessageType = MessageType.FromUnread
                    },
                    new MessageModel
                    {
                        MainPhoto = new PhotoItemModel { PhotoUrl = "https://mota.ru/upload/wallpapers/source/2016/02/28/13/05/47636/mota.ru_20160228063.jpg" },
                        FirstName = "Эля",
                        LastMessage = "Почему ты переехала, ведь теперь тебе придётся далеко ехать на учёбу",
                        LastDateMessage = DateTime.Now,
                        MessageType = MessageType.To
                    }
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
