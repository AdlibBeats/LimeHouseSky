using LimeHouseSky.DbContexts;
using LimeHouseSky.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

namespace LimeHouseSky
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private Company _company;

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            using (MobileContext db = new MobileContext())
            {
                _company = db.Companies.FirstOrDefault();
                if (_company == null)
                {
                    _company = new Company
                    {
                        Name = ""
                    };
                    db.Companies.Add(_company);
                    db.SaveChanges();
                }
            }
            textBox.Text = _company.Name;
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            _company.Name = textBox.Text;
            using (MobileContext db = new MobileContext())
            {
                db.Companies.Update(_company);
                db.SaveChanges();
            }
        }

        private void ContentHost_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            // Replace the ContentControl's content with a new Rectangle of a random color.
            Rectangle newItem = new Rectangle();
            Random rand = new Random();

            newItem.Height = 200;
            newItem.Width = 200;
            newItem.Fill = new SolidColorBrush(Color.FromArgb(255,
                 (byte)rand.Next(0, 255), (byte)rand.Next(0, 255), (byte)rand.Next(0, 255)));

            ContentHost.Content = newItem;
        }
    }
}
