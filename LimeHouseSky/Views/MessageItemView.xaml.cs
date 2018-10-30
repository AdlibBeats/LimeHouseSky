using LimeHouseSky.ViewModels;
using Microsoft.Graphics.Canvas.Effects;
using Microsoft.Toolkit.Uwp.UI.Animations.Expressions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using LimeHouseSky.Models.Message;

namespace LimeHouseSky.Views
{
    public sealed partial class MessageItemView : UserControl
    {
        private CompositionPropertySet _props;
        private CompositionPropertySet _scrollerPropertySet;
        private Compositor _compositor;
        private SpriteVisual _blurredBackgroundImageVisual;

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

        private void LayoutRoot_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            
        }

        private void LayoutRoot_PointerExited(object sender, PointerRoutedEventArgs e)
        {

        }
    }
}
