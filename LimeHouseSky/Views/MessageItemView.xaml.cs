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

using LimeHouseSky.Models.Message;

namespace LimeHouseSky.Views
{
    public sealed partial class MessageItemView : UserControl
    {
        public MessageItemView()
        {
            InitializeComponent();
        }

        public MessageModel MessageModel
        {
            get => (MessageModel)GetValue(MessageModelProperty);
            set => SetValue(MessageModelProperty, value);
        }

        public static readonly DependencyProperty MessageModelProperty =
            DependencyProperty.Register(nameof(MessageModel), typeof(MessageModel), typeof(MessageItemView),
                new PropertyMetadata(default));
    }
}
