using LimeHouseSky.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace LimeHouseSky.Pages.Main
{
    public sealed partial class MainMenuPage : Page, IPage
    {
        public MainMenuPage()
        {
            InitializeComponent();

            ViewModel = new MainMenuViewModel();
        }

        public MainMenuViewModel ViewModel { get; }
    }
}
